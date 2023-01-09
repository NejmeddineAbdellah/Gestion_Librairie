namespace Gestion_Librairie.Classes
{
    internal class Categorie
    {
        private int id;
        private string code;
        private string libelle;

        public Categorie(string code, string libelle)
        {
            this.Code = code;
            this.Libelle = libelle;
        }

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Libelle { get => libelle; set => libelle = value; }
    }

}
