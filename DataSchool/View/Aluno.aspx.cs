using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View
{
    public partial class Aluno : System.Web.UI.Page
    {
        private AlunoBll _alunoBll;

        public Aluno()
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

        }

        protected void gvdAluno_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvdAluno_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvdAluno_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void Insert(object sender, EventArgs e)
        {

        }
    }
}