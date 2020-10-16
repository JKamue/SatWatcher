using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatWatcher.Calculators;
using SatWatcher.Data;
using SatWatcher.Satellites;

namespace SatWatcher.Screen
{
    class BufferedScreenController
    {
        private readonly Panel _panel;
        private readonly Timer _timer;
        private readonly SqLiteDb _db;

        private BufferedGraphicsContext _context;
        private BufferedGraphics _graphicsBuffer;
        private Graphics _panelGraphics;

        public readonly SatellitesController _satellites;

        public BufferedScreenController(Panel panel, SatellitesController satellitesController, SqLiteDb db)
        {
            _panel = panel;
            _satellites = satellitesController;
            _db = db;

            SetupGraphics();

            // Setup Timer
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += Redraw;
            _timer.Start();

            _panel.SizeChanged += PanelResizeEvent;
            _satellites.SelectionChanged += Redraw;
        }

        public void PanelResizeEvent(object sender, EventArgs e) => SetupGraphics();

        private void RedrawNow() => Redraw(this, EventArgs.Empty);

        private void SetupGraphics()
        {
            _context = BufferedGraphicsManager.Current;
            _panelGraphics = _panel.CreateGraphics();
            _graphicsBuffer = _context.Allocate(_panelGraphics, _panel.DisplayRectangle);
            RedrawNow();
        }

        private void Redraw(object sender, EventArgs e)
        {
            var graphics = _graphicsBuffer.Graphics;
            graphics.Clear(Color.White);
            graphics.DrawImage(Properties.Resources.world,0,0, _panel.Width+1, _panel.Height+1);
            var corCalc = new CoordinateCalculator(_panel.Size);

            DrawGrid(corCalc, graphics);
            DrawPosition(corCalc, graphics);

            if (_satellites.MainSatellite != null)
                _satellites.MainSatellite.DrawLine(graphics, corCalc);

            foreach (var satellite in _satellites.SelectedSatellites)
                satellite.DrawLocation(graphics, corCalc);

            _graphicsBuffer.Render(_panelGraphics);
        }

        private void DrawPosition(CoordinateCalculator corCalc, Graphics g)
        {
            var point = _db.GetPosition();
            var projectd = corCalc.MapPoint(new PointF(Decimal.ToSingle(point.lng), Decimal.ToSingle(point.lat)));

            g.DrawLine(new Pen(Color.Red, 2), projectd.X - 6, projectd.Y, projectd.X + 6, projectd.Y);
            g.DrawLine(new Pen(Color.Red, 2), projectd.X, projectd.Y - 6, projectd.X, projectd.Y + 6);
        }

        private void DrawGrid(CoordinateCalculator corCalc, Graphics g)
        {
            var fontSize = (float)Math.Round(0.013888888888889 * _panel.Width + 5);
            var font = new Font("Times New Roman", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            for (var i = 60; i >= -60; i -= 30)
            {
                var start = corCalc.MapPoint(new PointF(-180, i));
                var end = corCalc.MapPoint(new PointF(180, i));

                g.DrawString($"{i}°", font, new SolidBrush(Color.White), start);
                g.DrawLine(new Pen(Color.LightGray, 1), start, end);
            }

            for (var i = -180; i <= 180; i += 30)
            {
                var start = corCalc.MapPoint(new PointF(i, 90));
                var end = corCalc.MapPoint(new PointF(i, -90));

                g.DrawString($"{i}°", font, new SolidBrush(Color.White), new PointF(start.X, start.Y + 20));
                g.DrawLine(new Pen(Color.LightGray, 1), start, end);
            }
        }
    }
}
