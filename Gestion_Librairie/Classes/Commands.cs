using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Librairie.Classes
{
    internal class Commands
    {
        private int id;
        private string client_email;
        private string ref_produit;
        private string date_command;
        private int quantite;
        private string user_email;

        public Commands(string client_email, string ref_produit, string date_command, int quantite, string user_email)
        {
            this.Client_email = client_email;
            this.Ref_produit = ref_produit;
            this.Date_command = date_command;
            this.Quantite = quantite;
            this.User_email = user_email;
        }

        public int Id { get => id; set => id = value; }
        public string Client_email { get => client_email; set => client_email = value; }
        public string Ref_produit { get => ref_produit; set => ref_produit = value; }
        public string Date_command { get => date_command; set => date_command = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public string User_email { get => user_email; set => user_email = value; }
    }
}
    