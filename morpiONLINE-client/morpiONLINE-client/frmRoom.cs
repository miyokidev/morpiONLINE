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
        public frmRoom()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Démarrage de la partie
            this.Hide();
            frmGame partie = new frmGame();
            partie.ShowDialog();
            this.Close();
        }

        // Socket IO - Communication avec le serveur
        private static async Task SocketManager()
        {
            var client = new SocketIO("http://10.5.47.43:7000/");

            Console.WriteLine("Test");

            client.On("working", response =>
            {
                // You can print the returned data first to decide what to do next.
                // output: ["hi client"]
                Console.WriteLine(response);
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

        private async void frmRoom_Load(object sender, EventArgs e)
        {
            await SocketManager();
        }
    }
}
