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
            JObject o = new JObject();
            o["id"] = tbxRoomCode.Text;

            await client.EmitAsync("joinRoom", o);

            /*
            // Rejoindre un salon
            this.Hide();
            frmRoom salon = new frmRoom();
            salon.ShowDialog();
            this.Close();
            */
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            await client.EmitAsync("createRoom");

            string id = "";

            client.On("id", response =>
            {
                string json = response.GetValue().GetRawText();
                var room = JsonConvert.DeserializeObject<dynamic>(json);

                id = room["id"];

                // Console.WriteLine(id);

                this.Hide(); // Utliser HideForm() ? (Ne fonctionne pas)
                frmRoom salon = new frmRoom(user, id);
                salon.ShowDialog();
                this.Close(); // Utiliser CloseForm() ? (Fonctionne)
            });

            // Créer un salon
            /* Cette strat pue sent le caca mais fonctionne
            while (id == "")
            {
                Console.WriteLine("caca");
            }

            Lancer la nouvelle forme ici
            */            

        }

        private void HideForm()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { HideForm(); }));
            }
            else
            {
                Hide();
            }
        }

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => { CloseForm(); }));
            }
            else
            {
                Close();
            }
        }


        // Socket IO - Communication avec le serveur
        private async Task SocketManager()
        {
            Console.WriteLine("Test");

            client.On("working", response =>
            {
                Console.WriteLine(response);
            });


            client.OnConnected += async (sender, e) =>
            {
                await client.EmitAsync("testC");
                Console.WriteLine("Connected");

            };

            await client.ConnectAsync();

            // Vérification de la validité du token
            client.On("expiredToken", response =>
            {
                Console.WriteLine("Token expiré");

                // Déconnection
                this.Hide();
                frmConnection connection = new frmConnection();
                connection.ShowDialog();
                this.Close();

            });

            Console.ReadLine();
        }


    }
}
