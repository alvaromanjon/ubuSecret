<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="web.Registro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    <div class="container">
        <h1>Registro</h1>
        <div class="mb-3">
            <label for="name" class="form-label">Nombre</label>
            <input type="text" class="form-control" id="name" placeholder="Nombre">
        </div>
        <div class="mb-3">
            <label for="mail" class="form-label">Correo electrónico</label>
            <input type="text" class="form-control" id="mail" placeholder="Correo electrónico">
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Contraseña</label>
            <input type="password" class="form-control" id="password" placeholder="Contraseña">
        </div>
        </br>

        <label for="rol" class="form-label">Rol escogido</label>
        <asp:DropDownList ID="rol" runat="server">
            <asp:ListItem Text= "Usuario" Value="1"></asp:ListItem>
            <asp:ListItem Text= "Administrador" Value="2"></asp:ListItem>
        </asp:DropDownList>
        
        </br>
        <p><a runat="server" href="Registro.aspx" class="btn btn-primary">Registrarse</a> <a runat="server" href="Default.aspx" class="btn btn-danger">Cancelar</a></p>
    </div>

</asp:Content>
