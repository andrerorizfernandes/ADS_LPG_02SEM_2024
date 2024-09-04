using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHeranca
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }

        public double Salario { get; protected set; }

        public virtual void PagarSalario(double salario)
        {
            this.Salario = salario;
        }
    }
}
