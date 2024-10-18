using MySql.Data.MySqlClient;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AlunoDal
    {
        public List<Aluno> CarregarAlunos()
        {
            MySqlCommand comando = new MySqlCommand("SELECT id, matricula, nome, curso FROM aluno", Conexao.ConectarBD());
            MySqlDataReader dr = comando.ExecuteReader();

            List<Aluno> alunos = new List<Aluno>();
            while (dr.Read())
            {
                Aluno aluno = new Aluno();

                aluno.Id = Convert.ToInt32(dr["id"].ToString());
                aluno.Nome = dr["nome"].ToString();
                aluno.Matricula = dr["matricula"].ToString();
                aluno.Curso = dr["curso"].ToString();

                alunos.Add(aluno);
            }

            return alunos;
        }

        public bool InserirAluno(Aluno aluno)
        {
            MySqlCommand comando = new MySqlCommand("Insert Into Aluno (matricula, nome, curso) " +
                "Value (@matricula, @nome, @curso)", Conexao.ConectarBD());
            comando.Parameters.AddWithValue("@matricula", aluno.Matricula);
            comando.Parameters.AddWithValue("@nome", aluno.Nome);
            comando.Parameters.AddWithValue("@curso", aluno.Curso);
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }

        public bool EditarAluno(Aluno aluno)
        {
            MySqlCommand comando = new MySqlCommand("Update Aluno Set matricula=@matricula, nome=@nome, curso=@curso" +
                " Where id=@id", Conexao.ConectarBD());
            comando.Parameters.AddWithValue("@matricula", aluno.Matricula);
            comando.Parameters.AddWithValue("@nome", aluno.Nome);
            comando.Parameters.AddWithValue("@curso", aluno.Curso);
            comando.Parameters.AddWithValue("@id", aluno.Id.ToString());
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }

        public bool ExcluirAluno(Aluno aluno)
        {
            MySqlCommand comando = new MySqlCommand("Delete From Aluno" +
                " Where id=@id", Conexao.ConectarBD());
            comando.Parameters.AddWithValue("@id", aluno.Id.ToString());
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }
    }
}
