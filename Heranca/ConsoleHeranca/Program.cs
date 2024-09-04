using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHeranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Funcionario fx = new Funcionario();
            fx.PagarSalario(4000);
            Console.WriteLine("Salário do funcionário: " + fx.Salario);

            Gerente gx = new Gerente();
            gx.PagarSalario(4000);
            Console.WriteLine("Salário do gerente: " + gx.Salario);

            Console.ReadKey();
            ;
        }
    }
}
