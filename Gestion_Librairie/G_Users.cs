using Gestion_Librairie.Classes;
using Gestion_Librairie.Connection;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class G_Users : UserControl
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;

        public G_Users()
        {
            InitializeComponent();
            GetUsersList();
        }

        private void GetUsersList()
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from user", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "" || txt_username.Text == "" || txt_email.Text == "" || txt_telephone.Text == ""
                || txt_prenom.Text == "" || txt_nom.Text == "" || cmb_role.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Users user = new Users(txt_username.Text, txt_password.Text, txt_email.Text, txt_telephone.Text, cmb_role.Text, txt_nom.Text, txt_prenom.Text);
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_nom.Clear();
                    txt_prenom.Clear();
                    txt_telephone.Clear();
                    txt_email.Clear();

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO user (username,password,role,nom,prenom,email,telephone) VALUES(@username,@password,@role,@nom,@prenom,@email,@telephone)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@nom", user.Nom);
                    cmd.Parameters.AddWithValue("@prenom", user.Password);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@telephone", user.Telephone);
                    cmd.ExecuteNonQuery();
                    GetUsersList();
                    cnx.cnxClose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
            txt_username.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            txt_password.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[2].Value);
            cmb_role.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[3].Value);
            txt_nom.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[4].Value);
            txt_prenom.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[5].Value);
            txt_email.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[6].Value);
            txt_telephone.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[7].Value);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id_user = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);


            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer cet utilisateur", "Supprimer un utilisateur", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM user WHERE id = '" + id_user + "'", cnx.connMaster);
                cmd.ExecuteNonQuery();
                GetUsersList();
                cnx.cnxClose();

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "" || txt_username.Text == "" || txt_email.Text == "" || txt_telephone.Text == ""
                || txt_prenom.Text == "" || txt_nom.Text == "" || cmb_role.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int id_user = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("update user set username=@username ,password =@password,role =@role ,nom =@nom,prenom =@prenom,email =@email,telephone =@telephone where id = @id", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@username", txt_username.Text);
                    cmd.Parameters.AddWithValue("@password", txt_password.Text);
                    cmd.Parameters.AddWithValue("@role", cmb_role.Text);
                    cmd.Parameters.AddWithValue("@nom", txt_nom.Text);
                    cmd.Parameters.AddWithValue("@prenom", txt_prenom.Text);
                    cmd.Parameters.AddWithValue("@email", txt_email.Text);
                    cmd.Parameters.AddWithValue("@telephone", txt_telephone.Text);
                    cmd.Parameters.AddWithValue("@id", id_user);
                    cmd.ExecuteNonQuery();
                    GetUsersList();
                    cnx.cnxClose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from user where nom like '%" + txt_nom.Text + "%';", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();
        }
    }
}
