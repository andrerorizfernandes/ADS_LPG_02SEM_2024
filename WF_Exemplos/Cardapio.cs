using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WF_Exemplos
{
    public class Cardapio
    {
        public double EntradaFeminino { get; }
        public double EntradaMasculino { get; }
        public double ValorCerveja { get; }
        public double ValorRefrigerante { get; }
        public double ValorEspeto { get; }

        public Cardapio()
        {
            EntradaFeminino = 5;
            EntradaMasculino = 10;
            ValorCerveja = 9;
            ValorRefrigerante = 5;
            ValorEspeto = 10;
        }
    }
}