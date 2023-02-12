<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PageAutor.aspx.cs" Inherits="Portal.PageAutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alterações de autores" Height="235px">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Width="118px" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome do Autor"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="396px"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Foto"></asp:Label>
        <br />
        <asp:FileUpload ID="fuFoto" runat="server" />
        <br />
        <br />

        <asp:Button ID="btnAdd" runat="server"  Text="Salvar" Width="95px" OnClick="btnAdd_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" Width="98px" OnClick="btnCancelar_Click"  />
        <br />
        <br />
       

    </asp:Panel>


    
    <asp:Panel ID="Panel3" runat="server"  GroupingText="Registro de Autores" Height="662px" >

         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="678px" Height="199px" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:CommandField ShowSelectButton="True" />
                 <asp:CommandField ShowDeleteButton="True" />
                 <asp:BoundField DataField="id" HeaderText="ID" />
                 <asp:BoundField DataField="nome" HeaderText="Autor" />
                 <asp:ImageField DataImageUrlField="foto" DataImageUrlFormatString="~/Imagens/Autores/{0}" HeaderText="Foto">
                     <ControlStyle Height="120px" />
                 </asp:ImageField>
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


</asp:Content>
