using Gestion_Librairie.Classes;
using Gestion_Librairie.Connection;
using Gestion_Librairie.G_form;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gestion_Librairie
{
    public partial class G_Produits : UserControl
    {
        Connexion cnx = new Connexion();
        MySqlDataAdapter da;
        MySqlDataAdapter dap;
        DataTable dt;
        DataTable dta;
        Byte[] img;

        private static int id_produit;


        public G_Produits()
        {
            InitializeComponent();
            GetProduitsList();
            GetCategorieList();
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
            dt = dt.DefaultView.ToTable(true,"id", "nom", "reference", "quantite", "prix", "categorie", "description");
            guna2DataGridView1.DataSource = dt;
            cnx.cnxClose();

        }
        private void GetCategorieList()
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from categorie", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            dta = new DataTable();
            dap = new MySqlDataAdapter(Command);
            da.Fill(dt);
            dap.Fill(dta);
            cmb_categorie.DataSource = dt;
            cmb_categorie.DisplayMember = "libelle";
            cmb_categorie_refresh.DataSource = dta;
            cmb_categorie_refresh.DisplayMember = "libelle";
            cnx.cnxClose();

        }
        public void GetProduitByCategorie(string libelle)
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from produit where categorie like '" + libelle + "';", cnx.connMaster);
            Command.ExecuteNonQuery();
            dta = new DataTable();
            dap = new MySqlDataAdapter(Command);
            dap.Fill(dta);
            dta = dta.DefaultView.ToTable(true, "id", "nom", "reference", "quantite", "prix", "categorie", "description");
            guna2DataGridView1.DataSource = dta;

            cnx.cnxClose();

        }

        public void ClearData()
        {
            txt_reference.Clear();
            txt_reference.PlaceholderText = "Reference du produit";
            txt_nom.Clear();
            txt_nom.PlaceholderText = "Nom du produit";
            txt_description.Clear();
            txt_prix.Clear();
            txt_prix.PlaceholderText = "Prix";
            txt_stock.Clear();
            txt_stock.PlaceholderText = "Quantite";
            txt_recherche.Clear();
            txt_recherche.PlaceholderText = "Reference";
            guna2PictureBox1.Image = null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (txt_reference.Text == "" || txt_nom.Text == "" || txt_description.Text == "" || txt_stock.Text == "" || txt_prix.Text == "" || cmb_categorie.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    Byte[] image = img;
                    Produits produits = new Produits(txt_nom.Text, txt_reference.Text, Convert.ToInt32(txt_stock.Text), Convert.ToDouble(txt_prix.Text), cmb_categorie.Text, txt_description.Text, image);

                    txt_reference.Clear();
                    txt_nom.Clear();
                    txt_description.Clear();
                    txt_stock.Clear();
                    txt_prix.Clear();

                    cnx.connexion();
                    cnx.cnxOpen();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO produit (nom,reference,quantite,prix,categorie,description,image) VALUES(@nom,@reference,@quantite,@Prix,@categorie,@description,@image)", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@nom", produits.Nom);
                    cmd.Parameters.AddWithValue("@reference", produits.References);
                    cmd.Parameters.AddWithValue("@quantite", Convert.ToInt32(produits.Stock));
                    cmd.Parameters.AddWithValue("@prix", Convert.ToDouble(produits.Prix));
                    cmd.Parameters.AddWithValue("@categorie", produits.Categorie);
                    cmd.Parameters.AddWithValue("@description", produits.Description);
                    cmd.Parameters.AddWithValue("@image", produits.Image);

                    cmd.ExecuteNonQuery();
                    GetProduitsList();
                    cnx.cnxClose();

                    ClearData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int id_produit = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);


            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce produits", "Supprimer un produit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                cnx.connexion();
                cnx.cnxOpen();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM produit WHERE id = '" + id_produit + "'", cnx.connMaster);
                cmd.ExecuteNonQuery();
                GetProduitsList();
                GetCategorieList();
                cnx.cnxClose();

                ClearData();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (txt_reference.Text == "" || txt_nom.Text == "" || cmb_categorie.Text == "" || txt_description.Text == ""
               || txt_stock.Text == "" || txt_prix.Text == "")
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
                    MySqlCommand cmd = new MySqlCommand("update produit set reference=@reference ,nom =@nom,categorie =@categorie ,description =@description,quantite =@quantite,prix =@prix where id = @id", cnx.connMaster);
                    cmd.Parameters.AddWithValue("@reference", txt_reference.Text);
                    cmd.Parameters.AddWithValue("@nom", txt_nom.Text);
                    cmd.Parameters.AddWithValue("@categorie", cmb_categorie.Text);
                    cmd.Parameters.AddWithValue("@description", txt_description.Text);
                    cmd.Parameters.AddWithValue("@quantite", Convert.ToInt32(txt_stock.Text));
                    cmd.Parameters.AddWithValue("@prix", Convert.ToDouble(txt_prix.Text));

                    cmd.Parameters.AddWithValue("@id", id_produit);
                    cmd.ExecuteNonQuery();
                    GetProduitsList();
                    GetCategorieList();
                    cnx.cnxClose();
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id_produit = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
            txt_nom.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            txt_reference.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[2].Value);
            txt_stock.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[3].Value);
            txt_prix.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[4].Value);
            cmb_categorie.SelectedItem = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[5].Value);
            txt_description.Text = Convert.ToString(guna2DataGridView1.SelectedRows[0].Cells[6].Value);


            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from produit where id =" + id_produit, cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            dt = dt.DefaultView.ToTable(true, "image");


            byte[] img = (byte[])dt.Rows[0][0];
            MemoryStream ms = new MemoryStream(img);
            guna2PictureBox1.Image = Image.FromStream(ms);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            cnx.cnxClose();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            GetProduitsList();
            ClearData();

        }
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

            cnx.connexion();
            cnx.cnxOpen();
            MySqlCommand Command = new MySqlCommand("select * from produit where nom like '%" + txt_recherche.Text + "%';", cnx.connMaster);
            Command.ExecuteNonQuery();
            dt = new DataTable();
            da = new MySqlDataAdapter(Command);
            da.Fill(dt);
            guna2DataGridView1.DataSource = dt;

            cnx.cnxClose();
            ClearData();
        }

        private void G_Produits_Load(object sender, EventArgs e)
        {
            GetProduitsList();
            GetCategorieList();
        }

        private void cmb_categorie_refresh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void cmb_categorie_refresh_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetProduitByCategorie(cmb_categorie_refresh.Text);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            System.Drawing.Image image;

            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "All Files |*.*|JPG|*.jpg|PNG|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    guna2PictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName);
                    guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    image = System.Drawing.Image.FromFile(ofd.FileName);
                    var ms = new MemoryStream();
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] i = ms.ToArray();
                    img = i;
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DetailProduit g = new DetailProduit(id_produit);
            g.ShowDialog();
        }

    }
}
