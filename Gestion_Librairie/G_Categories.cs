using Gestion_Librairie.Connection;
using Gestion_Librairie.G_form;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class G_Categories : UserControl
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;

        public G_Categories()
        {
            InitializeComponent();
            GetCategorieList();
        }


        private void GetCategorieList()
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from categorie", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            categorieforme gf = new categorieforme();
            gf.ShowDialog();

        }

        private void G_Categories_Load(object sender, EventArgs e)
        {
            GetCategorieList();
        }
    }
}
