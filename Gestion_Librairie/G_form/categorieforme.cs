using Gestion_Librairie.Classes;
using Gestion_Librairie.Connection;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie.G_form
{
    public partial class categorieforme : Form
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;

        public categorieforme()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void guna2Button1_Click(object sender, System.EventArgs e)
        {

            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Categorie categorie = new Categorie(guna2TextBox1.Text, guna2TextBox2.Text);

                    guna2TextBox2.Clear();
                    guna2TextBox1.Clear();

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO categorie (code,libelle)" + "VALUES(@code,@libelle)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@cin", categorie.Code);
                    cmd.Parameters.AddWithValue("@nom", categorie.Libelle);

                    cmd.ExecuteNonQuery();
                    cnx.cnxClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
