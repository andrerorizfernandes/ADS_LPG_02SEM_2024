using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlaMundo
{
    public class MyCustomClass
    {
        private int numero;

        public int GetNumber()
        {
            return numero;
        }

        public void SetNumber(int numero)
        {
            this.numero = numero;
        }

//       public int Number { get; set; }
        public int Multiply(int num)
        {
            return num * numero;
        }

        public MyCustomClass()
        {
            numero = 0;
        }

        public MyCustomClass(int numero)
        {
            this.numero = numero;
        }

        public MyCustomClass(int numero, int elevado)
        {
            this.numero = numero;
        }
    }
}
