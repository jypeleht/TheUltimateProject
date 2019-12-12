using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FundScraperCore;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JyriLehto.Program.JyriLehto();
        }

        private void btn_TT_Click(object sender, EventArgs e)
        {
            FundScraperCore.Program.TomiTupiini();
        }
    }
}
