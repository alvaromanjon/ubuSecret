<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>UBUSecreet</h1>
        <p class="lead">UBUSecreet es una aplicación que te permite guardar y compartir secretos en la nube.</p>
        <p><a runat="server" href="Login.aspx" class="btn btn-primary btn-lg">Iniciar sesión &raquo;</a> <a runat="server" href="Registro.aspx" class="btn btn-primary btn-lg">Registrarse &raquo;</a></p>
    </div>

</asp:Content>