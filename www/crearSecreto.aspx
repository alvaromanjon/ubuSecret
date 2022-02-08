<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearSecreto.aspx.cs" Inherits="www.WebForm8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style4 {
            text-align: center;
        }
        .auto-style5 {
            width: 6px;
        }
        .auto-style7 {
            width: 8px;
        }
        .auto-style9 {
            width: 111px;
        }
        .auto-style11 {
            height: 40px;
        }
        .auto-style13 {
            width: 6px;
            height: 40px;
        }
        .auto-style14 {
            width: 111px;
            height: 40px;
        }
        .auto-style15 {
            width: 8px;
            height: 40px;
        }
        .auto-style18 {
            text-align: left;
        }
        .auto-style19 {
            width: 10px;
            height: 40px;
        }
        .auto-style20 {
            width: 10px;
        }
        .auto-style21 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style4" colspan="7">
                        <asp:Label ID="lblTituloSecretos" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Creación de secretos - UBUSecreet"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style19"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style13"></td>
                    <td class="auto-style14"></td>
                    <td class="auto-style15"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Label ID="lblDestinatario" runat="server" Font-Bold="True" Text="Destinatario"></asp:Label>
                    </td>
                    <td class="auto-style21" colspan="2">
                        <asp:Label ID="lblDestinatarioError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:TextBox ID="tbxDestinatario" runat="server" Width="586px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Text="Título"></asp:Label>
                    </td>
                    <td class="auto-style4" colspan="2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:TextBox ID="tbxTitulo" runat="server" Width="586px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style18">
                        <asp:Label ID="lblSecreto" runat="server" Font-Bold="True" Text="Secreto"></asp:Label>
                    </td>
                    <td class="auto-style21" colspan="2">
                        <asp:Label ID="lblCaracteres" runat="server" Text="Máximo 255 caracteres"></asp:Label>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:TextBox ID="tbxSecreto" runat="server" TextMode="MultiLine" Width="586px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:Label ID="lblSecretoError" runat="server" Font-Bold="True" ForeColor="Red" Text="Error"></asp:Label>
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4" colspan="2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:Button ID="btnCreacionSecretos" runat="server" Text="Crear un secreto" Width="231px" OnClick="btnCreacionSecretos_Click" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4" colspan="2">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td class="auto-style20">&nbsp;</td>
                    <td class="auto-style4" colspan="3">
                        <asp:Button ID="btnPanel" runat="server" Text="&lt;&lt; Volver al panel" Width="231px" OnClick="btnPanel_Click" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
