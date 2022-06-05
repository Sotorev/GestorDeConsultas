<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoPacientes.aspx.cs" Inherits="Proyecto_final.MantenimientoPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-lg-6 jumbotron">
        <h2 style="font-size: x-large"><strong>Registrar paciente</strong></h2>
        <br />
        NIT:
    <asp:TextBox ID="NitTextBox" runat="server" ValidationGroup="R"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="NitTextBox" ErrorMessage="Campos obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <br />
        Nombre:
    <asp:TextBox ID="NombreTextBox" runat="server" ValidationGroup="R"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="NombreTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <br />
        Apellido:
    <asp:TextBox ID="ApellidoTextBox" runat="server" ValidationGroup="R"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ApellidoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <br />
        Dirección:
    <asp:TextBox ID="DireccionTextBox" runat="server" ValidationGroup="R"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DireccionTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <br />
        Fecha de nacimiento:
    <asp:TextBox ID="FechaNacimientoTextBox" runat="server" TextMode="Date" ValidationGroup="R"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FechaNacimientoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <br />
        Telefono:
    <asp:TextBox ID="TelefonoTextBox" runat="server" ValidationGroup="R"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TelefonoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="R"></asp:RequiredFieldValidator>

        <br />

        <br />
        <asp:Button ID="GuardarButton" runat="server" Text="Registrar" OnClick="GuardarButton_Click" ValidationGroup="R" />
    </div>
    <div class="col-lg-6 jumbotron">
        <h2 style="font-size: x-large"><strong>Pacientes registrados</strong></h2>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
        <h2 style="font-size: x-large"><strong>Editar paciente</strong></h2>

        Seleccione Nit<br />
        <asp:DropDownList ID="NitDropDownList" runat="server" Height="16px">
        </asp:DropDownList>
        <br />
        <br />
        Nombre:
    <asp:TextBox ID="NombreTextBox0" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="NombreTextBox0" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="E"></asp:RequiredFieldValidator>
        <br />
        <br />
        Apellido:
    <asp:TextBox ID="ApellidoTextBox0" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ApellidoTextBox0" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="E"></asp:RequiredFieldValidator>
        <br />
        <br />
        Dirección:
    <asp:TextBox ID="DireccionTextBox0" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DireccionTextBox0" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="E"></asp:RequiredFieldValidator>
        <br />
        <br />
        Fecha de nacimiento:
    <asp:TextBox ID="FechaNacimientoTextBox0" runat="server" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="FechaNacimientoTextBox0" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="E"></asp:RequiredFieldValidator>
        <br />
        <br />
        Telefono:
    <asp:TextBox ID="TelefonoTextBox0" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TelefonoTextBox0" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True" ValidationGroup="E"></asp:RequiredFieldValidator>

        <br />
        <br />

        <asp:Button ID="EditarButton" runat="server" OnClick="EditarButton_Click" Text="Editar datos de paciente" ValidationGroup="E" />

    </div>

</asp:Content>
