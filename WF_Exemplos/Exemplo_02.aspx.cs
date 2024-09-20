using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF_Exemplos
{
    public partial class Exemplo_02 : System.Web.UI.Page
    {
        protected void showMessageBox(string message)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + message + "');";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        private void RetornarValorDaCorSelecionada()
        {
            lblInformacao.Text = ddlDados.SelectedValue;
        }

        private void PreencherTermosDoContrato()
        {
            lblInfo02.Text = string.Empty;

            if (chkAceito.Checked)
            {
                lblInfo02.Text = "Termos do contrato aceitos";
            }
        }

        private void PreecherCores()
        {
            ddlDados.Items.Add(new ListItem("Amarelo", "100"));
            ddlDados.Items.Add(new ListItem("Azul", "200"));
            ddlDados.Items.Add(new ListItem("Verde", "300"));
            ddlDados.Items.Add(new ListItem("Vermelho", "400"));
            ddlDados.Items.Add(new ListItem("Rosa", "500"));
        }

        private void PreencherCarros()
        {
            lbiCarros.Items.Add(new ListItem("Corolla", "1"));
            lbiCarros.Items.Add(new ListItem("Civic", "2"));
            lbiCarros.Items.Add(new ListItem("Polo", "3"));
            lbiCarros.Items.Add(new ListItem("Siena", "4"));
            lbiCarros.Items.Add(new ListItem("Palio", "5"));
            lbiCarros.Items.Add(new ListItem("Celta", "6"));
        }

        private void ExibirCarrosSelecionados()
        {
            string lCarrosSelecionados = string.Empty;

            foreach (ListItem lValor in lbiCarros.Items)
            {
                if (lValor.Selected)
                {
                    lCarrosSelecionados += lValor.Text + ";";
                }
            }

            lCarrosSelecionados = lCarrosSelecionados.Substring(0, lCarrosSelecionados.Length - 1);

            if (lCarrosSelecionados.Trim() != string.Empty)
            {
                showMessageBox(lCarrosSelecionados);
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreecherCores();
                PreencherCarros();
            }
        }

        protected void ddlDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetornarValorDaCorSelecionada();
        }

        protected void chkAceito_CheckedChanged(object sender, EventArgs e)
        {
            PreencherTermosDoContrato();
        }

        protected void btnSelecionados_Click(object sender, EventArgs e)
        {
            ExibirCarrosSelecionados();
        }
    }
}