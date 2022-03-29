using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace morpiONLINE_client
{
    public partial class frmConnection : Form
    {

        const string API = "http://85.6.250.101:5555/";
        
        public frmConnection()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            // Connexion           
            string user = tbxUser.Text;
            string password = tbxPassword.Text;
            string param = "signin";

            Send(user, password, param);
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {

            // Inscription
            string user = tbxNewUser.Text;
            string password = tbxNewPassword.Text;
            string param = "signup";

            // Vérification des deux mots de passe
            bool areTheSame = false;
            if (tbxNewPassword.Text == tbxConfirmPassword.Text)
            {
                areTheSame = true;
            }

            // Si les deux mots de passe sont identiques
            if (areTheSame)
            {
                Send(user, password, param);
            }
            else
            {
                // Sinon, affichage de l'erreur
                lblError.Visible = true;
                lblError.Text = "Mots de passe non similaires";
                tbxConfirmPassword.Text = "";
            }
        }

        /// <summary>
        /// Requête vers l'API
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="httpWebRequest"></param>
        public void Send(string user, string password, string param)
        {
            string token = "";
            lblSuccess.Visible = false;
            lblError.Visible = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(API + param);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                // Envoi des informations en JSON
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"username\":\"" + user + "\"," +
                                  "\"password\":\"" + password + "\"}";

                    streamWriter.Write(json);
                }

                // Récupération de la réponse
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);

                    dynamic obj = JsonConvert.DeserializeObject(result);

                    token = obj.token;
                }

                // Si aucune erreur n'a été rencontrée
                switch (param)
                {
                    case "signin":
                        User usr = new User(user, token);

                        // Redirection vers le menu principal
                        this.Hide();
                        frmMenu menu = new frmMenu(usr);
                        menu.ShowDialog();
                        this.Close();
                        break;
                    case "signup":
                        // Affiche que le compte a été crée avec succès
                        lblSuccess.Visible = true;
                        tbxNewUser.Text = "";
                        tbxNewPassword.Text = "";
                        tbxConfirmPassword.Text = "";
                        break;
                }

            }
            catch (WebException error)
            {
                using (WebResponse response = error.Response)
                {
                    // Affichage du message d'erreur
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        Console.WriteLine(text);
                        dynamic obj = JsonConvert.DeserializeObject(text);

                        lblError.Visible = true;
                        lblError.Text = obj.message[0];
                    }
                }
            }
        }        
    }
}