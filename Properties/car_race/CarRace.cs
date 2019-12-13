using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Properties.car_race
{
    public partial class CarRace : Form
    {

        int carSpeed = 5;
        int roadSpeed = 5;
        bool carLeft;
        bool carRight;
        int trafficSpeed = 5;
        int Score = 0;
        private Label label3;
        private Panel panel1;
        private PictureBox trophy;
        private PictureBox player;
        private PictureBox explosion;
        private PictureBox AI2;
        private PictureBox AI1;
        private PictureBox roadTrack2;
        private PictureBox roadTrack1;
        private Label distance;
        private Label label1;
        private Button btnStart;
        private Timer timer1;
        private IContainer components;
        Random rnd = new Random();

        public CarRace()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            trophy.Visible = false;

            btnStart.Enabled = false;

            explosion.Visible = false;

            trafficSpeed = 5;

            roadSpeed = 5;

            Score = 0;
            player.Left = 161;
            player.Top = 286;

            carLeft = false;
            carRight = false;

            AI1.Left = 66;
            AI1.Top = -120;

            AI1.Left = 294;
            AI1.Top = -185;

            roadTrack2.Left = -3;
            roadTrack2.Top = -222;
            roadTrack1.Left = -2;
            roadTrack1.Top = -638;

            timer1.Start();

        }


        private void timer1_Tic(object sender, EventArgs e)
        {
            Score++;

            distance.Text = "" + Score;

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;


            if (roadTrack1.Top > 630)
            {
                roadTrack1.Top = -630;
            }
            if (roadTrack2.Top > 630)
            {
                roadTrack2.Top = -630;
            }

            if (carLeft)
            {
                player.Left -= carSpeed;
            }
            if (carRight)
            {
                player.Left += carSpeed;
            }

            if (player.Left < 1)
            {
                carLeft = false;
            }
            else if (player.Left + player.Width > 380)
		{
                carRight = false;
            }

            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;

            if (AI1.Top > panel1.Height)
            {
                changeAI1();
                AI1.Left = rnd.Next(2, 160);
                AI1.Top = rnd.Next(100, 200) * -1;
            }
            if (AI2.Top > panel1.Height)
            {
                changeAI2();
                AI2.Left = rnd.Next(185, 327);
                AI2.Top = rnd.Next(100, 200) * -1;
            }

            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver();
            }

            if (Score > 100 && Score < 500)
            {
                trafficSpeed = 6;
                roadSpeed = 7;
            }
            else if (Score > 500 && Score < 1000)
            {
                trafficSpeed = 7;
                roadSpeed = 8;
            }
            else if (Score > 1200)
            {
                trafficSpeed = 9;
                roadSpeed = 10;
            }
        }

        private void moveCar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && player.Left > 0)
            {
                carLeft = true;
            }

            if (e.KeyCode == Keys.Right && player.Left + player.Width < panel1.Width)
            {
                carRight = true;
            }
        }




        private void stopCar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                carLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                carRight = false;
            }
        }






        private void playMusic()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"music.wav");
            player.Play();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void gameOver()
        {
            trophy.Visible = true;

            timer1.Stop();

            btnStart.Enabled = true;

            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;
            explosion.BringToFront();


            if (Score < 1000)
            {
                trophy.Image = Properties.Resources.bronze;
            }
            if (Score > 2000)
            {
                trophy.Image = Properties.Resources.silver;
            }
            if (Score > 3500)
            {
                trophy.Image = Properties.Resources.gold;
            }
        }

        private void changeAI1()
        {
            int num = rnd.Next(1, 8);

            switch (num)
            {
                case 1:
                    AI1.Image = Properties.Resources.carGreen;
                    break;
                case 2:
                    AI1.Image = Properties.Resources.carGrey;
                    break;
                case 3:
                    AI1.Image = Properties.Resources.carPink;
                    break;
                case 4:
                    AI1.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    AI1.Image = Properties.Resources.carRed;
                    break;
                case 6:
                    AI1.Image = Properties.Resources.truckBlue;
                    break;
                case 7:
                    AI1.Image = Properties.Resources.truckWhite;
                    break;
                case 8:
                    AI1.Image = Properties.Resources.ambulance;
                    break;
                default:
                    break;
            }
        }

        private void changeAI2()
        {
            int num = rnd.Next(1, 8);

            switch (num)
            {
                case 1:
                    AI2.Image = Properties.Resources.carGreen;
                    break;
                case 2:
                    AI2.Image = Properties.Resources.carGrey;
                    break;
                case 3:
                    AI2.Image = Properties.Resources.carPink;
                    break;
                case 4:
                    AI2.Image = Properties.Resources.carOrange;
                    break;
                case 5:
                    AI2.Image = Properties.Resources.carRed;
                    break;
                case 6:
                    AI2.Image = Properties.Resources.truckBlue;
                    break;
                case 7:
                    AI2.Image = Properties.Resources.truckWhite;
                    break;
                case 8:
                    AI2.Image = Properties.Resources.ambulance;
                    break;
                default:
                    break;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarRace));
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trophy = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.explosion = new System.Windows.Forms.PictureBox();
            this.AI2 = new System.Windows.Forms.PictureBox();
            this.AI1 = new System.Windows.Forms.PictureBox();
            this.roadTrack2 = new System.Windows.Forms.PictureBox();
            this.roadTrack1 = new System.Windows.Forms.PictureBox();
            this.distance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trophy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Avoid other cars and get ponts. Use Left  and Right keys to move the car.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.trophy);
            this.panel1.Controls.Add(this.player);
            this.panel1.Controls.Add(this.explosion);
            this.panel1.Controls.Add(this.AI2);
            this.panel1.Controls.Add(this.AI1);
            this.panel1.Controls.Add(this.roadTrack2);
            this.panel1.Controls.Add(this.roadTrack1);
            this.panel1.Location = new System.Drawing.Point(162, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 380);
            this.panel1.TabIndex = 8;
            // 
            // trophy
            // 
            this.trophy.BackColor = System.Drawing.Color.Transparent;
            this.trophy.Image = ((System.Drawing.Image)(resources.GetObject("trophy.Image")));
            this.trophy.Location = new System.Drawing.Point(66, 157);
            this.trophy.Name = "trophy";
            this.trophy.Size = new System.Drawing.Size(250, 100);
            this.trophy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.trophy.TabIndex = 6;
            this.trophy.TabStop = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(161, 286);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 101);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 5;
            this.player.TabStop = false;
            // 
            // explosion
            // 
            this.explosion.BackColor = System.Drawing.Color.Transparent;
            this.explosion.Image = ((System.Drawing.Image)(resources.GetObject("explosion.Image")));
            this.explosion.Location = new System.Drawing.Point(153, 234);
            this.explosion.Name = "explosion";
            this.explosion.Size = new System.Drawing.Size(64, 64);
            this.explosion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.explosion.TabIndex = 4;
            this.explosion.TabStop = false;
            // 
            // AI2
            // 
            this.AI2.BackColor = System.Drawing.Color.Transparent;
            this.AI2.Image = ((System.Drawing.Image)(resources.GetObject("AI2.Image")));
            this.AI2.Location = new System.Drawing.Point(294, 85);
            this.AI2.Name = "AI2";
            this.AI2.Size = new System.Drawing.Size(50, 101);
            this.AI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AI2.TabIndex = 3;
            this.AI2.TabStop = false;
            // 
            // AI1
            // 
            this.AI1.BackColor = System.Drawing.Color.Transparent;
            this.AI1.Image = ((System.Drawing.Image)(resources.GetObject("AI1.Image")));
            this.AI1.Location = new System.Drawing.Point(66, 19);
            this.AI1.Name = "AI1";
            this.AI1.Size = new System.Drawing.Size(50, 101);
            this.AI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AI1.TabIndex = 2;
            this.AI1.TabStop = false;
            // 
            // roadTrack2
            // 
            this.roadTrack2.Image = ((System.Drawing.Image)(resources.GetObject("roadTrack2.Image")));
            this.roadTrack2.Location = new System.Drawing.Point(-3, -222);
            this.roadTrack2.Name = "roadTrack2";
            this.roadTrack2.Size = new System.Drawing.Size(385, 632);
            this.roadTrack2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack2.TabIndex = 1;
            this.roadTrack2.TabStop = false;
            // 
            // roadTrack1
            // 
            this.roadTrack1.Image = ((System.Drawing.Image)(resources.GetObject("roadTrack1.Image")));
            this.roadTrack1.Location = new System.Drawing.Point(-2, -638);
            this.roadTrack1.Name = "roadTrack1";
            this.roadTrack1.Size = new System.Drawing.Size(385, 632);
            this.roadTrack1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roadTrack1.TabIndex = 0;
            this.roadTrack1.TabStop = false;
            // 
            // distance
            // 
            this.distance.AutoSize = true;
            this.distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.distance.Location = new System.Drawing.Point(105, 315);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(36, 26);
            this.distance.TabIndex = 7;
            this.distance.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(2, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Distance";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnStart.Location = new System.Drawing.Point(23, 380);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 76);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start Race";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // CarRace
            // 
            this.ClientSize = new System.Drawing.Size(609, 495);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "CarRace";
            this.Text = "Car Race Game";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trophy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roadTrack1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
