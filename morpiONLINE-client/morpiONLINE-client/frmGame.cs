using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SocketIOClient;

namespace morpiONLINE_client
{
    public partial class frmGame : Form
    {
        // Variables globales
        static SocketIO client;
        readonly User user;
        string idRoom;

        Image imgPlayer1 = Properties.Resources.cross;
        Image imgPlayer2 = Properties.Resources.circle;

        public frmGame(User u, string id)
        {
            InitializeComponent();

            user = u;
            idRoom = id;

            // Connection avec le serveur socket IO
            client = new SocketIO("http://85.6.250.101:5554/", new SocketIOOptions
            {
                Query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token", user.Token),
                }
            });
        }

        private async void frmGame_Load(object sender, EventArgs e)
        {
            await SocketManager();
        }

        public async void Play(object sender, EventArgs e)
        {
            PictureBox clickedBox = sender as PictureBox;

            await client.EmitAsync("play", clickedBox.Tag.ToString());

            clickedBox.Enabled = false;
        }

        private async void btnMenu_Click(object sender, EventArgs e)
        {
            // Quitte le salon
            await client.EmitAsync("leaveRoom");

            // Retour au menu
            this.Hide();
            frmMenu partie = new frmMenu(user);
            partie.ShowDialog();
            this.Close();
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            // Rejouer une partie
        }

        private void pibBox_Click(object sender, EventArgs e)
        {
            Play(sender, e);
        }

        // Socket IO - Communication avec le serveur
        private async Task SocketManager()
        {
            // Récupération de la liste des joueurs
            client.On("playerList", response =>
            {
                string json = response.GetValue().GetRawText();
                var playerList = JsonConvert.DeserializeObject<dynamic>(json);

                ShowPlayers((string)playerList["player1"], (string)playerList["player2"]);
            });

            // Récupère qui doit jouer
            client.On("isPlayer1Turn", response =>
            {
                lblPlayer1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
                lblPlayer2.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

                string json = response.GetValue().GetRawText();
                var isPlayer1Turn = JsonConvert.DeserializeObject<dynamic>(json);

                if (isPlayer1Turn)
                {
                    lblPlayer1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }
                else
                {
                    lblPlayer2.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                }

                HideError();
            });

            // Récupération de l'état de la partie
            client.On("gridState", response =>
            {
                string json = response.GetValue().GetRawText();
                var grid = JsonConvert.DeserializeObject<dynamic>(json);

                // Affichage de la grille de jeu
                foreach (PictureBox box in this.Controls.OfType<PictureBox>())
                {
                    if (box.Tag != null)
                    {
                        for (int i = 0; i < grid.Count; i++)
                        {
                            for (int j = 0; j < grid[i].Count; j++)
                            {

                                switch ((string)grid[i][j])
                                {
                                    case "P1":
                                        if (box.Tag.ToString() == i + ";" + j)
                                        {
                                            box.Image = imgPlayer1;
                                        }
                                        break;
                                    case "P2":
                                        if (box.Tag.ToString() == i + ";" + j)
                                        {
                                            box.Image = imgPlayer2;
                                        }
                                        break;
                                    default:
                                        if (box.Tag.ToString() == i + ";" + j)
                                        {
                                            box.Image = null;
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            });

            // Fin de partie
            client.On("gameEnded", response =>
            {
                string json = response.GetValue().GetRawText();
                var result = JsonConvert.DeserializeObject<dynamic>(json);

                ShowResult((string)result["p1"], (string)result["p2"]);
            });

            // Gérer les erreurs
            client.On("exception", response =>
            {
                string json = response.GetValue().GetRawText();
                var msg = JsonConvert.DeserializeObject<dynamic>(json);

                string errorMsg = msg["errorMessage"];

                ShowError(errorMsg);
            });

            // Vérification de la validité du token
            client.On("expiredToken", response =>
            {
                Console.WriteLine("Token expiré");

                // Déconnection
                Disconnect();
            });

            await client.ConnectAsync();

            Console.ReadLine();
        }

        /// <summary>
        /// Redirection vers le menu
        /// </summary>
        private void Disconnect()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { Disconnect(); }));
            }
            else
            {
                frmConnection connection = new frmConnection();
                this.Hide();
                connection.ShowDialog();
                this.Close();
            }
        }

        /// <summary>
        /// Affichage des résultats
        /// </summary>
        private void ShowResult(string resultP1, string resultP2)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { ShowResult(resultP1, resultP2); }));
            }
            else
            {
                lblResult1.Visible = true;
                lblResult2.Visible = true;
                btnMenu.Visible = true;
                btnReplay.Visible = true;

                lblResult1.Text = resultP1;
                lblResult2.Text = resultP2;
            }
        }

        /// <summary>
        /// Cache les erreurs
        /// </summary>
        private void HideError()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { HideError(); }));
            }
            else
            {
                lblError.Visible = false;
            }
        }

        /// <summary>
        /// Affichage des erreurs
        /// </summary>
        /// <param name="errorMsg">Message d'erreur</param>
        private void ShowError(string errorMsg)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { ShowError(errorMsg); }));
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = errorMsg;
            }
        }

        /// <summary>
        /// Affichage des joueurs
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        private void ShowPlayers(string player1, string player2)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { ShowPlayers(player1, player2); }));
            }

            lblPlayer1.Text = "Joueur 1: " + player1;
            lblPlayer2.Text = "Joueur 2: " + player2;
        }
    }
}
