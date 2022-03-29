using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morpiONLINE_client
{    
    public class User
    {
        string _token;
        string _username;

        public string Token { get => _token; set => _token = value; }
        public string Username { get => _username; set => _username = value; }

        public User(string username, string token)
        {
            this.Username = username;
            this.Token = token;
        }
    }
}
