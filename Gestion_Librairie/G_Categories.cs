using Gestion_Librairie.Classes;
using Gestion_Librairie.Connection;
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
            /*   categorieforme gf = new categorieforme();
               gf.Show();
            */


            if (guna2TextBox3.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Categorie categorie = new Categorie(guna2TextBox2.Text, guna2TextBox3.Text);

                    guna2TextBox2.Clear();
                    guna2TextBox3.Clear();

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO categorie (code,libelle) VALUES(@code,@libelle)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@code", categorie.Code);
                    cmd.Parameters.AddWithValue("@libelle", categorie.Libelle);
                    cmd.ExecuteNonQuery();
                    GetCategorieList();
                    cnx.cnxClose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void G_Categories_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "" || guna2TextBox3.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int id_categorie = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("update categorie set code=@code ,libelle =@libelle where id = @id", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@code", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@libelle", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@id", id_categorie);
                    cmd.ExecuteNonQuery();
                    GetCategorieList();
                    cnx.cnxClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            string id_categorie = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);


            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer cette categorie", "Supprimer une categorie", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM categorie WHERE id = '" + id_categorie + "'", cnx.connMaster);
                cmd.ExecuteNonQuery();
                GetCategorieList();
                cnx.cnxClose();

            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string id_categorie = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            guna2TextBox2.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            guna2TextBox3.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[2].Value);

        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from categorie where libelle like '%"+ guna2TextBox1.Text+"%';", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }
    }
}
