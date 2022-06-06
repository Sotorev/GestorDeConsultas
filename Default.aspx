<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_final._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
    <h1>Bienvenido al gestor de consultas</h1>
    <p class="lead">
        Aquí podrá administrar y crear consultas.</p>
</div>

    <h2>Resumen</h2>
    <p>
        Enfermedades más diagnosticadas</p>
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    <p>
        Edad promedio de pacientes:&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        Medicamentos más recetados</p>
    <p>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    </p>
    <p>
        Total de ingresos del
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;al
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
&nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Obtener ingresos" />
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Total de ingresos"></asp:Label>
    </p>

</asp:Content>
