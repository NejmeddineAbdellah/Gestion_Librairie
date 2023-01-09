using System;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class Dashboard : Form
    {


        public Dashboard()
        {
            InitializeComponent();

            g_Dashboard3.Show();
            g_Categories3.Hide();
            g_Produits3.Hide();
            g_Commands3.Hide();
            g_Users3.Hide();


        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_nav_user_Click(object sender, EventArgs e)
        {
            g_Dashboard3.Hide();
            g_Categories3.Hide();
            g_Produits3.Hide();
            g_Commands3.Hide();
            g_Users3.Show();


        }

        private void btn_nav_produit_Click(object sender, EventArgs e)
        {
            g_Dashboard3.Hide();
            g_Categories3.Hide();
            g_Produits3.Show();
            g_Commands3.Hide();
            g_Users3.Hide();
        }

        private void btn_nav_categorie_Click(object sender, EventArgs e)
        {
            g_Dashboard3.Hide();
            g_Categories3.Show();
            g_Produits3.Hide();
            g_Commands3.Hide();
            g_Users3.Hide();
        }

        private void btn_nav_command_Click(object sender, EventArgs e)
        {
            g_Dashboard3.Hide();
            g_Categories3.Hide();
            g_Produits3.Hide();
            g_Commands3.Show();
            g_Users3.Hide();
        }

        private void g_Users2_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            g_Dashboard3.Show();
            g_Categories3.Hide();
            g_Produits3.Hide();
            g_Commands3.Hide();
            g_Users3.Hide();
        }

        private void g_Users3_Load(object sender, EventArgs e)
        {

        }
    }
}
