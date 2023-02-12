<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Portal.Categoria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alterações de Categorias" Height="160px">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Width="118px" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome da Categoria"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="396px"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Inserir" Width="95px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" Width="98px" OnClick="btnCancelar_Click" />
        <br />
        <br />
       

    </asp:Panel>


    
    <asp:Panel ID="Panel3" runat="server"  GroupingText="Registro de Categorias" Height="662px" >

         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="678px" Height="199px" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:CommandField ShowSelectButton="True" />
                 <asp:CommandField ShowDeleteButton="True" />
                 <asp:BoundField DataField="id" HeaderText="ID" />
                 <asp:BoundField DataField="categoria" HeaderText="Categoria" />
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
       
        <br />
        <br />

    </asp:Panel>

    <asp:PlaceHolder ID="PH1" runat="server"></asp:PlaceHolder>



</asp:Content>
