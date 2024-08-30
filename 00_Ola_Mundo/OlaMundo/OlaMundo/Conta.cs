using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlaMundo
{
    public class Conta
    {
        
        private double saldo;
        private Cliente titular;

        public string Nome { get; set; }

        private int numero;
        public int GetNumero()
        {
            return this.numero;
        }

        public void SetNumero(int numero)
        {
            this.numero = numero;
        }

        public void Saca(double valor)
        {
            this.saldo -= valor;
        }

        public void Deposita(double valor)
        {
            this.saldo += valor;
        }

        public Conta(double saldo)
        {
            this.saldo = saldo;
        }

        public Conta()
        {

        }
    }
}
