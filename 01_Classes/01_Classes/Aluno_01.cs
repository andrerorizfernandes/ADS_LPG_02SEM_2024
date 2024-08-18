using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Classes
{
    public class Aluno_01
    {
        private int codigo;
        private string nome;
        private string sexo;
        private int idade;

        public void SetCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public int GetCodigo()
        {
            return this.codigo;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public void SetSexo(string sexo)
        {
            this.sexo = sexo;
        }

        public string GetSexo()
        {
            return this.sexo;
        }

        public void SetIdade(int idade)
        {
            this.idade = idade;
        }

        public int GetIdade()
        {
            return this.idade;
        }
    }
}
