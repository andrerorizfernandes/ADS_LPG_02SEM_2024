<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlunoView.aspx.cs" Inherits="View.AlunoView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            z-index: 1;
            left: 10px;
            top: 56px;
            position: absolute;
            height: 226px;
            width: 936px;
        }
    </style>
</head>
<body style="height: 195px">
    <form id="form1" runat="server">               
        <asp:GridView ID="gvdAluno" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCancelingEdit="gvdAluno_RowCancelingEdit" OnRowDeleting="gvdAluno_RowDeleting" OnRowEditing="gvdAluno_RowEditing" OnRowUpdating="gvdAluno_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="Código">
                    <EditItemTemplate>
                        <asp:Label ID="lblCodAluno" runat="server" Text='<%# Bind("codaluno") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCodAluno" runat="server" Text='<%# Bind("codaluno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNome" runat="server" Text='<%# Bind("nome") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Bind("nome") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Cpf">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtCpf" runat="server" Text='<%# Bind("cpf") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCpf" runat="server" Text='<%# Bind("cpf") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sexo">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSexo" runat="server" Text='<%# Bind("sexo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSexo" runat="server" Text='<%# Bind("sexo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Idade">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIdade" runat="server" Text='<%# Bind("idade") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdade" runat="server" Text='<%# Bind("idade") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CommandName="Update"></asp:Button>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancel"></asp:Button>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Edit"></asp:Button>
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CommandName="Delete"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>    
        <p></p>
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
            <tr>                    
                <td style="width:300">
                    Nome:<br/>
                    <asp:TextBox ID="txtNovoNome" runat="server" Width="300" />
                </td>
                <td style="width:120px">
                    Cpf:<br/>
                    <asp:TextBox ID="txtNovoCpf" runat="server" Width="120"/>
                </td>
                <td style="width:180px">
                    Sexo:<br/>
                    <asp:TextBox ID="txtNovoSexo" runat="server" Width="180"/>
                </td>
                <td style="width:180px">
                    Idade:<br/>
                    <asp:TextBox ID="txtNovoIdade" runat="server" Width="180"/>
                </td>
                <td>
                    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="Insert"></asp:Button>
                </td>
            </tr>
        </table>                 
    </form>
</body>
</html>