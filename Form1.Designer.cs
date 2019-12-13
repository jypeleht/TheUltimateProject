namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonJarmo = new System.Windows.Forms.Button();
            this.buttonArttu = new System.Windows.Forms.Button();
            this.buttonRahahomma = new System.Windows.Forms.Button();
            this.buttonStartRace = new System.Windows.Forms.Button();
            this.buttonLeftCar = new System.Windows.Forms.Button();
            this.buttonRightCar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(22, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Esimerkki";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(182, 24);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Ikäsi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            //
            // buttonJarmo
            // 
            this.buttonJarmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonJarmo.Location = new System.Drawing.Point(22, 99);
            this.buttonJarmo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonJarmo.Name = "buttonJarmo";
            this.buttonJarmo.Size = new System.Drawing.Size(143, 87);
            this.buttonJarmo.TabIndex = 1;
            this.buttonJarmo.Text = "Jarmon Esimerkki";
            this.buttonJarmo.UseVisualStyleBackColor = true;
            this.buttonJarmo.Click += new System.EventHandler(this.ButtonJarmo_Click);
            // 
            // buttonArttu
            // 
            this.buttonArttu.Location = new System.Drawing.Point(221, 127);
            this.buttonArttu.Name = "buttonArttu";
            this.buttonArttu.Size = new System.Drawing.Size(142, 131);
            this.buttonArttu.TabIndex = 1;
            this.buttonArttu.Text = "taikanappi";
            this.buttonArttu.UseVisualStyleBackColor = true;
            this.buttonArttu.Click += new System.EventHandler(this.ButtonArttu_Click);
            // 
            // buttonRahahomma
            // 
            this.buttonRahahomma.Location = new System.Drawing.Point(258, 24);
            this.buttonRahahomma.Name = "buttonRahahomma";
            this.buttonRahahomma.Size = new System.Drawing.Size(93, 51);
            this.buttonRahahomma.TabIndex = 1;
            this.buttonRahahomma.Text = "rahahomma";
            this.buttonRahahomma.UseVisualStyleBackColor = true;
            this.buttonRahahomma.Click += new System.EventHandler(this.ButtonRahahomma_Click);
            // 
            // buttonStartRace
            // 
            this.buttonStartRace.Location = new System.Drawing.Point(258, 300);
            this.buttonStartRace.Name = "buttonStartRace";
            this.buttonStartRace.Size = new System.Drawing.Size(75, 23);
            this.buttonStartRace.TabIndex = 2;
            this.buttonStartRace.Text = "Start race";
            this.buttonStartRace.UseVisualStyleBackColor = true;
            this.buttonStartRace.Click += new System.EventHandler(this.ButtonStartRace_Click);
            // 
            // buttonLeftCar
            // 
            this.buttonLeftCar.Location = new System.Drawing.Point(414, 3);
            this.buttonLeftCar.Name = "buttonLeftCar";
            this.buttonLeftCar.Size = new System.Drawing.Size(50, 10);
            this.buttonLeftCar.TabIndex = 3;
            this.buttonLeftCar.Text = "Left car";
            this.buttonLeftCar.UseVisualStyleBackColor = true;
            // 
            // buttonRightCar
            // 
            this.buttonRightCar.Location = new System.Drawing.Point(503, 242);
            this.buttonRightCar.Name = "buttonRightCar";
            this.buttonRightCar.Size = new System.Drawing.Size(47, 93);
            this.buttonRightCar.TabIndex = 4;
            this.buttonRightCar.Text = "Right car";
            this.buttonRightCar.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(450, 218);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 90);
            this.button2.TabIndex = 5;
            this.button2.Text = "Left car";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonRightCar);
            this.Controls.Add(this.buttonLeftCar);
            this.Controls.Add(this.buttonStartRace);
            this.Controls.Add(this.buttonJarmo);
            this.Controls.Add(this.buttonArttu);
            this.Controls.Add(this.buttonRahahomma);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "UltimateProject";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonJarmo;
        private System.Windows.Forms.Button buttonArttu;
        private System.Windows.Forms.Button buttonRahahomma;
        private System.Windows.Forms.Button buttonStartRace;
        private System.Windows.Forms.Button buttonLeftCar;
        private System.Windows.Forms.Button buttonRightCar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
    }
}

