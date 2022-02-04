<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicioSesion.aspx.cs" Inherits="www.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 35px;
        }
        .auto-style2 {
            width: 391px;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style5 {
            width: 391px;
            text-align: center;
        }
        .auto-style6 {
            margin-left: 34px;
        }
        .auto-style8 {
            width: 53px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3" colspan="3">
                        <asp:Label ID="lblTituloInicioSesion" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" Text="Inicio de sesión - UBUSecreet"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Text="Usuario"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblUsuarioError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3" colspan="3">
                        <asp:TextBox ID="tbxUsuario" runat="server" CssClass="auto-style6" Width="460px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style3" colspan="3"></td>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblContraseña" runat="server" Font-Bold="True" Text="Contraseña"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Label ID="lblContraseñaError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3" colspan="3">
                        <asp:TextBox ID="tbxContraseña" runat="server" CssClass="auto-style6" TextMode="Password" Width="460px"></asp:TextBox>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                    <td class="auto-style8"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style1"></td>
                    <td class="auto-style2"></td>
                    <td class="auto-style1"></td>
                    <td></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3" colspan="3">
                        <asp:Label ID="lblInicioError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3" colspan="3">
                        <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión" Width="199px" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style3" colspan="3">
                        <asp:Button ID="btnInicio" runat="server" Text="&lt;&lt; Volver al inicio" Width="231px" OnClick="btnInicio_Click" />
                    </td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
