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
            }
        }

        private void Editar()
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
                lblRetornoOperacao.Text = "Aluno editar com sucesso";
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

        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}