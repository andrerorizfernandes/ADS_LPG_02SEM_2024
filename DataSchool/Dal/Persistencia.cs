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
        public static MySqlDataReader ExecutarSQL(string pSQL, object pEntidade)
        {
            MySqlCommand comando = new MySqlCommand(pSQL, Conexao.ConectarBD());
            if (pEntidade is Aluno aluno)
	        {           
               comando.Parameters.AddWithValue("@codaluno", aluno.CodAluno);
               comando.Parameters.AddWithValue("@nome", aluno.Nome);
               comando.Parameters.AddWithValue("@cpf", aluno.Cpf);
               comando.Parameters.AddWithValue("@sexo", aluno.Sexo);
               comando.Parameters.AddWithValue("@idade", aluno.Idade);
               
	        }else 
            if (pEntidade is Professor professor)
            {
               comando.Parameters.AddWithValue("@codprofessor", professor.CodProfessor);
               comando.Parameters.AddWithValue("@nome", professor.Nome);
               comando.Parameters.AddWithValue("@cpf", professor.Cpf);
               comando.Parameters.AddWithValue("@sexo", professor.Sexo);
               comando.Parameters.AddWithValue("@titulacao", professor.Titulacao);
               comando.Parameters.AddWithValue("@area", professor.Area);
            }

            MySqlDataReader dr = comando.ExecuteReader();
            return dr;
        }

        public static int RetornarProximoId(string pNomeTabela, string pNomeCampoChave)
        {
            var lSql = "Select Coalesce(Max(" + pNomeCampoChave + ")+1, 1) ProximoCodigo From " + pNomeTabela;
            using (var dr = ExecutarSQL(lSql, null))
            {
                dr.Read();
                return Convert.ToInt32(dr["ProximoCodigo"].ToString());
            }
        }
    }
}
