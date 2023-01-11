using MySql.Data.MySqlClient;

namespace Gestion_Librairie.Connection
{
    internal class Connexion
    {
        public MySqlConnection connMaster;
        public void connexion()
        {
            connMaster = new MySqlConnection($"datasource=localhost;port=3306;username=root;password=;database=bibliotheque");
        }
        public void cnxOpen()
        {
            connMaster.Open();
        }
        public void cnxClose()
        {
            connMaster.Close();
        }
    }
}
