using System;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class Dashboard : Form
    {

        public static string userRole;

        public Dashboard(string role)
        {
            InitializeComponent();

            g_Categories1.Hide();
            userRole= role;

            if (userRole.Equals("Manager"))
            {
                btn_nav_user.Enabled = true;
            }else btn_nav_user.Enabled = false;
            //  guna2HtmlLabel1.Text= role;
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
 
        private void btn_nav_categorie_Click_1(object sender, EventArgs e)
        {
            g_Categories1.Show();
        }

        private void btn_nav_user_Click(object sender, EventArgs e)
        {

        }

        private void btn_nav_produit_Click(object sender, EventArgs e)
        {

        }

        private void btn_nav_command_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
