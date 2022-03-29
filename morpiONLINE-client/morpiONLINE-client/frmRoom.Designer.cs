
namespace morpiONLINE_client
{
    partial class frmRoom
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
            this.lblWaitingLaunch = new System.Windows.Forms.Label();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.lblIdRoom = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWaitingLaunch
            // 
            this.lblWaitingLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingLaunch.Location = new System.Drawing.Point(12, 23);
            this.lblWaitingLaunch.Name = "lblWaitingLaunch";
            this.lblWaitingLaunch.Size = new System.Drawing.Size(776, 49);
            this.lblWaitingLaunch.TabIndex = 1;
            this.lblWaitingLaunch.Text = "En attente du lancement...";
            this.lblWaitingLaunch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayers
            // 
            this.lblPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayers.Location = new System.Drawing.Point(18, 132);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(369, 25);
            this.lblPlayers.TabIndex = 2;
            this.lblPlayers.Text = "Joueurs :";
            this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.Location = new System.Drawing.Point(12, 174);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(778, 25);
            this.lblPlayer1.TabIndex = 3;
            this.lblPlayer1.Text = "Votre pseudo";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Black;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(278, 330);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 46);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Lancer la partie";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.Location = new System.Drawing.Point(11, 213);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(778, 25);
            this.lblPlayer2.TabIndex = 6;
            this.lblPlayer2.Text = "Adversaire";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIdRoom
            // 
            this.lblIdRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdRoom.Location = new System.Drawing.Point(241, 88);
            this.lblIdRoom.Name = "lblIdRoom";
            this.lblIdRoom.Size = new System.Drawing.Size(199, 25);
            this.lblIdRoom.TabIndex = 7;
            this.lblIdRoom.Text = "Code du salon";
            this.lblIdRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(423, 87);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(84, 30);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copier code";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.BackColor = System.Drawing.Color.Black;
            this.btnLeave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeave.ForeColor = System.Drawing.Color.White;
            this.btnLeave.Location = new System.Drawing.Point(412, 330);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(109, 46);
            this.btnLeave.TabIndex = 9;
            this.btnLeave.Text = "Quitter";
            this.btnLeave.UseVisualStyleBackColor = false;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 397);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(776, 23);
            this.lblError.TabIndex = 11;
            this.lblError.Text = "Message d\'erreur";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // frmRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblIdRoom);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lblWaitingLaunch);
            this.Name = "frmRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "morpiONLINE";
            this.Load += new System.EventHandler(this.frmRoom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWaitingLaunch;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblIdRoom;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnLeave;
        private System.Windows.Forms.Label lblError;
    }
}