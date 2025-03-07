﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace coldmakClass
{
    // classe Banco é nossa classe de conexão
    public static class Banco // static pois não precisaremos criar uma instancia de Banco para conectar às nossas base dados
    {
        public static MySqlCommand Abrir(int cod = 0) // método para abrir conexão
        {
            string strcon = @"server=127.0.0.1;database=coldmak;user=root;password=";
            MySqlConnection cn = new(strcon);
            MySqlCommand cmd = new();
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return cmd;
        }
    }
}
