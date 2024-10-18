using Dal;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class AlunoBll
    {
        public List<Aluno> CarregarAlunos()
        {
            AlunoDal a = new AlunoDal();
            return a.CarregarAlunos();
        }

        public bool InserirAluno(Aluno aluno)
        {
            AlunoDal a = new AlunoDal();
            return a.InserirAluno(aluno);
        }

        public bool EditarAluno(Aluno aluno)
        {
            AlunoDal a = new AlunoDal();
            return a.EditarAluno(aluno);
        }

        public bool ExcluirAluno(Aluno aluno)
        {
            AlunoDal a = new AlunoDal();
            return a.ExcluirAluno(aluno);
        }
    }
}
