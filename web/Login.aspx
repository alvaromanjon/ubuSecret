<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    <div class="container">
        <h1>Inicio de sesión</h1>
        <div class="mb-3">
            <label for="mail" class="form-label">Correo electrónico</label>
            <input type="text" class="form-control" id="mail" placeholder="Correo electrónico">
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Contraseña</label>
            <input type="password" class="form-control" id="password" placeholder="Contraseña">
        </div>

        <p><a runat="server" href="Login.aspx" class="btn btn-primary">Iniciar sesión</a> <a runat="server" href="Registro.aspx" class="btn btn-danger">Cancelar</a></p>
    </div>

</asp:Content>