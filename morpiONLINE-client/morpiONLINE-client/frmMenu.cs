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
        User user;

        public frmMenu(User u)
        {
            InitializeComponent();
            user = u;

            // Connection avec le serveur socket IO

            var options = new SocketIOOptions();
            options.Auth = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("token", user.Token),
            };


            client = new SocketIO("http://10.5.47.32:7000/", options);

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

            client.On("id", response =>
            {
                Console.WriteLine(response);
            });

            /*
            // Créer un salon
            this.Hide();
            frmRoom salon = new frmRoom();
            salon.ShowDialog();
            this.Close();
            */
        }

        // Socket IO - Communication avec le serveur
        private static async Task SocketManager()
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
            client.On("expiredToken", response => {
                Console.WriteLine("Token expiré");

                /*
                // Déconnection
                this.Hide();
                frmConnection connection = new frmConnection();
                connection.ShowDialog();
                this.Close();
                */

            });
            
            Console.ReadLine();
        }


    }
}
