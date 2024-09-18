using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.WebControls;

namespace WF_Exemplos
{
    public class Utilidade
    {
        public static string Mensagem(string pMensagem)
        {
            return "**" + pMensagem + "**";
        }
    }
}