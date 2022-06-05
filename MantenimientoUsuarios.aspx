<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoUsuarios.aspx.cs" Inherits="Proyecto_final.MantenimientoUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Nombre de usuario:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    Contraseña:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    Nivel de usuario:<br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registrar usuario" />

</asp:Content>
