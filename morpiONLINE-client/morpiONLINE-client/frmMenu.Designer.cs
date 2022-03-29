namespace morpiONLINE_client
{
    partial class frmMenu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblJoin = new System.Windows.Forms.Label();
            this.tbxRoomCode = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnJoin = new System.Windows.Forms.Button();
            this.lblCreate = new System.Windows.Forms.Label();
            this.grbHome = new System.Windows.Forms.GroupBox();
            this.lblRoomCode = new System.Windows.Forms.Label();
            this.grbHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJoin
            // 
            this.lblJoin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoin.Location = new System.Drawing.Point(6, 32);
            this.lblJoin.Name = "lblJoin";
            this.lblJoin.Size = new System.Drawing.Size(204, 25);
            this.lblJoin.TabIndex = 0;
            this.lblJoin.Text = "Rejoindre un salon";
            this.lblJoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxRoomCode
            // 
            this.tbxRoomCode.BackColor = System.Drawing.Color.Silver;
            this.tbxRoomCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRoomCode.Location = new System.Drawing.Point(43, 93);
            this.tbxRoomCode.Name = "tbxRoomCode";
            this.tbxRoomCode.Size = new System.Drawing.Size(138, 26);
            this.tbxRoomCode.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Black;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(58, 252);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(109, 46);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Créer";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.Black;
            this.btnJoin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnJoin.ForeColor = System.Drawing.Color.White;
            this.btnJoin.Location = new System.Drawing.Point(95, 137);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(86, 26);
            this.btnJoin.TabIndex = 4;
            this.btnJoin.Text = "Rejoindre";
            this.btnJoin.UseVisualStyleBackColor = false;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // lblCreate
            // 
            this.lblCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.Location = new System.Drawing.Point(11, 205);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(199, 25);
            this.lblCreate.TabIndex = 5;
            this.lblCreate.Text = "Créer un salon";
            this.lblCreate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbHome
            // 
            this.grbHome.Controls.Add(this.lblRoomCode);
            this.grbHome.Controls.Add(this.tbxRoomCode);
            this.grbHome.Controls.Add(this.lblCreate);
            this.grbHome.Controls.Add(this.lblJoin);
            this.grbHome.Controls.Add(this.btnJoin);
            this.grbHome.Controls.Add(this.btnCreate);
            this.grbHome.Location = new System.Drawing.Point(330, 85);
            this.grbHome.Name = "grbHome";
            this.grbHome.Size = new System.Drawing.Size(216, 336);
            this.grbHome.TabIndex = 6;
            this.grbHome.TabStop = false;
            // 
            // lblRoomCode
            // 
            this.lblRoomCode.AutoSize = true;
            this.lblRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCode.Location = new System.Drawing.Point(40, 75);
            this.lblRoomCode.Name = "lblRoomCode";
            this.lblRoomCode.Size = new System.Drawing.Size(86, 15);
            this.lblRoomCode.TabIndex = 9;
            this.lblRoomCode.Text = "Code du salon";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.grbHome);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "morpiONLINE";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.grbHome.ResumeLayout(false);
            this.grbHome.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblJoin;
        private System.Windows.Forms.TextBox tbxRoomCode;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.GroupBox grbHome;
        private System.Windows.Forms.Label lblRoomCode;
    }
}

