using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void ButtonJMR_Click(object sender, EventArgs e)
        {
            Olio_Harjoitus.Program.JMR(null);
        }
            
        private void ButtonRahahomma_Click(object sender, EventArgs e)
        {
            rahajuttu.Program.rahajuttu();
        }

        private void ButtonArttu_Click(object sender, EventArgs e)
        {
            ArttuLaihorinne.Program.JyriLehto();
        }

        private void ButtonJarmo_Click(object sender, EventArgs e)
        {
            JarmoKarna.Program.JarmoKarna();
        }

        private void buttonTeemu_Click(object sender, EventArgs e)
        {
            ikä.Program.Aja();
        }

        private void BtnHello_Click(object sender, EventArgs e)
        {
            Mika.Program.Mika();
        }

        private void buttonTykit_Click(object sender, EventArgs e)
        {
            EsaKohtala.Program.EsaKohtala();
        }
    }
}
