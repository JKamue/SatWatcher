﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using One_Sgp4;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Annotations;
using SatWatcher.Data.Dtos;
using SatWatcher.Forms;

namespace SatWatcher.Data
{
    class PassPdf
    {
        private Document document;
        private Table table;
        private TextFrame addressFrame;
        private PassSettingDto settings;
        private List<PassCalculator.SatPass> passes;
        public Document GetPassPdf(string filename, PassSettingDto settings, List<PassCalculator.SatPass> passes)
        {
            this.settings = settings;
            this.passes = passes;

            // Create a new MigraDoc document
            this.document = new Document();
            this.document.Info.Title = "Satellite pass list";
            this.document.Info.Subject = "Simple satellite pass list generated by SatWatcher";
            this.document.Info.Author = "Jannes Kaspar-Müller";

            DefineStyles();

            CreatePage();

            AddTableData();

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();

            // Save the document...
            renderer.PdfDocument.Save(filename);
            Process.Start(filename);
            return this.document;
        }

        void DefineStyles()
        {
            // Get the predefined style Normal.
            Style style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 12;

            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            Section section = this.document.AddSection();
            // Put a logo in the header
            Image image = section.Headers.Primary.AddImage("Resources\\logo-background.jpeg");
            image.Height = "2.5cm";
            image.LockAspectRatio = true;
            image.RelativeVertical = RelativeVertical.Line;
            image.RelativeHorizontal = RelativeHorizontal.Margin;
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Right;
            image.WrapFormat.Style = WrapStyle.Through;

            TextFrame textFrame = new TextFrame();
            textFrame.Width = new Unit(530);
            textFrame.Height = new Unit(40);
            textFrame.RelativeHorizontal = RelativeHorizontal.Page;
            textFrame.RelativeVertical = RelativeVertical.Page;
            textFrame.WrapFormat.DistanceLeft = new Unit(10, UnitType.Millimeter);
            textFrame.WrapFormat.DistanceTop = new Unit(65, UnitType.Point);

            var paragraph = textFrame.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.AddFormattedText("Satellite pass list", new Font("Arial", 18));

            section.Add(textFrame);

            // Create footer
            paragraph = section.Footers.Primary.AddParagraph();

            paragraph.AddText("Generated by ");
            var satWatcherHyperlink = paragraph.AddHyperlink("https://github.com/JKamue/SatWatcher", HyperlinkType.Web);
            satWatcherHyperlink.AddFormattedText("SatWatcher");

            paragraph.AddText(" · Programmed by ");
            var jkamueHyperlink = paragraph.AddHyperlink("http://jkamue.de", HyperlinkType.Web);
            jkamueHyperlink.AddFormattedText("JKamue");


            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "2.2cm";
            paragraph.AddFormattedText("Settings\n", new Font("Arial", 14));
            paragraph.AddFormattedText("\tLocation: \t\t", new Font("Arial", 12));
            var locationHyperlink = paragraph.AddHyperlink(@"https://geohack.toolforge.org/geohack.php?language=en&params=" + settings.Location.lat.ToString(CultureInfo.GetCultureInfo("en-US"))+ ";" + settings.Location.lng.ToString(CultureInfo.GetCultureInfo("en-US")), HyperlinkType.Web);
            locationHyperlink.AddFormattedText($"Lat: {settings.Location.lat} Lng: {settings.Location.lng}\n");
            locationHyperlink.Font = new Font("Arial", 12);
            locationHyperlink.Font.Underline = Underline.Single;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.AddFormattedText($"\tTimeframe: \t\t{settings.Start} - {settings.Start.AddDays(settings.Days)}\n", new Font("Arial", 12));
            paragraph.AddFormattedText($"\tMin. Elevation: \t{settings.MinElevtation}°\n", new Font("Arial", 12));
            paragraph.AddFormattedText($"\tSelected Satellites: \t{string.Join(", ", settings.SelectedSatellites)}\n\n\n", new Font("Arial", 12));

            // Add table
            table = section.AddTable();
            table.Borders.Width = 0.5;
            table.Style = "Table";

            // Add column
            Column column = this.table.AddColumn("1.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("2.2cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.15cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.25cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.15cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.25cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.75cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.15cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("1.25cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            // Add Header row
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Date");
            row.Cells[0].MergeDown = 1;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[1].AddParagraph("Satellite");
            row.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;
            row.Cells[1].MergeDown = 1;
            row.Cells[2].AddParagraph("Start");
            row.Cells[2].MergeRight = 2;
            row.Cells[5].AddParagraph("Max. Elev");
            row.Cells[5].MergeRight = 2;
            row.Cells[8].AddParagraph("End");
            row.Cells[8].MergeRight = 2;

            // Add clarification row
            row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Cells[2].AddParagraph("Time");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].AddParagraph("Elev.");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].AddParagraph("Azim.");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[5].AddParagraph("Time");
            row.Cells[5].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[6].AddParagraph("Elev.");
            row.Cells[6].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[7].AddParagraph("Azim.");
            row.Cells[7].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[8].AddParagraph("Time");
            row.Cells[8].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[9].AddParagraph("Elev.");
            row.Cells[9].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[10].AddParagraph("Azim.");
            row.Cells[10].Format.Alignment = ParagraphAlignment.Center;
        }

        private void AddTableData()
        {
            var font = new Font("Arial", 10);
            foreach (var pass in passes)
            {
                var row = table.AddRow();
                var paragraph = row.Cells[0].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getStartEpoch().toDateTime().ToString("yy-M-d"), font);
                paragraph = row.Cells[1].AddParagraph();
                paragraph.AddFormattedText(pass.Name, font);
                paragraph = row.Cells[2].AddParagraph();
                row.Cells[2].Shading.Color = Color.FromArgb(70, 0, 255, 0);
                paragraph.AddFormattedText(pass.Pass.getPassDetailsAtStart().time.toDateTime().ToString("T"), font);
                paragraph = row.Cells[3].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailsAtStart().elevation.ToString("F1"), font);
                paragraph = row.Cells[4].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailsAtStart().azimuth.ToString("F1"), font);
                paragraph = row.Cells[5].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailOfMaxElevation().time.toDateTime().ToString("T"), font);
                paragraph = row.Cells[6].AddParagraph();
                row.Cells[6].Shading.Color = Color.FromArgb(70, 255, 0, 0);
                paragraph.AddFormattedText(pass.Pass.getPassDetailOfMaxElevation().elevation.ToString("F1"), font);
                paragraph = row.Cells[7].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailOfMaxElevation().azimuth.ToString("F1"), font);
                paragraph = row.Cells[8].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailsAtEnd().time.toDateTime().ToString("T"), font);
                paragraph = row.Cells[9].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailsAtEnd().elevation.ToString("F1"), font);
                paragraph = row.Cells[10].AddParagraph();
                paragraph.AddFormattedText(pass.Pass.getPassDetailsAtEnd().azimuth.ToString("F1"), font);
            }
        }

        private static void DrawImage(XGraphics gfx, int x, int y, int width, int height)
        {
            var test = new MemoryStream();
            Properties.Resources.logo_background.Save(test, ImageFormat.Png);
            XImage image = XImage.FromStream(test);
            gfx.DrawImage(image, x, y, width, height);

            
        }
    }
}
