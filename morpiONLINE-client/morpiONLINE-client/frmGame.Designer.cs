
namespace morpiONLINE_client
{
    partial class frmGame
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
            this.btnReplay = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pibBox1 = new System.Windows.Forms.PictureBox();
            this.pibPlayer1 = new System.Windows.Forms.PictureBox();
            this.pibPlayer2 = new System.Windows.Forms.PictureBox();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.pibBox2 = new System.Windows.Forms.PictureBox();
            this.pibBox3 = new System.Windows.Forms.PictureBox();
            this.pibBox6 = new System.Windows.Forms.PictureBox();
            this.pibBox5 = new System.Windows.Forms.PictureBox();
            this.pibBox4 = new System.Windows.Forms.PictureBox();
            this.pibBox9 = new System.Windows.Forms.PictureBox();
            this.pibBox8 = new System.Windows.Forms.PictureBox();
            this.pibBox7 = new System.Windows.Forms.PictureBox();
            this.lblLignH1 = new System.Windows.Forms.Label();
            this.lblLignH2 = new System.Windows.Forms.Label();
            this.lblLignV1 = new System.Windows.Forms.Label();
            this.lblLignV2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReplay
            // 
            this.btnReplay.BackColor = System.Drawing.Color.Black;
            this.btnReplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReplay.ForeColor = System.Drawing.Color.White;
            this.btnReplay.Location = new System.Drawing.Point(247, 576);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(109, 46);
            this.btnReplay.TabIndex = 4;
            this.btnReplay.Text = "Rejouer";
            this.btnReplay.UseVisualStyleBackColor = false;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Black;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(452, 576);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(109, 46);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pibBox1
            // 
            this.pibBox1.Location = new System.Drawing.Point(217, 131);
            this.pibBox1.Name = "pibBox1";
            this.pibBox1.Size = new System.Drawing.Size(100, 100);
            this.pibBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox1.TabIndex = 6;
            this.pibBox1.TabStop = false;
            this.pibBox1.Tag = "0;0";
            this.pibBox1.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibPlayer1
            // 
            this.pibPlayer1.Image = global::morpiONLINE_client.Properties.Resources.cross;
            this.pibPlayer1.Location = new System.Drawing.Point(85, 15);
            this.pibPlayer1.Name = "pibPlayer1";
            this.pibPlayer1.Size = new System.Drawing.Size(50, 50);
            this.pibPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibPlayer1.TabIndex = 7;
            this.pibPlayer1.TabStop = false;
            // 
            // pibPlayer2
            // 
            this.pibPlayer2.Image = global::morpiONLINE_client.Properties.Resources.circle;
            this.pibPlayer2.Location = new System.Drawing.Point(664, 15);
            this.pibPlayer2.Name = "pibPlayer2";
            this.pibPlayer2.Size = new System.Drawing.Size(50, 50);
            this.pibPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibPlayer2.TabIndex = 8;
            this.pibPlayer2.TabStop = false;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.Location = new System.Drawing.Point(12, 77);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(197, 25);
            this.lblPlayer1.TabIndex = 9;
            this.lblPlayer1.Text = "Votre pseudo";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.Location = new System.Drawing.Point(591, 77);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(197, 25);
            this.lblPlayer2.TabIndex = 10;
            this.lblPlayer2.Text = "Adversaire";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pibBox2
            // 
            this.pibBox2.Location = new System.Drawing.Point(353, 131);
            this.pibBox2.Name = "pibBox2";
            this.pibBox2.Size = new System.Drawing.Size(100, 100);
            this.pibBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox2.TabIndex = 11;
            this.pibBox2.TabStop = false;
            this.pibBox2.Tag = "0;1";
            this.pibBox2.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox3
            // 
            this.pibBox3.Location = new System.Drawing.Point(491, 131);
            this.pibBox3.Name = "pibBox3";
            this.pibBox3.Size = new System.Drawing.Size(100, 100);
            this.pibBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox3.TabIndex = 12;
            this.pibBox3.TabStop = false;
            this.pibBox3.Tag = "0;2";
            this.pibBox3.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox6
            // 
            this.pibBox6.Location = new System.Drawing.Point(492, 256);
            this.pibBox6.Name = "pibBox6";
            this.pibBox6.Size = new System.Drawing.Size(100, 100);
            this.pibBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox6.TabIndex = 15;
            this.pibBox6.TabStop = false;
            this.pibBox6.Tag = "1;2";
            this.pibBox6.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox5
            // 
            this.pibBox5.Location = new System.Drawing.Point(353, 256);
            this.pibBox5.Name = "pibBox5";
            this.pibBox5.Size = new System.Drawing.Size(100, 100);
            this.pibBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox5.TabIndex = 14;
            this.pibBox5.TabStop = false;
            this.pibBox5.Tag = "1;1";
            this.pibBox5.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox4
            // 
            this.pibBox4.Location = new System.Drawing.Point(217, 256);
            this.pibBox4.Name = "pibBox4";
            this.pibBox4.Size = new System.Drawing.Size(100, 100);
            this.pibBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox4.TabIndex = 13;
            this.pibBox4.TabStop = false;
            this.pibBox4.Tag = "1;0";
            this.pibBox4.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox9
            // 
            this.pibBox9.Location = new System.Drawing.Point(491, 383);
            this.pibBox9.Name = "pibBox9";
            this.pibBox9.Size = new System.Drawing.Size(100, 100);
            this.pibBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox9.TabIndex = 18;
            this.pibBox9.TabStop = false;
            this.pibBox9.Tag = "2;2";
            this.pibBox9.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox8
            // 
            this.pibBox8.Location = new System.Drawing.Point(353, 383);
            this.pibBox8.Name = "pibBox8";
            this.pibBox8.Size = new System.Drawing.Size(100, 100);
            this.pibBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox8.TabIndex = 17;
            this.pibBox8.TabStop = false;
            this.pibBox8.Tag = "2;1";
            this.pibBox8.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // pibBox7
            // 
            this.pibBox7.Location = new System.Drawing.Point(217, 383);
            this.pibBox7.Name = "pibBox7";
            this.pibBox7.Size = new System.Drawing.Size(100, 100);
            this.pibBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibBox7.TabIndex = 16;
            this.pibBox7.TabStop = false;
            this.pibBox7.Tag = "2;0";
            this.pibBox7.Click += new System.EventHandler(this.pibBox_Click);
            // 
            // lblLignH1
            // 
            this.lblLignH1.BackColor = System.Drawing.Color.Black;
            this.lblLignH1.Location = new System.Drawing.Point(214, 240);
            this.lblLignH1.Name = "lblLignH1";
            this.lblLignH1.Size = new System.Drawing.Size(380, 2);
            this.lblLignH1.TabIndex = 19;
            // 
            // lblLignH2
            // 
            this.lblLignH2.BackColor = System.Drawing.Color.Black;
            this.lblLignH2.Location = new System.Drawing.Point(211, 368);
            this.lblLignH2.Name = "lblLignH2";
            this.lblLignH2.Size = new System.Drawing.Size(380, 2);
            this.lblLignH2.TabIndex = 20;
            // 
            // lblLignV1
            // 
            this.lblLignV1.BackColor = System.Drawing.Color.Black;
            this.lblLignV1.Location = new System.Drawing.Point(332, 122);
            this.lblLignV1.Name = "lblLignV1";
            this.lblLignV1.Size = new System.Drawing.Size(2, 380);
            this.lblLignV1.TabIndex = 21;
            // 
            // lblLignV2
            // 
            this.lblLignV2.BackColor = System.Drawing.Color.Black;
            this.lblLignV2.Location = new System.Drawing.Point(473, 122);
            this.lblLignV2.Name = "lblLignV2";
            this.lblLignV2.Size = new System.Drawing.Size(2, 380);
            this.lblLignV2.TabIndex = 22;
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 529);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(775, 23);
            this.lblError.TabIndex = 23;
            this.lblError.Text = "Message d\'erreur";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 643);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblLignV2);
            this.Controls.Add(this.lblLignV1);
            this.Controls.Add(this.lblLignH2);
            this.Controls.Add(this.lblLignH1);
            this.Controls.Add(this.pibBox9);
            this.Controls.Add(this.pibBox8);
            this.Controls.Add(this.pibBox7);
            this.Controls.Add(this.pibBox6);
            this.Controls.Add(this.pibBox5);
            this.Controls.Add(this.pibBox4);
            this.Controls.Add(this.pibBox3);
            this.Controls.Add(this.pibBox2);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.pibPlayer2);
            this.Controls.Add(this.pibPlayer1);
            this.Controls.Add(this.pibBox1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnReplay);
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "morpiONLINE";
            this.Load += new System.EventHandler(this.frmGame_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pibBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pibBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.PictureBox pibBox1;
        private System.Windows.Forms.PictureBox pibPlayer1;
        private System.Windows.Forms.PictureBox pibPlayer2;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.PictureBox pibBox2;
        private System.Windows.Forms.PictureBox pibBox3;
        private System.Windows.Forms.PictureBox pibBox6;
        private System.Windows.Forms.PictureBox pibBox5;
        private System.Windows.Forms.PictureBox pibBox4;
        private System.Windows.Forms.PictureBox pibBox9;
        private System.Windows.Forms.PictureBox pibBox8;
        private System.Windows.Forms.PictureBox pibBox7;
        private System.Windows.Forms.Label lblLignH1;
        private System.Windows.Forms.Label lblLignH2;
        private System.Windows.Forms.Label lblLignV1;
        private System.Windows.Forms.Label lblLignV2;
        private System.Windows.Forms.Label lblError;
    }
}