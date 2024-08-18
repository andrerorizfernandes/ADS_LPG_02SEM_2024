using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Aluno_01 al = new Aluno_01();
            al.SetCodigo(1);
            al.SetNome("Andre");
            al.SetSexo("Masculino");
            al.SetIdade(36);

            string mensagem = $"O aluno {al.GetNome()} possui o código {al.GetCodigo()} " +
                $"é do sexo {al.GetSexo()} e atualmente está com {al.GetIdade()} anos.\n\n" +
                "Aperte qualquer tecla para encerrar esse prompt...";

            Console.WriteLine(mensagem);
            Console.ReadKey();
        }
    }
}
