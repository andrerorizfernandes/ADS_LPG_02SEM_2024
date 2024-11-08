using Bll;
using System;
using Pojo;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{

    public partial class AlunoView : System.Web.UI.Page
    {
        private AlunoBll _alunoBll;

        public AlunoView()
        {
            _alunoBll = new AlunoBll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Lib.ExibirDados(_alunoBll, gvdAluno);
            }
        }

        protected void gvdAluno_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvdAluno.EditIndex = -1;
            Lib.ExibirDados(_alunoBll, gvdAluno);
        }

        protected void gvdAluno_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;

            Aluno aluno = new Aluno();
            Label lblCodAluno = gvdAluno.Rows[index].FindControl("lblCodAluno") as Label;
            if (lblCodAluno != null)
            {
                aluno.CodAluno = Convert.ToInt32(lblCodAluno.Text);
            }

            _alunoBll.ExcluirAluno(aluno);
            gvdAluno.EditIndex = -1;
            Lib.ExibirDados(_alunoBll, gvdAluno);
        }

        protected void gvdAluno_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvdAluno.EditIndex = e.NewEditIndex;
            Lib.ExibirDados(_alunoBll, gvdAluno);
        }

        protected void gvdAluno_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;

            Aluno aluno = new Aluno();
            Label lblCodAluno = gvdAluno.Rows[index].FindControl("lblCodAluno") as Label;
            if (lblCodAluno != null)
            {
                aluno.CodAluno = Convert.ToInt32(lblCodAluno.Text);
            }
            TextBox txtNome = gvdAluno.Rows[index].FindControl("txtNome") as TextBox;
            if (txtNome != null)
            {
                aluno.Nome = txtNome.Text;
            }
            TextBox txtCpf = gvdAluno.Rows[index].FindControl("txtCpf") as TextBox;
            if (txtCpf != null)
            {
                aluno.Cpf = txtCpf.Text;
            }
            TextBox txtSexo = gvdAluno.Rows[index].FindControl("txtSexo") as TextBox;
            if (txtSexo != null)
            {
                aluno.Sexo = txtSexo.Text;
            }
            TextBox txtIdade = gvdAluno.Rows[index].FindControl("txtIdade") as TextBox;
            if (txtIdade != null)
            {
                aluno.Idade = Convert.ToInt32(txtIdade.Text);
            }

            _alunoBll.EditarAluno(aluno);
            gvdAluno.EditIndex = -1;
            Lib.ExibirDados(_alunoBll, gvdAluno);
        }

        protected void Insert(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno();
            aluno.Nome = txtNovoNome.Text;
            aluno.Cpf = txtNovoCpf.Text;
            aluno.Sexo = txtNovoSexo.Text;
            aluno.Idade = Convert.ToInt32(txtNovoIdade.Text);

            _alunoBll.InserirAluno(aluno);
            Lib.ExibirDados(_alunoBll, gvdAluno);

            txtNovoCpf.Text = string.Empty;
            txtNovoIdade.Text = string.Empty;
            txtNovoNome.Text = string.Empty;
            txtNovoSexo.Text = string.Empty;
        }
    }
}