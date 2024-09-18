using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF_Exemplos
{
    public partial class Exemplo_01 : System.Web.UI.Page
    {
        private void ExibirMensagem()
        {
            lblInformacao.Text = Utilidade.Mensagem(txtInformacao.Text);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnExibir_Click(object sender, EventArgs e)
        {
            ExibirMensagem();
        } 
    }
}