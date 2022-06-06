<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Proyecto_final.Consulta" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron col-lg-6">
        <h1>Consulta</h1>
        <strong>Id de consulta</strong>&nbsp;
    <asp:TextBox ID="IdTextBox" runat="server" AutoCompleteType="Disabled" Enabled="False" EnableTheming="False" EnableViewState="False" ReadOnly="True" Width="16px" Height="20px"></asp:TextBox>
        <br />
        <strong>Paciente</strong><br />
        <asp:DropDownList ID="PacienteDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="PacienteDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        Nit<br />
        <asp:TextBox ID="NitTextBox" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <strong>Fecha y hora de la consulta</strong><br />
        <asp:TextBox ID="FechaConsultaTextBox" runat="server" TextMode="DateTime" ReadOnly="True" Enabled="False"></asp:TextBox>
        <br />
        <strong>Temperatura</strong><br />
        <asp:TextBox ID="TemperaturaTextBox" runat="server" TextMode="Number"></asp:TextBox>

        &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TemperaturaTextBox" ErrorMessage="Ingrese un numero entre 1 y 60" MaximumValue="60" MinimumValue="1" Type="Integer" ForeColor="Red"></asp:RangeValidator>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TemperaturaTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        <strong>Presión</strong><br />
        <asp:TextBox ID="PresionTextBox" runat="server" TextMode="Number"></asp:TextBox>

        &nbsp;<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="PresionTextBox" ErrorMessage="Ingrese un numero entre 1 y 200" MaximumValue="200" MinimumValue="1" Type="Integer" ForeColor="Red"></asp:RangeValidator>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PresionTextBox" Display="Dynamic" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <br />
        Nuevo síntoma<br />
        Codigo
    <asp:TextBox ID="CodigoTextBox" runat="server"></asp:TextBox>
        <br />
        <span style="font-weight: normal">Descripcion</span>
        <asp:TextBox ID="SintomasTextBox" runat="server" Width="128px"></asp:TextBox>
        &nbsp;
    <asp:Button ID="AgregarSintomaButton" runat="server" OnClick="AgregarSintomaButton_Click" Text="Agregar síntoma" CausesValidation="False" />
        <br />
        Síntomas Comúnes<br />
        <asp:DropDownList ID="SintomasDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SintomasDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;<br />
        <br />
        <asp:TextBox ID="DescripcionSintomaTextBox" runat="server" Enabled="False" OnLoad="DescripcionSintomaTextBox_Load"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SintomaComunButton" runat="server" Text="Agregar síntoma común" OnClick="SintomaComunButton_Click" CausesValidation="False" />
        <br />
        <br />
        <asp:GridView ID="SintomasGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
        <span style="font-weight: normal"><strong>Diagnóstico</strong></span><br />
        <asp:TextBox ID="DiagnosticoTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DiagnosticoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

        <br />
        <span style="font-weight: normal"><strong>Tratamiento</strong></span>

        <br />
        <asp:TextBox ID="TratamientoTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TratamientoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

        <br />
        <span style="font-weight: normal"><strong>Receta</strong></span><br />
        Medicamentos<br />
        <asp:DropDownList ID="MedicamentosDropDownList" runat="server">
        </asp:DropDownList>
        &nbsp;<asp:Button ID="MedicamentosButton" runat="server" OnClick="MedicamentosButton_Click" Text="Agregar medicamento" CausesValidation="False" />
        <br />
        <asp:GridView ID="MedicamentosGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
        Dosis<br />
        <asp:TextBox ID="DosisTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>

        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DosisTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

        <br />
        Horario<br />
        <asp:TextBox ID="HorarioTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="HorarioTextBox" ErrorMessage="Campo obligatorio" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

        <br />
        Próxima visita
    <br />
        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged1" />
        <br />
        <div>
            Fecha&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Hora Inicio&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Hora Fin
        <br />
            <asp:TextBox ID="AgendarTextBox" runat="server" TextMode="Date"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="HoraInicioTextBox" runat="server" TextMode="Time"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="HoraFinTextBox" runat="server" TextMode="Time"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="AgendarButton" runat="server" OnClick="AgendarButton_Click" Text="Agendar nueva cita" CausesValidation="False" />
            <br />
        </div>
        <br />
        Costo de consulta<br />
        <asp:DropDownList ID="CostoDropDownList" runat="server">
            <asp:ListItem Value="200">Q.200</asp:ListItem>
            <asp:ListItem Value="150">Q.150</asp:ListItem>
        </asp:DropDownList>
        <br />
        Multimedia<br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        &nbsp;Descripcion imagen
    <asp:TextBox ID="DescripcionMultimediaTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>

        <asp:GridView ID="MultimediaGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" ControlStyle-Height="150px">
<ControlStyle Height="150px"></ControlStyle>
                </asp:ImageField>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
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
        <asp:Button ID="MultimediaButton" runat="server" OnClick="MultimediaButton_Click" Text="Subir imagen" CausesValidation="False" />

        <br />
        <asp:Button ID="GuardarButton" runat="server" OnClick="GuardarButton_Click" Text="Guardar Consulta" Width="165px" />
    </div>
    <div class="col-lg-6">
        <h1>Historial médico</h1>
        Filtrar historial por id de consulta<br />
        <asp:DropDownList ID="FiltroIDDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="FiltroIDDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:GridView ID="HistorialMedicoGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:GridView ID="MultimediaHGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:ImageField DataImageUrlField="Imagen" ControlStyle-Height="150px" HeaderText="Imagen">
<ControlStyle Height="150px"></ControlStyle>
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <asp:GridView ID="RecetaGridView" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
