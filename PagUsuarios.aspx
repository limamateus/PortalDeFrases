<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagUsuarios.aspx.cs" Inherits="Portal.PagUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="Panel1" runat="server" Height="270px" style="font-weight: 700">
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="57px"></asp:TextBox>


        <br />    <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="245px"></asp:TextBox>
        <br />

        <br />    <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
      
        <asp:TextBox ID="txtEmail" runat="server" Width="239px" TextMode="Email" ></asp:TextBox>
        <br />
       

        
        <br />    <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="txtSenha" runat="server" Width="234px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSalvarOuAtualizar" runat="server" Text="Salvar" Width="112px" OnClick="btnSalvarOuAtualizar_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="112px" OnClick="btnCancelar_Click" />


    </asp:Panel>

    <asp:Panel ID="Panel2" runat="server" Height="442px">
        <asp:GridView ID="gridUsuarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="299px" Width="1014px" AutoGenerateColumns="False" OnRowDeleting="gridUsuarios_RowDeleting" OnSelectedIndexChanged="gridUsuarios_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="email" HeaderText="E-mail" />
                <asp:BoundField DataField="senha" HeaderText="Senha" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

    </asp:Panel>
</asp:Content>
