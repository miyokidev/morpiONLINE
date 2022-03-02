using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace morpiONLINE_client
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            // Rejoindre un salon
            this.Hide();
            frmRoom salon = new frmRoom();
            salon.ShowDialog();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Créer un salon
            this.Hide();
            frmRoom salon = new frmRoom();
            salon.ShowDialog();
            this.Close();
        }
    }
}
