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
            MyCustomClass myClass = new MyCustomClass();
            myClass.SetNumber(27);

            int resultado = myClass.Multiply(16);

            Console.WriteLine("Desenvolvido na primeira aula prática: " + resultado.ToString());
            Console.ReadKey();
        }
    }
}
