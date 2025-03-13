using MySql.Data.MySqlClient;

namespace coldmakClass
{
    public static class Banco
    {
        public static MySqlCommand Abrir()
        {
            var cn = new MySqlConnection("server=127.0.0.1;database=coldmak;user=root;password=");
            cn.Open();
            return new MySqlCommand { Connection = cn };
        }
    }
}