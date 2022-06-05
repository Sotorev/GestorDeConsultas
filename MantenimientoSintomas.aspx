<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoSintomas.aspx.cs" Inherits="Proyecto_final.MantenimientoSintomas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mantemiento sintomas<br />
</h1>
<h2 class="text-center">Síntomas registrados</h2>
<asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
</asp:GridView>
<br />
Id&nbsp;
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
Descripción
<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox2" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<asp:Button ID="AgregarButton" runat="server" OnClick="AgregarButton_Click" Text="Agregar sintoma" />
<asp:Button ID="EditarButton" runat="server" OnClick="EditarButton_Click" Text="Editar sintoma existente" />
</asp:Content>
