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
        // Serveur de Brian http://10.5.47.37:6969/
        // Serveur de Leo http://10.5.47.32:6969/


        const string server = "http://10.5.47.43:7000/";
        public frmMenu()
        {
            InitializeComponent();           
        }

        private async void frmMenu_Load(object sender, EventArgs e)
        {
            await SocketManager();
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

        // Socket IO - Communication avec le serveur
        private static async Task SocketManager()
        {
            var client = new SocketIO("http://10.5.47.43:7000/");

            Console.WriteLine("Test");

            client.On("hi", response =>
            {
                // You can print the returned data first to decide what to do next.
                // output: ["hi client"]
                Console.WriteLine(response);

                string text = response.GetValue<string>();

                // The socket.io server code looks like this:
                // socket.emit('hi', 'hi client');
            });

            client.OnConnected += async (sender, e) =>
            {
                // Emit a string
                await client.EmitAsync("testC");
                Console.WriteLine("Connected");

            };
            await client.ConnectAsync();

            Console.ReadLine();
        }
    }
}
