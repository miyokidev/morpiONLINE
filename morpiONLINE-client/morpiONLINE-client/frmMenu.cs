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
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using SocketIOClient;

namespace morpiONLINE_client
{
    public partial class frmMenu : Form
    {
        // Variables globales
        static SocketIO client;
        readonly User user;

        public frmMenu(User u)
        {
            InitializeComponent();
            user = u;

            // Connection avec le serveur socket IO
            client = new SocketIO("http://85.6.250.101:5554/", new SocketIOOptions
            {
                Query = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("token", user.Token),
                }
            });

            Console.WriteLine(user.Token);
        }

        private async void frmMenu_Load(object sender, EventArgs e)
        {
            await SocketManager();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            // Demande de rejoindre un salon
            await client.EmitAsync("joinRoom", new { id = tbxRoomCode.Text });

            // Si le serveur accèpte la demande, redirection vers le salon
            client.On("joinedRoom", response =>
            {
                string json = response.GetValue().GetRawText();
                var game = JsonConvert.DeserializeObject<dynamic>(json);

                string id = game["id"];

                NavToRoom(id);
            });                
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            // Création du salon
            await client.EmitAsync("createRoom");

            // Récupérationde du code du salon
            client.On("id", response =>
            {
                string json = response.GetValue().GetRawText();
                var room = JsonConvert.DeserializeObject<dynamic>(json);

                string id = room["id"];
                NavToRoom(id);
            });              
        }

        /// <summary>
        /// Redirection vers un salon
        /// </summary>
        /// <param name="id">Code du salon</param>
        private void NavToRoom(string id)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { NavToRoom(id); }));
            }
            else
            {
                frmRoom salon = new frmRoom(user, id);
                this.Hide();
                salon.ShowDialog();
                this.Close();
            }
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
        /// Affichage du message d'erreur
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

        // Socket IO - Communication avec le serveur
        private async Task SocketManager()
        {
            await client.ConnectAsync();

            // Vérification de la validité du token
            client.On("expiredToken", response =>
            {
                Console.WriteLine("Token expiré");

                // Déconnection
                Disconnect();
            });

            // Gérer les exceptions
            client.On("exception", response =>
            {
                string json = response.GetValue().GetRawText();
                var msg = JsonConvert.DeserializeObject<dynamic>(json);

                string errorMsg = msg["errorMessage"];

                ShowError(errorMsg);
            });

            Console.ReadLine();
        }
    }
}
