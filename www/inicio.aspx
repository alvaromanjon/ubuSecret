<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="www.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
        .auto-style2 {
            width: 507px;
        }
        .auto-style3 {
            width: 113px;
        }
        .auto-style4 {
            width: 508px;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 507px;
            text-align: center;
        }
        .auto-style7 {
            width: 508px;
            text-align: center;
        }
        .auto-style8 {
            height: 12px;
        }
        .auto-style9 {
            text-align: center;
            height: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style5" colspan="3">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="UBUSecreet"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style5" colspan="3" rowspan="2">
                        <asp:Label ID="lblDescripcion" runat="server" Text="UBUSecreet es una aplicación web para almacenar y compartir secretos con otros usuarios, de manera fácil y segura."></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style5" colspan="3">
                        <asp:Button ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" Text="Iniciar sesión" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9" colspan="3"></td>
                    <td class="auto-style8"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style5" colspan="3">
                        <asp:Button ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" Text="Registrarse" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
