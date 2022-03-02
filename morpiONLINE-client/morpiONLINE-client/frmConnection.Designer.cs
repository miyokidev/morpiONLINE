
namespace morpiONLINE_client
{
    partial class frmConnection
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
            this.grbConnection = new System.Windows.Forms.GroupBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grbInscription = new System.Windows.Forms.GroupBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblNewUser = new System.Windows.Forms.Label();
            this.tbxConfirmPassword = new System.Windows.Forms.TextBox();
            this.tbxNewPassword = new System.Windows.Forms.TextBox();
            this.tbxNewUser = new System.Windows.Forms.TextBox();
            this.lblInscription = new System.Windows.Forms.Label();
            this.btnInscription = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.grbConnection.SuspendLayout();
            this.grbInscription.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbConnection
            // 
            this.grbConnection.Controls.Add(this.lblPassword);
            this.grbConnection.Controls.Add(this.lblUser);
            this.grbConnection.Controls.Add(this.tbxPassword);
            this.grbConnection.Controls.Add(this.tbxUser);
            this.grbConnection.Controls.Add(this.lblConnection);
            this.grbConnection.Controls.Add(this.btnConnect);
            this.grbConnection.Location = new System.Drawing.Point(133, 59);
            this.grbConnection.Name = "grbConnection";
            this.grbConnection.Size = new System.Drawing.Size(216, 336);
            this.grbConnection.TabIndex = 7;
            this.grbConnection.TabStop = false;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(37, 152);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(81, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Mot de passe";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(37, 97);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(49, 15);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Pseudo";
            // 
            // tbxPassword
            // 
            this.tbxPassword.BackColor = System.Drawing.Color.Silver;
            this.tbxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(40, 170);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(138, 26);
            this.tbxPassword.TabIndex = 2;
            // 
            // tbxUser
            // 
            this.tbxUser.BackColor = System.Drawing.Color.Silver;
            this.tbxUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUser.Location = new System.Drawing.Point(40, 115);
            this.tbxUser.Name = "tbxUser";
            this.tbxUser.Size = new System.Drawing.Size(138, 26);
            this.tbxUser.TabIndex = 1;
            // 
            // lblConnection
            // 
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnection.Location = new System.Drawing.Point(6, 42);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(204, 25);
            this.lblConnection.TabIndex = 0;
            this.lblConnection.Text = "Connexion";
            this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.Black;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(92, 242);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(86, 26);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Se connecter";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grbInscription
            // 
            this.grbInscription.Controls.Add(this.lblConfirmPassword);
            this.grbInscription.Controls.Add(this.lblNewPassword);
            this.grbInscription.Controls.Add(this.lblNewUser);
            this.grbInscription.Controls.Add(this.tbxConfirmPassword);
            this.grbInscription.Controls.Add(this.tbxNewPassword);
            this.grbInscription.Controls.Add(this.tbxNewUser);
            this.grbInscription.Controls.Add(this.lblInscription);
            this.grbInscription.Controls.Add(this.btnInscription);
            this.grbInscription.Location = new System.Drawing.Point(428, 59);
            this.grbInscription.Name = "grbInscription";
            this.grbInscription.Size = new System.Drawing.Size(216, 336);
            this.grbInscription.TabIndex = 8;
            this.grbInscription.TabStop = false;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(37, 206);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(138, 15);
            this.lblConfirmPassword.TabIndex = 10;
            this.lblConfirmPassword.Text = "Confirmer mot de passe";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(37, 152);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(81, 15);
            this.lblNewPassword.TabIndex = 9;
            this.lblNewPassword.Text = "Mot de passe";
            // 
            // lblNewUser
            // 
            this.lblNewUser.AutoSize = true;
            this.lblNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewUser.Location = new System.Drawing.Point(37, 97);
            this.lblNewUser.Name = "lblNewUser";
            this.lblNewUser.Size = new System.Drawing.Size(49, 15);
            this.lblNewUser.TabIndex = 8;
            this.lblNewUser.Text = "Pseudo";
            // 
            // tbxConfirmPassword
            // 
            this.tbxConfirmPassword.BackColor = System.Drawing.Color.Silver;
            this.tbxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConfirmPassword.Location = new System.Drawing.Point(40, 224);
            this.tbxConfirmPassword.Name = "tbxConfirmPassword";
            this.tbxConfirmPassword.PasswordChar = '*';
            this.tbxConfirmPassword.Size = new System.Drawing.Size(138, 26);
            this.tbxConfirmPassword.TabIndex = 3;
            // 
            // tbxNewPassword
            // 
            this.tbxNewPassword.BackColor = System.Drawing.Color.Silver;
            this.tbxNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNewPassword.Location = new System.Drawing.Point(40, 170);
            this.tbxNewPassword.Name = "tbxNewPassword";
            this.tbxNewPassword.PasswordChar = '*';
            this.tbxNewPassword.Size = new System.Drawing.Size(138, 26);
            this.tbxNewPassword.TabIndex = 2;
            // 
            // tbxNewUser
            // 
            this.tbxNewUser.BackColor = System.Drawing.Color.Silver;
            this.tbxNewUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNewUser.Location = new System.Drawing.Point(40, 115);
            this.tbxNewUser.Name = "tbxNewUser";
            this.tbxNewUser.Size = new System.Drawing.Size(138, 26);
            this.tbxNewUser.TabIndex = 1;
            // 
            // lblInscription
            // 
            this.lblInscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInscription.Location = new System.Drawing.Point(6, 42);
            this.lblInscription.Name = "lblInscription";
            this.lblInscription.Size = new System.Drawing.Size(204, 25);
            this.lblInscription.TabIndex = 0;
            this.lblInscription.Text = "Inscription";
            this.lblInscription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInscription
            // 
            this.btnInscription.BackColor = System.Drawing.Color.Black;
            this.btnInscription.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInscription.ForeColor = System.Drawing.Color.White;
            this.btnInscription.Location = new System.Drawing.Point(92, 273);
            this.btnInscription.Name = "btnInscription";
            this.btnInscription.Size = new System.Drawing.Size(86, 26);
            this.btnInscription.TabIndex = 4;
            this.btnInscription.Text = "S\'inscrire";
            this.btnInscription.UseVisualStyleBackColor = false;
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(130, 43);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(514, 13);
            this.lblError.TabIndex = 8;
            this.lblError.Text = "Message d\'erreur";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.ForeColor = System.Drawing.Color.Green;
            this.lblSuccess.Location = new System.Drawing.Point(425, 43);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(137, 13);
            this.lblSuccess.TabIndex = 9;
            this.lblSuccess.Text = "Compte créé avec succès !";
            this.lblSuccess.Visible = false;
            // 
            // frmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.grbInscription);
            this.Controls.Add(this.grbConnection);
            this.Name = "frmConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "morpiONLINE";
            this.grbConnection.ResumeLayout(false);
            this.grbConnection.PerformLayout();
            this.grbInscription.ResumeLayout(false);
            this.grbInscription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbConnection;
        private System.Windows.Forms.TextBox tbxUser;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.GroupBox grbInscription;
        private System.Windows.Forms.TextBox tbxNewPassword;
        private System.Windows.Forms.TextBox tbxNewUser;
        private System.Windows.Forms.Label lblInscription;
        private System.Windows.Forms.Button btnInscription;
        private System.Windows.Forms.TextBox tbxConfirmPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblNewUser;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblSuccess;
    }
}