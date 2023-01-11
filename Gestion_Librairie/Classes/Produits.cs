using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Librairie.Classes
{
    internal class Produits
    {
        private int id;
        private string nom;
        private string references;
        private int stock;
        private double prix;
        private string categorie;
        private string description;
        Byte[] image;

        public Produits(string nom, string references, int stock, double prix, string categorie, string description, byte[] image)
        {
            this.Nom = nom;
            this.References = references;
            this.Stock = stock;
            this.Prix = prix;
            this.Categorie = categorie;
            this.Description = description;
            this.Image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string References { get => references; set => references = value; }
        public int Stock { get => stock; set => stock = value; }
        public double Prix { get => prix; set => prix = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Description { get => description; set => description = value; }
        public byte[] Image { get => image; set => image = value; }
    }
}
