using System;

namespace Gestion_Librairie.Classes
{
    internal class Commands
    {
        private int id;
        private string client_email;
        private int produit_id;
        private DateTime date_command;
        private int quantite;
        private string user_email;

        public Commands(string client_email, int produit_id,DateTime date_command, int quantite, string user_email)
        {
            this.Client_email = client_email;
            this.Produit_id = produit_id;
            this.Date_command = date_command;
            this.Quantite = quantite;
            this.User_email = user_email;
        }

        public int Id { get => id; set => id = value; }
        public string Client_email { get => client_email; set => client_email = value; }
        public int Produit_id { get => produit_id; set => produit_id = value; }
        public DateTime Date_command { get => date_command; set => date_command = value; }
        public int Quantite { get => quantite; set => quantite = value; }
        public string User_email { get => user_email; set => user_email = value; }
    }
}
