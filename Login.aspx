<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Portal.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="Css/CssLogin.css" />
    <title>Tela De Login</title>
</head>
<body>
   <form id="form1" runat="server">
    <div class="telaDeLogin" >
      

            <br />
            <br />

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Sistemas/login.png" Width="94px"  />
            <br />
            <br />
            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
            <br />
            <asp:TextBox ID="txtLogin" runat="server" Width="275px" TextMode="Email"></asp:TextBox>
            <br />

            <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
            <br />
            <asp:TextBox ID="txtSenha" runat="server" Width="275px" TextMode="Password"></asp:TextBox>
            <br />
            <br />


            <asp:Button ID="btnEntra" runat="server" OnClick="btnEntra_Click" Text="Entrar" Width="148px" />
            <br />


        
    </div>

    </form>
</body>
</html>
