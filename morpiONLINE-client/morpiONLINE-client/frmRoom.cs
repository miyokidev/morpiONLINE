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
        static SocketIO client;
        readonly User user;
        string idRoom;

        public frmRoom(User u, string id)
        {
            InitializeComponent();
            user = u;
            idRoom = id;

            Console.WriteLine("Code du salon : " + id);

            lblIdRoom.Text = idRoom;
            lblPlayer1.Text = user.Username;
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
            var client = new SocketIO("http://85.6.250.101:5554/");

            Console.WriteLine("Test");

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

        private void btnLeave_Click(object sender, EventArgs e)
        {
            // Retour au menu
            this.Hide();
            frmMenu partie = new frmMenu(user);
            partie.ShowDialog();
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // Copier le code du salon
            Clipboard.SetText(idRoom);
            MessageBox.Show("Le code a été copié dans votre presse-papiers", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}