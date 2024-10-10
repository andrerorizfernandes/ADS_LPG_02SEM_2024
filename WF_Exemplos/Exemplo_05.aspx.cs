using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace WF_Exemplos
{
    public partial class Exemplo_05 : System.Web.UI.Page
    {
        private MySqlConnection Conexao()
        {
            MySqlConnection con = new MySqlConnection(@"server=127.0.0.1;user=root;password=18071988;database=ads");
            con.Open();

            return con;
        }

        private void ExibirDados(List<Aluno> pDados)
        {
            gvDados.DataSource = pDados;
            gvDados.DataBind();
        }

        private void LimparCampos()
        {
            txtID.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtCurso.Text = string.Empty;
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

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                ExibirDados(CarregarAlunos());
            } 
        }

        private void Inserir()
        {
            Aluno a = new Aluno();
            a.Matricula = txtMatricula.Text;
            a.Nome = txtNome.Text;
            a.Curso = txtCurso.Text;

            lblRetornoOperacao.Text = "Falha ao inserir aluno";
            if (InserirAluno(a))
            {
                ExibirDados(CarregarAlunos());
                lblRetornoOperacao.Text = "Aluno inserido com sucesso";
                LimparCampos();
            }
        }

        private void Editar()
        {
            if (txtID.Text == string.Empty)
            {
                ExibirMensagem("Informe o id para alteração");
            }
            else
            {
                Aluno a = new Aluno();
                a.Id = Convert.ToInt32(txtID.Text);
                a.Matricula = txtMatricula.Text;
                a.Nome = txtNome.Text;
                a.Curso = txtCurso.Text;

                lblRetornoOperacao.Text = "Falha ao editar aluno";
                if (EditarAluno(a))
                {
                    ExibirDados(CarregarAlunos());
                    lblRetornoOperacao.Text = "Aluno editado com sucesso";
                    LimparCampos();
                }
            }
        }

        private void Excluir()
        {
            if (txtID.Text == string.Empty)
            {
                ExibirMensagem("Informe o id para exclusão");
            }
            else
            {
                Aluno a = new Aluno();
                a.Id = Convert.ToInt32(txtID.Text);

                lblRetornoOperacao.Text = "Falha ao excluir aluno";
                if (ExcluirAluno(a))
                {
                    ExibirDados(CarregarAlunos());
                    lblRetornoOperacao.Text = "Aluno excluído com sucesso";
                    LimparCampos();
                }
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            Inserir();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            ExibirDados(CarregarAlunos());
        }
    }
}