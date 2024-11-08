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
        public bool InserirAluno(Aluno aluno)
        {
            aluno.CodAluno = Persistencia.RetornarProximoId("aluno", "codaluno");
            return (Persistencia.ExecutarSQL("Insert Into Aluno Values (@codaluno, @nome, @cpf, @sexo," +
                "@idade)", aluno).RecordsAffected > 0);
        }

        public bool EditarAluno(Aluno aluno)
        {
            return (Persistencia.ExecutarSQL("Update Aluno Set nome=@nome, cpf=@cpf, sexo=@sexo," +
                "idade=@idade Where CodAluno=@codaluno", aluno).RecordsAffected > 0);
        }

        public bool ExcluirAluno(Aluno aluno)
        {
            return (Persistencia.ExecutarSQL("Delete From Aluno Where CodAluno=@codaluno", aluno).RecordsAffected > 0);
        }

        public List<Aluno> ListarAlunos()
        {
            using (var dr = Persistencia.ExecutarSQL("Select codaluno, nome, cpf, sexo, idade From aluno",
                null))
            {
                List<Aluno> alunos = new List<Aluno>();
                while (dr.Read())
                {
                    Aluno aluno = new Aluno();

                    aluno.CodAluno = Convert.ToInt32(dr["codaluno"].ToString());
                    aluno.Nome = dr["nome"].ToString();
                    aluno.Cpf = dr["cpf"].ToString();
                    aluno.Sexo = dr["sexo"].ToString();
                    aluno.Idade = Convert.ToInt32(dr["idade"].ToString());

                    alunos.Add(aluno);
                }

                return alunos;
            }
        }
    }
}
