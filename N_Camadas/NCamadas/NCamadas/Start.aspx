<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="NCamadas.Start" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Form com Menu</title>
    <link rel="stylesheet" type="text/css" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="menu">
                <ul>
                    <li><a href="Index.aspx">Professor</a></li>
                    <li><a href="Aluno.aspx">Aluno</a></li>                    
                </ul>
            </div>
        </header>
        <div class="content">
        </div>
        <footer>
            <p>&copy; ADS/FASM - 2024. Todos os direitos reservados.</p>
        </footer>
    </form>
    <script src="script.js"></script>
</body>
</html>