using MySql.Data.MySqlClient;
using System;

namespace coldmakClass
{
    public static class Banco
    {
        private static string connectionString = "server=127.0.0.1;database=coldmak;user=root;password=";

        public static MySqlCommand Abrir()
        {
            var cn = new MySqlConnection(connectionString);
            cn.Open();
            return new MySqlCommand { Connection = cn };
        }

        // Método para fechar a conexão manualmente, se necessário
        public static void Fechar(MySqlCommand cmd)
        {
            if (cmd != null && cmd.Connection != null && cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }
    }
}