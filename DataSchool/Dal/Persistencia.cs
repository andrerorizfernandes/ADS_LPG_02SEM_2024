using MySql.Data.MySqlClient;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Persistencia
    {
        public static MySqlDataReader ExecutarSQL(string pSQL, Aluno pAluno)
        {
            MySqlCommand comando = new MySqlCommand(pSQL, Conexao.ConectarBD());
            if (pAluno != null)
            {
                comando.Parameters.AddWithValue("@codaluno", pAluno.CodAluno);
                comando.Parameters.AddWithValue("@nome", pAluno.Nome);
                comando.Parameters.AddWithValue("@cpf", pAluno.Cpf);
                comando.Parameters.AddWithValue("@sexo", pAluno.Sexo);
                comando.Parameters.AddWithValue("@idade", pAluno.Idade);
            }
            MySqlDataReader dr = comando.ExecuteReader();

            return dr;
        }

        public static bool ExecutarSQL(string pSQL, Professor pProfessor)
        {
            MySqlCommand comando = new MySqlCommand(pSQL, Conexao.ConectarBD());
            if (pProfessor != null)
            {
                comando.Parameters.AddWithValue("@codprofessor", pProfessor.CodProfessor);
                comando.Parameters.AddWithValue("@nome", pProfessor.Nome);
                comando.Parameters.AddWithValue("@cpf", pProfessor.Cpf);
                comando.Parameters.AddWithValue("@sexo", pProfessor.Sexo);
                comando.Parameters.AddWithValue("@titulacao", pProfessor.Titulacao);
                comando.Parameters.AddWithValue("@area", pProfessor.Area);
            }
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }
    }
}
