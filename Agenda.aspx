<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agenda.aspx.cs" Inherits="Proyecto_final.Agenda1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Agenda</h1>
    <br />
    <div class="col-lg-6">
        Paciente:
    <asp:DropDownList ID="PacienteDropDownList" runat="server">
    </asp:DropDownList>
        <br />
        Fecha:
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
        <DayStyle BackColor="#CCCCCC" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" />
    </asp:Calendar>
        <br />
        Hora de inicio:<br />
        <asp:TextBox ID="HoraInicioTextBox" runat="server" TextMode="Time" OnTextChanged="HoraInicioTextBox_TextChanged"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="HoraInicioTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        Hora de finalizacion:<br />
        <asp:TextBox ID="HoraFinTextBox" runat="server" TextMode="Time" OnTextChanged="HoraFinTextBox_TextChanged"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="HoraFinTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" ValidationGroup="R"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" Text="Crear cita" ValidationGroup="R" />
    </div>
    <div class="col-lg-6">
        <h2>Citas reservadas</h2>
        <asp:GridView ID="CitasGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Nit" HeaderText="Nit" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Fecha" HeaderText="Cita" ItemStyle-Width="150"
                    DataFormatString="{0:dd/MM/yyyy}">
                    <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="HoraInicio" DataFormatString="{0:H:mm}" HeaderText="Hora de inicio" />
                <asp:BoundField DataField="HoraFin" DataFormatString="{0:H:mm}" HeaderText="Hora de fin" />
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
        ¿Desea eliminar una cita reservada?<br />
        Seleccione el Nit<br />
        <asp:DropDownList ID="NitDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="NitDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        Seleccione la fecha<br />
        <asp:DropDownList ID="FechaDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="EliminarButton" runat="server" OnClick="EliminarButton_Click" Text="Eliminar" />
        <br />
    </div>
    
</asp:Content>
