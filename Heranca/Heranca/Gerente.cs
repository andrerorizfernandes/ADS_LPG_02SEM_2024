using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    public class Gerente: Funcionario
    {
        public override void PagarSalario(double salario)
        {
            this.Salario = (salario * 1.2);
        }
    } 
}
