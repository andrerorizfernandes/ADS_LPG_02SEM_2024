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
        private AlunoDal _alunoDal;

        public AlunoBll()
        {
            _alunoDal = new AlunoDal();
        }

        public bool InserirAluno(Aluno aluno)
        {
            return _alunoDal.InserirAluno(aluno);
        }

        public bool EditarAluno(Aluno aluno)
        {
            return _alunoDal.EditarAluno(aluno);
        }

        public bool ExcluirAluno(Aluno aluno)
        {
            return _alunoDal.ExcluirAluno(aluno);
        }

        public List<Aluno> ListarAlunos()
        {
            return _alunoDal.ListarAlunos();
        }
    }
}
