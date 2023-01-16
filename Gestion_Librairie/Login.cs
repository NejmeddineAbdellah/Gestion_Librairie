using Gestion_Librairie.Connection;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class Login : Form
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;

        public Login()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("SELECT * from user WHERE username = @username and password=@password", cnx.connMaster);
            Command.Parameters.AddWithValue("@username", txt_user.Text);
            Command.Parameters.AddWithValue("@password", txt_password.Text);
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);

            cnx.cnxClose();

            if (dt.Rows.Count == 1)
            {
                Dashboard dashboard = new Dashboard(dt.Rows[0]["role"].ToString(), dt.Rows[0]["nom"].ToString());
                dashboard.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }
    }
}
