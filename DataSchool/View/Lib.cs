using Bll;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace View
{
    public class Lib
    {
        public static void ExibirDados(AlunoBll alunoBll, GridView pGrid)
        {
            pGrid.DataSource = alunoBll.ListarAlunos();
            pGrid.DataBind();
        }
    }
}