using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlaMundo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Conta x = new Conta();

            x.SetNumero(30);
            x.GetNumero();

            x.Nome = "pedro";
            string y = x.Nome;

            /*MyCustomClass myClass = new MyCustomClass();
            myClass.SetNumber(27);

            int resultado = myClass.Multiply(16);

            Console.WriteLine("Desenvolvido na primeira aula prática: " + resultado.ToString());
            Console.ReadKey();*/
        }
    }
}
