using Gestion_Librairie.Classes;
using Gestion_Librairie.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class G_Commands : UserControl
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;
        private static int id_produit;
        private static int id_command;
        private static string nom_u;

        public string nom_user
        {
            get{return nom_u; }
            set{if (value != nom_u) { nom_u = value;}}
        }


        public G_Commands()
        {
            InitializeComponent();
            GetCommandsList();
            GetProduitsList();
        }
        private void GetCommandsList()
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from command", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }
        private void GetProduitsList()
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from produit", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            dt = dt.DefaultView.ToTable(true, "id", "nom", "reference", "quantite", "prix", "categorie", "description");
            guna2DataGridView2.DataSource = dt;
            cnx.cnxClose();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int id_produit = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);

                    cnx.connexion();
                    cnx.cnxOpen();

                    MySqlCommand cmd = new MySqlCommand("update command set client_email=@client_email ,produit_id =@produit_id,date_cmd =@date_cmd ,quantite =@quantite,quantite =@quantite,email_user =@email_user where id = @id", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@client_email", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@produit_id", id_produit);
                    cmd.Parameters.AddWithValue("@date_cmd", guna2DateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@quantite", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@email_user", "user@d.com");

                    cmd.Parameters.AddWithValue("@id", id_produit);
                    cmd.ExecuteNonQuery();
                    GetProduitsList();
                    GetCommandsList();
                    cnx.cnxClose();

                    guna2TextBox2.Clear();
                    guna2TextBox2.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            double prix = 0;

            if (guna2TextBox2.Text == "" || guna2TextBox1.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand Command = new MySqlCommand("select * from produit where id ="+ id_produit, cnx.connMaster);
                    MySqlDataReader dr = Command.ExecuteReader();
                    while (dr.Read())
                    {

                        prix = Convert.ToDouble(dr["prix"]);


                    }
                    cnx.cnxClose();

                    double total_prix = prix * Convert.ToDouble(guna2TextBox2.Text);

                    Commands command = new Commands(guna2TextBox1.Text, id_produit, guna2DateTimePicker1.Value, Convert.ToInt16(guna2TextBox2.Text), Dashboard.nomu.ToString(), total_prix);

                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();

                    cnx.connexion();
                    cnx.cnxOpen();

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO command (client_email,produit_id,date_cmd,quantite,email_user,total_prix) VALUES (@client_email,@produit_id,@date_cmd,@quantite,@email_user,@total_prix)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@client_email", command.Client_email);
                    cmd.Parameters.AddWithValue("@produit_id", command.Produit_id);
                    cmd.Parameters.AddWithValue("@date_cmd", command.Date_command);
                    cmd.Parameters.AddWithValue("@quantite", command.Quantite);
                    cmd.Parameters.AddWithValue("@email_user", command.User_email);
                    cmd.Parameters.AddWithValue("@total_prix", command.Total_prix);
                    cmd.ExecuteNonQuery();
                    cnx.cnxClose();

                    cnx.cnxOpen();
                    MySqlCommand cmd2 = new MySqlCommand("update produit set quantite = quantite - " + command.Quantite + " where id = @id", cnx.connMaster);
                    cmd2.Parameters.AddWithValue("@id", id_produit);
                    cmd2.ExecuteNonQuery();
                    cnx.cnxClose();
                    GetCommandsList();
                    GetProduitsList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void G_Commands_Load(object sender, EventArgs e)
        {


        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_produit = Convert.ToInt32(guna2DataGridView2.SelectedRows[0].Cells[0].Value);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_command = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id_command = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);


            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer cette command", "Supprimer une command", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM command WHERE id = '" + id_command + "'", cnx.connMaster);
                cmd.ExecuteNonQuery();
                GetProduitsList();
                GetCommandsList();
                cnx.cnxClose();

                guna2TextBox1.Clear();
                guna2TextBox2.Clear();

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            double total_prix = 0;
            int total_produit = 0;


            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from command", cnx.connMaster);
            MySqlDataReader dr = Command.ExecuteReader();
            while (dr.Read())
            {

                total_produit += Convert.ToInt32(dr["quantite"]);
                total_prix += Convert.ToDouble(dr["total_prix"]);


            }

            cnx.cnxClose();
            
        }
    }
}
