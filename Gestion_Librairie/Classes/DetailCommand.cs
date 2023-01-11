using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Librairie.Classes
{
    internal class DetailCommand
    {
        private int id;
        private int command_id;
        private int produit_id;
        private double total;

        public DetailCommand(int command_id, int produit_id, double total)
        {
            this.Command_id = command_id;
            this.Produit_id = produit_id;
            this.Total = total;
        }

        public int Id { get => id; set => id = value; }
        public int Command_id { get => command_id; set => command_id = value; }
        public int Produit_id { get => produit_id; set => produit_id = value; }
        public double Total { get => total; set => total = value; }
    }
}
