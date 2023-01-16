using System;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class Dashboard : Form
    {

        public static string userRole;
        public static string nomu;

        public Dashboard(string role,string nom)
        {
            InitializeComponent();


            g_Dashboard1.Show();
            g_Categories2.Hide();
            g_Users1.Hide();
            g_Produits1.Hide();
            g_Commands1.Hide();

            userRole = role;
            lb_nom.Text = nom;
            nomu=nom ;

            if (userRole.Equals("Manager"))
            {

                btn_nav_user.Enabled = true;
            }
            else
            {
                btn_nav_user.Enabled = false;
                btn_nav_user.Visible = false;
            }
            //  guna2HtmlLabel1.Text= role;
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }


        private void btn_nav_user_Click(object sender, EventArgs e)
        {
            g_Users1.Show();
            g_Categories2.Hide();
            g_Dashboard1.Hide();
            g_Produits1.Hide();
            g_Commands1.Hide();

        }

        private void btn_nav_produit_Click(object sender, EventArgs e)
        {
            g_Dashboard1.Hide();
            g_Categories2.Hide();
            g_Users1.Hide();
            g_Produits1.Show();
            g_Commands1.Hide();

        }

        private void btn_nav_command_Click(object sender, EventArgs e)
        {

            g_Dashboard1.Hide();
            g_Categories2.Hide();
            g_Users1.Hide();
            g_Produits1.Hide();
            g_Commands1.nom_user = nomu;
            g_Commands1.Show();
           
            
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            g_Dashboard1.Show();
            g_Categories2.Hide();
            g_Users1.Hide();
            g_Produits1.Hide();
            g_Commands1.Hide();
        }

        private void btn_nav_categorie_Click(object sender, EventArgs e)
        {
            g_Categories2.Show();
            g_Dashboard1.Hide();
            g_Users1.Hide();
            g_Produits1.Hide();
            g_Commands1.Hide();

        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {

            g_Dashboard1.Show();
            g_Categories2.Hide();
            g_Users1.Hide();
            g_Produits1.Hide();
            g_Commands1.Hide();
        }
    }
}
