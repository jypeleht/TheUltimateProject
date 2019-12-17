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
            this.button1 = new System.Windows.Forms.Button();
            this.btnHello = new System.Windows.Forms.Button();
            this.buttonJMR = new System.Windows.Forms.Button();
            this.buttonJarmo = new System.Windows.Forms.Button();
            this.buttonArttu = new System.Windows.Forms.Button();
            this.buttonRahahomma = new System.Windows.Forms.Button();
            this.buttonTeemu = new System.Windows.Forms.Button();
            this.buttonTykit = new System.Windows.Forms.Button();
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
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(22, 238);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(143, 53);
            this.btnHello.TabIndex = 1;
            this.btnHello.Text = "Hello World!";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.BtnHello_Click);
            // 
            // buttonJMR
            // 
            this.buttonJMR.Location = new System.Drawing.Point(22, 201);
            this.buttonJMR.Name = "buttonJMR";
            this.buttonJMR.Size = new System.Drawing.Size(75, 23);
            this.buttonJMR.TabIndex = 1;
            this.buttonJMR.Text = "JMR";
            this.buttonJMR.UseVisualStyleBackColor = true;
            this.buttonJMR.Click += new System.EventHandler(this.ButtonJMR_Click);
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
            // buttonTeemu
            // 
            this.buttonTeemu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTeemu.Location = new System.Drawing.Point(382, 24);
            this.buttonTeemu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTeemu.Name = "buttonTeemu";
            this.buttonTeemu.Size = new System.Drawing.Size(143, 52);
            this.buttonTeemu.TabIndex = 1;
            this.buttonTeemu.Text = "Ikäsi";
            this.buttonTeemu.UseVisualStyleBackColor = true;
            this.buttonTeemu.Click += new System.EventHandler(this.buttonTeemu_Click);
            // 
            // buttonTykit
            // 
            this.buttonTykit.Location = new System.Drawing.Point(445, 127);
            this.buttonTykit.Name = "buttonTykit";
            this.buttonTykit.Size = new System.Drawing.Size(126, 59);
            this.buttonTykit.TabIndex = 2;
            this.buttonTykit.Text = "Tykit";
            this.buttonTykit.UseVisualStyleBackColor = true;
            this.buttonTykit.Click += new System.EventHandler(this.buttonTykit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.buttonTykit);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.buttonJMR);
            this.Controls.Add(this.buttonTeemu);
            this.Controls.Add(this.buttonJarmo);
            this.Controls.Add(this.buttonArttu);
            this.Controls.Add(this.buttonRahahomma);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "UltimateProject";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Button buttonJMR;
        private System.Windows.Forms.Button buttonJarmo;
        private System.Windows.Forms.Button buttonArttu;
        private System.Windows.Forms.Button buttonRahahomma;
        private System.Windows.Forms.Button buttonTeemu;
        private System.Windows.Forms.Button buttonTykit;
    }
}

