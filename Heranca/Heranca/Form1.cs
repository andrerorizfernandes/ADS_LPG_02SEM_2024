using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heranca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario();
            func.PagarSalario(4000);
            MessageBox.Show(func.Salario.ToString());

            Gerente ger = new Gerente();
            ger.PagarSalario(4000);
            MessageBox.Show(ger.Salario.ToString());
        }
    }
}
