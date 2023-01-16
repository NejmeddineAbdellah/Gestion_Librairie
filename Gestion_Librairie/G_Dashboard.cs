using Gestion_Librairie.Connection;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class G_Dashboard : UserControl
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;

        public G_Dashboard()
        {
            InitializeComponent();
        }

        private void G_Dashboard_Load(object sender, System.EventArgs e)
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select count(*) from categorie", cnx.connMaster);
            Int32 nb_categorie =Convert.ToInt32(Command.ExecuteScalar());
            cnx.cnxClose();

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command2 = new MySqlCommand("select count(*) from user", cnx.connMaster);
            Int32 nb_users = Convert.ToInt32(Command2.ExecuteScalar());
            cnx.cnxClose();

            guna2HtmlLabel7.Text= nb_categorie.ToString();
            guna2HtmlLabel6.Text= nb_users.ToString();

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand cmd = new MySqlCommand("select c.id, p.nom ,c.quantite from command c, produit p where c.produit_id=p.id order by c.quantite limit 5", cnx.connMaster);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.chart1.Series["Produits"].Points.AddXY(dr["nom"].ToString(), Convert.ToInt32(dr["quantite"]));

            }

            cnx.cnxClose();


            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand cmd1 = new MySqlCommand("select nom ,quantite from produit order by quantite limit 5", cnx.connMaster);
            MySqlDataReader dr2 = cmd1.ExecuteReader();
            while (dr2.Read())
            {
                this.chart2.Series["Produits"].Points.AddXY(dr2["nom"].ToString(), Convert.ToInt32(dr2["quantite"]));

            }

            cnx.cnxClose();

        }
    }
}
