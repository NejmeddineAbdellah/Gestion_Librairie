using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Librairie.Facture
{
    public partial class Facture : Form
    {
        public Facture()
        {
            InitializeComponent();
        }

        private void Facture_Load(object sender, EventArgs e)
        {
            this.Facture01.RefreshReport();
        }
    }
}
