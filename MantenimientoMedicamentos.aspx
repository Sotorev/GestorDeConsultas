<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoMedicamentos.aspx.cs" Inherits="Proyecto_final.MantenimientoMedicamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mantenimiento medicamentos</h1>
<h2>
    <br />
    Medicamentos existentes</h2>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
Codigo
<asp:TextBox ID="CodigoTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CodigoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
Ingrediente genérico
<asp:TextBox ID="IngrTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="IngrTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
Lab (Marca comercial)
<asp:TextBox ID="MarcaTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="MarcaTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
Enfermedades
<asp:TextBox ID="EnfermedadesTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="EnfermedadesTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<asp:Button ID="AgregarButton" runat="server" OnClick="AgregarButton_Click" Text="Agregar medicamento" />
<asp:Button ID="EditarButton" runat="server" OnClick="EditarButton_Click" Text="Editar medicamento existente" />
</asp:Content>
