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
    public partial class frmGame : Form
    {
        enum Players { Player1, Player2};
        Players whosTurn;
        Image imgPlayer1;
        Image imgPlayer2;

        public frmGame()
        {
            InitializeComponent();

            // Récupération de quel joueur est quelle forme (manuel pour le moment)
            whosTurn = Players.Player1;
            imgPlayer1 = Properties.Resources.cross;
            imgPlayer2 = Properties.Resources.circle;
        }

        public void Play(object sender, EventArgs e)
        {
            PictureBox clickedBox = sender as PictureBox;

            switch (whosTurn)
            {
                case Players.Player1:
                    clickedBox.Image = imgPlayer1;
                    whosTurn = Players.Player2;
                    break;
                case Players.Player2:
                    clickedBox.Image = imgPlayer2;
                    whosTurn = Players.Player1;
                    break;
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            // Retour au menu
            /*
            this.Hide();
            frmMenu menu = new frmMenu();
            menu.ShowDialog();
            this.Close();
            */
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            // Rejouer une partie
        }

        private void pibBox_Click(object sender, EventArgs e)
        {
            Play(sender, e);
        }
    }
}
