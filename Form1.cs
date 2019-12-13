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
        bool raceIsOn = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JyriLehto.Program.JyriLehto();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ikä.Program.Aja();
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

        private void ButtonStartRace_Click(object sender, EventArgs e)
        {
            if (!raceIsOn)
            {
                buttonStartRace.Text = "Stop race";
                raceIsOn = true;
                timer1.Enabled = true;
            }
            else
            {
                buttonStartRace.Text = "Start race";
                raceIsOn = false;
                timer1.Enabled = false;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            buttonLeftCar.Location = new Point(buttonLeftCar.Location.X, buttonLeftCar.Location.Y - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
