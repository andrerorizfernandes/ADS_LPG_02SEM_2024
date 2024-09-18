<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exemplo_01.aspx.cs" Inherits="WF_Exemplos.Exemplo_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aula inicial</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtInformacao" runat="server" style="z-index: 1; left: 11px; top: 31px; position: absolute; width: 305px"></asp:TextBox>
        <asp:Label ID="lblInformacao" runat="server" BackColor="#FFFF66" style="z-index: 1; left: 10px; top: 61px; position: absolute; width: 310px"></asp:Label>
        <asp:Button ID="btnExibir" runat="server" OnClick="btnExibir_Click" style="z-index: 1; left: 10px; top: 89px; position: absolute; width: 111px" Text="Exibir" />
    </form>
</body>
</html>
