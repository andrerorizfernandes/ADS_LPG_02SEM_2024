using Bll;
using Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NCamadas
{
    public partial class Index : System.Web.UI.Page
    {
        private void ExibirDados()
        {
            AlunoBll ab = new AlunoBll();

            gvdAluno.DataSource = ab.CarregarAlunos();
            gvdAluno.DataBind();
        }

        private void LimparCampos()
        {
            txtNovoNome.Text = string.Empty;
            txtNovaMatricula.Text = string.Empty;
            txtNovoCurso.Text = string.Empty;
        }

        protected void ExibirMensagem(string pMensagem)
        {
            string sJavaScript = "<script language=javascript>\n";
            sJavaScript += "alert('" + pMensagem + "');";
            sJavaScript += "\n";
            sJavaScript += "</script>";
            ClientScript.RegisterStartupScript(typeof(string), "MessageBox", sJavaScript);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExibirDados();
            }
        }

        private void Inserir()
        {
            Aluno a = new Aluno();
            a.Matricula = txtNovaMatricula.Text;
            a.Nome = txtNovoNome.Text;
            a.Curso = txtNovoCurso.Text;

            AlunoBll ab = new AlunoBll();
            if (ab.InserirAluno(a))
            {
                ExibirDados();
                ExibirMensagem("Aluno inserido com sucesso");
                LimparCampos();
            }
            else
            {
                ExibirMensagem("Erro ao inserir aluno");
            }
        }

        protected void Insert(object sender, EventArgs e)
        {
            Inserir();
        }

        protected void gvdUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvdAluno.EditIndex = -1;
            ExibirDados();
        }

        protected void gvdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            Aluno a = new Aluno();
            Label lblId = gvdAluno.Rows[index].FindControl("lblId") as Label;
            if (lblId != null)
            {
                a.Id = Convert.ToInt32(lblId.Text);
            }

            AlunoBll ab = new AlunoBll();
            if (ab.ExcluirAluno(a))
            {
                ExibirMensagem("Aluno excluído com sucesso");
            }
            else
            {
                ExibirMensagem("Falha ao excluir aluno");
            }

            gvdAluno.EditIndex = -1;
            ExibirDados();
        }

        protected void gvdUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvdAluno.EditIndex = e.NewEditIndex;
            ExibirDados();
        }

        protected void gvdUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            Aluno a = new Aluno();
            Label lblId = gvdAluno.Rows[index].FindControl("lblId") as Label;
            if (lblId != null)
            {
                a.Id = Convert.ToInt32(lblId.Text);
            }
            TextBox txtNome = gvdAluno.Rows[index].FindControl("txtNome") as TextBox;
            if (txtNome != null)
            {
                a.Nome = txtNome.Text;
            }
            TextBox txtMatricula = gvdAluno.Rows[index].FindControl("txtMatricula") as TextBox;
            if (txtMatricula != null)
            {
                a.Matricula = txtMatricula.Text;
            }
            TextBox txtCurso = gvdAluno.Rows[index].FindControl("txtCurso") as TextBox;
            if (txtCurso != null)
            {
                a.Curso = txtCurso.Text;
            }

            AlunoBll ab = new AlunoBll();
            if (ab.EditarAluno(a))
            {
                ExibirMensagem("Aluno editado com sucesso");
            }
            else
            {
                ExibirMensagem("Falha ao editar aluno");
            }

            gvdAluno.EditIndex = -1;
            ExibirDados();
        }
    }
}