using Gestion_Librairie.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class G_Produits : UserControl
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;

        public G_Produits()
        {
            InitializeComponent();
            GetProduitsList();
        }

        private void GetProduitsList()
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from produits", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
