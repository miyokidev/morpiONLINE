using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using SocketIOClient;

namespace morpiONLINE_client
{
    public partial class frmRoom : Form
    {
        // Variables globales
        static SocketIO client;
        readonly User user;
        string idRoom;

        public frmRoom(User u, string id)
        {
            InitializeComponent();
            user = u;
            idRoom = id;

            Console.WriteLine("Code du salon : " + idRoom);

            lblIdRoom.Text = idRoom;

            // Connection avec le serveur socket IO
            client = new SocketIO("http://85.6.250.101:5554/", new SocketIOOptions
            {
                Query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token", user.Token),
                }
            });
        }

        private async void frmRoom_Load(object sender, EventArgs e)
        {
            await SocketManager();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            // Demande au serveur de démarrer une partie
            await client.EmitAsync("startGame");                        
        }    

        private async void btnLeave_Click(object sender, EventArgs e)
        {
            // Quitte le salon
            await client.EmitAsync("leaveRoom");

            // Retour au menu
            this.Hide();
            frmMenu partie = new frmMenu(user);
            partie.ShowDialog();
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Copier le code du salon dans le presse-papiers
            Clipboard.SetText(idRoom);
            MessageBox.Show("Le code a été copié dans votre presse-papiers", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // Lorsque que le serveur lance la partie
            client.On("startedGame", response =>
            {
                string json = response.GetValue().GetRawText();
                var game = JsonConvert.DeserializeObject<dynamic>(json);

                string id = game["id"];

                StartGame(id);
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
        /// Démarrage de la partie
        /// </summary>
        /// <param name="id">Code du salon</param>
        private void StartGame(string id)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { StartGame(id); }));
            }
            else
            {
                // Démarrage de la partie
                this.Hide();
                frmGame partie = new frmGame(user, id);
                partie.ShowDialog();
                this.Close();
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
                Console.WriteLine("test");
                this.Invoke(new Action(() => { ShowPlayers(player1, player2); }));
            }

            lblPlayer1.Text = "Joueur 1: " + player1;
            lblPlayer2.Text = "Joueur 2: " + player2;
        }
    }
}