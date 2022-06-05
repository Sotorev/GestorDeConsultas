<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_final.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body class="col-sm-8 xyz text-center" style="margin-top:250px; background: linear-gradient(90deg, rgba(0,231,245,1) 0%, rgba(46,202,238,1) 45%, rgba(0,255,230,1) 100%);">
    <p class="h4 mb-4 text-left" style="color:aliceblue; font-size:24px; text-align:center">Ingresar para continuar</p>
    <div style="margin: auto;max-width:250px; color:aliceblue">
        <form id="form1" runat="server">
        <div>
        </div>
        <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="Login1_Authenticate" >
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </form>
    </div>
</body>
</html>
