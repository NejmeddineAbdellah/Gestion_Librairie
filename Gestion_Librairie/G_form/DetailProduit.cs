using Gestion_Librairie.Connection;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Librairie.G_form
{
    public partial class DetailProduit : Form
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        DataTable dt;
        Byte[] img;
        private int id_prod;

        public DetailProduit(int id_produit)
        {
            InitializeComponent();

            id_prod = id_produit;
            

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailProduit_Load(object sender, EventArgs e)
        {
            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from produit where id = " + id_prod + ";", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);

            lb_nom.Text = dt.Rows[0][1].ToString();
            lb_ref.Text = dt.Rows[0][2].ToString();
            lb_qte.Text = dt.Rows[0][3].ToString();
            lb_prix.Text = dt.Rows[0][4].ToString();
            lb_cat.Text = dt.Rows[0][5].ToString();
            lb_desc.Text = dt.Rows[0][6].ToString();

            byte[] img = (byte[])dt.Rows[0][7];
            MemoryStream ms = new MemoryStream(img);
            guna2PictureBox1.Image = Image.FromStream(ms);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
