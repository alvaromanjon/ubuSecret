<%@ Page Title="Inicio de sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>

          <!-- Email input -->
          <div class="form-outline mb-4">
            <label class="form-label" for="correo">Correo electrónico</label>
            <input type="email" id="correo" class="form-control form-control-lg"
              placeholder="Introduce el correo electrónico" />
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
            <label class="form-label" for="contraseña">Contraseña</label>
            <input type="password" id="contraseña" class="form-control form-control-lg"
              placeholder="Introduce la contraseña" />
          </div>
        </br>

        <!-- Login -->
          <div class="text-center text-lg-start mt-2 pt-4">
            <button type="button" class="btn btn-primary btn-lg">Iniciar sesión</button>
          </div>

        </form>
      </div>
    </div>
  </div>

</asp:Content>
