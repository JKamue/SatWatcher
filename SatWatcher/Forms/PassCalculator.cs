using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatWatcher.Forms
{
    public partial class PassCalculator : Form
    {
        public PassCalculator()
        {
            InitializeComponent();
            FormClosing += PassCalcHider;
        }

        private void PassCalcHider(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
