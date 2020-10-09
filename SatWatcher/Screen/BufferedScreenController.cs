using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatWatcher.Calculators;
using SatWatcher.Satellites;

namespace SatWatcher.Screen
{
    class BufferedScreenController
    {
        private readonly Panel _panel;
        private readonly Timer _timer;

        private BufferedGraphicsContext _context;
        private BufferedGraphics _graphicsBuffer;
        private Graphics _panelGraphics;

        public readonly SatellitesController _satellites;

        public BufferedScreenController(Panel panel, SatellitesController satellitesController)
        {
            _panel = panel;
            _satellites = satellitesController;

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

            foreach (var satellite in _satellites.SelectedSatellites)
                satellite.DrawLocation(graphics, corCalc);

            if (_satellites.MainSatellite != null)
                _satellites.MainSatellite.DrawLine(graphics, corCalc);


            _graphicsBuffer.Render(_panelGraphics);
        }
    }
}
