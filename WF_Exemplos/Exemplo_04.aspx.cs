using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF_Exemplos
{
    public partial class Exemplo_04 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void ExibirDados(DataSet pDados)
        {
            gvDados.DataSource = pDados;
            gvDados.DataBind();
        }

        private void ExibirDados(List<Aluno> pDados)
        {
            gvDados.DataSource = pDados;
            gvDados.DataBind();
        }

        private DataSet CarregarDadosXML()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Request.PhysicalApplicationPath + "Alunos.xml");

            return ds;
        }

        private List<Aluno> CarregarDadosComClasse()
        {
            List<Aluno> alunos = new List<Aluno>();
            for (int i = 1; i <= 20; i++)
            {
                Aluno aluno = new Aluno();
                aluno.Id = i;
                aluno.Nome = "Aluno " + i;
                aluno.Matricula = "Matrícula " + i;
                aluno.Curso = "Curso " + i;
                alunos.Add(aluno);
            }

            return alunos;
        }

        private void Listar()
        {
            switch (ddlAlunos.SelectedIndex)
            {
                case 0:
                    ExibirDados(CarregarDadosXML());
                    break;
                case 1:
                    ExibirDados(CarregarDadosComClasse());
                    break;
            }
        }

        protected void ddlAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar();
        }
    }
}