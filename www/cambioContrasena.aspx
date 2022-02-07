<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambioContrasena.aspx.cs" Inherits="www.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style5 {
            text-align: center;
        }
        .auto-style7 {
            width: 528px;
        }
        .auto-style8 {
            width: 528px;
            height: 40px;
        }
        .auto-style9 {
            height: 40px;
        }
        .auto-style10 {
            width: 788px;
        }
        .auto-style11 {
            height: 40px;
            width: 788px;
        }
        .auto-style12 {
            width: 214px;
        }
        .auto-style13 {
            height: 40px;
            width: 214px;
        }
        .auto-style14 {
            width: 788px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style5" colspan="5">
                        <asp:Label ID="lblTituloCambioContraseña" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Cambio de contraseña - UBUSecreet"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblTituloUsuario" runat="server" Font-Bold="True" Text="Usuario"></asp:Label>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style11">
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style13">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style11">
                        <asp:Label ID="lblContraseñaAntigua" runat="server" Font-Bold="True" Text="Contraseña antigua"></asp:Label>
                    </td>
                    <td class="auto-style13">
                        <asp:Label ID="lblContraseñaAntiguaError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td class="auto-style9"></td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="tbxContraseñaAntigua" runat="server" TextMode="Password" Width="690px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblNuevaContraseña" runat="server" Font-Bold="True" Text="Contraseña nueva"></asp:Label>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="tbxNuevaContraseña" runat="server" TextMode="Password" Width="690px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblRepetirNuevaContraseña" runat="server" Font-Bold="True" Text="Repite la contraseña nueva"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblRepetirContraseñaError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="tbxRepetirNuevaContraseña" runat="server" TextMode="Password" Width="690px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblPreguntaSeguridad1" runat="server" Font-Bold="True" Text="Pregunta de seguridad 1: ¿A qué colegio ibas?"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblPregunta1Error" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="tbxPreguntaSeguridad1" runat="server" Width="690px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Label ID="lblPreguntaSeguridad2" runat="server" Font-Bold="True" Text="Pregunta de seguridad 2: ¿Cuántos años tienes?"></asp:Label>
                    </td>
                    <td class="auto-style12">
                        <asp:Label ID="lblPregunta2Error" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:TextBox ID="tbxPreguntaSeguridad2" runat="server" Width="690px"></asp:TextBox>
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:Button ID="btnCambiarContraseña" runat="server" Text="Cambiar contraseña" Width="299px" OnClick="btnRegistro_Click" />
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:Button ID="btnInicio" runat="server" Text="&lt;&lt; Volver al inicio" Width="231px" OnClick="btnInicio_Click" />
                    </td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
