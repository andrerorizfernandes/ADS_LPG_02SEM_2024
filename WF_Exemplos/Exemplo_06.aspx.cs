using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WF_Exemplos
{
    public partial class Exemplo_06 : System.Web.UI.Page
    {
        private MySqlConnection Conexao()
        {
            MySqlConnection con = new MySqlConnection(@"server=127.0.0.1;user=root;password=18071988;database=ads");
            con.Open();

            return con;
        }

        private void ExibirDados(List<Aluno> pDados)
        {
            gvdAluno.DataSource = pDados;
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

        private List<Aluno> CarregarAlunos()
        {
            MySqlCommand comando = new MySqlCommand("SELECT id, matricula, nome, curso FROM aluno", Conexao());
            MySqlDataReader dr = comando.ExecuteReader();

            List<Aluno> alunos = new List<Aluno>();
            while (dr.Read())
            {
                Aluno aluno = new Aluno();

                aluno.Id = Convert.ToInt32(dr["id"].ToString());
                aluno.Nome = dr["nome"].ToString();
                aluno.Matricula = dr["matricula"].ToString();
                aluno.Curso = dr["curso"].ToString();

                alunos.Add(aluno);
            }

            return alunos;
        }

        private bool InserirAluno(Aluno aluno)
        {
            MySqlCommand comando = new MySqlCommand("Insert Into Aluno (matricula, nome, curso) " +
                "Value (@matricula, @nome, @curso)", Conexao());
            comando.Parameters.AddWithValue("@matricula", aluno.Matricula);
            comando.Parameters.AddWithValue("@nome", aluno.Nome);
            comando.Parameters.AddWithValue("@curso", aluno.Curso);
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }

        private bool EditarAluno(Aluno aluno)
        {
            MySqlCommand comando = new MySqlCommand("Update Aluno Set matricula=@matricula, nome=@nome, curso=@curso" +
                " Where id=@id", Conexao());
            comando.Parameters.AddWithValue("@matricula", aluno.Matricula);
            comando.Parameters.AddWithValue("@nome", aluno.Nome);
            comando.Parameters.AddWithValue("@curso", aluno.Curso);
            comando.Parameters.AddWithValue("@id", aluno.Id.ToString());
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }

        private bool ExcluirAluno(Aluno aluno)
        {
            MySqlCommand comando = new MySqlCommand("Delete From Aluno" +
                " Where id=@id", Conexao());
            comando.Parameters.AddWithValue("@id", aluno.Id.ToString());
            MySqlDataReader dr = comando.ExecuteReader();

            return (dr.RecordsAffected > 0);
        }

        private void Inserir()
        {
            Aluno a = new Aluno();
            a.Matricula = txtNovaMatricula.Text;
            a.Nome = txtNovoNome.Text;
            a.Curso = txtNovoCurso.Text;

            if (InserirAluno(a))
            {
                ExibirDados(CarregarAlunos());
                ExibirMensagem("Aluno inserido com sucesso");
                LimparCampos();
            }
            else
            {
                ExibirMensagem("Erro ao inserir aluno");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ExibirDados(CarregarAlunos());
            }
        }

        protected void Insert(object sender, EventArgs e)
        {
            Inserir();
        }

        protected void gvdUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvdAluno.EditIndex = -1;
            ExibirDados(CarregarAlunos());
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

            if (ExcluirAluno(a))
            {
                ExibirMensagem("Aluno excluído com sucesso");
            }
            else
            {
                ExibirMensagem("Falha ao excluir aluno");
            }

            gvdAluno.EditIndex = -1;
            ExibirDados(CarregarAlunos());
        }

        protected void gvdUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvdAluno.EditIndex = e.NewEditIndex;
            ExibirDados(CarregarAlunos());
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

            if (EditarAluno(a))
            {
                ExibirMensagem("Aluno editado com sucesso");
            }
            else
            {
                ExibirMensagem("Falha ao editar aluno");
            }

            gvdAluno.EditIndex = -1;
            ExibirDados(CarregarAlunos());
        }
    }
}