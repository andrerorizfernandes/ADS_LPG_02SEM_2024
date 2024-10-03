using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF_Exemplos
{
    public partial class Exemplo_03 : System.Web.UI.Page
    {
        private void CalcularEntrada()
        {
            Cardapio cardapio = new Cardapio();

            double Calculo = 0; 
            double TotalGeral = double.Parse(Session["TotalGeral"].ToString());
            switch (cboSexo.SelectedIndex)
            {
                case 0:
                {
                    Calculo += cardapio.EntradaFeminino;
                    break;
                }
                case 1:
                {
                    Calculo += cardapio.EntradaMasculino;
                    break;
                }
            }

            Calculo += (Convert.ToInt32(txtQtdCervejas.Text) * cardapio.ValorCerveja);
            Calculo += (Convert.ToInt32(txtQtdRefrigerantes.Text) * cardapio.ValorRefrigerante);
            Calculo += (Convert.ToInt32(txtQtdEspetinhos.Text) * cardapio.ValorEspeto);
            TotalGeral += Calculo;
            Session["TotalGeral"] = TotalGeral;

            lblTotalAtual.Text = "Total a Pagar: " + Calculo;
            lblTotalGeral.Text = "Total Geral: " + TotalGeral;
        }

        private void LimparCampos()
        {
            cboSexo.SelectedIndex = 0;
            txtQtdCervejas.Text = "0";
            txtQtdEspetinhos.Text = "0";
            txtQtdRefrigerantes.Text = "0";
            cboSexo.Focus();
        }

        private void ReiniciarValorAtual()
        {
            lblTotalAtual.Text = "Total a Pagar: 0";
            lblTotalGeral.Text = "Total Geral Recebido: 0";
            Session["TotalGeral"] = 0.0;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TotalGeral"] = 0.0;
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularEntrada();
            LimparCampos();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            ReiniciarValorAtual();
        }
    }
}