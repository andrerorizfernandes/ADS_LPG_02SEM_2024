using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Conexao
    {
        private static string strigConexao = "server=127.0.0.1;user=root;password=18071988;database=dataschool";

        public static MySqlConnection ConectarBD()
        {
            MySqlConnection conexao = new MySqlConnection(strigConexao);
            conexao.Open();
            return conexao;
        }
    }
}
