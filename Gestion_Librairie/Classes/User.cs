using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Librairie.Classes
{
    internal class User
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private string telephone;
        private string role;
        private string nom;
        private string prenom;

        public User(string username, string password, string email, string telephone, string role, string nom, string prenom)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.telephone = telephone;
            this.role = role;
            this.nom = nom;
            this.prenom = prenom;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Role { get => role; set => role = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
    }
}
