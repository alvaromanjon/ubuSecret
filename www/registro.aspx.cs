using Data;
using libreriaClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Usuario uAutenticado = null;
        DBPruebas db = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = (DBPruebas)Application["Datos"];
            if (db == null)
            {
                db = new DBPruebas();
                Application["Datos"] = db;
            }

            Session["uAutenticado"] = uAutenticado;

            if (!IsPostBack)
            {
                this.lblCorreoError.Text = "";
                this.lblRepetirContraseñaError.Text = "";
                this.lblRegistroError.Text = "";
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {

            if (!this.db.ExisteUsuarioEMail(this.tbxCorreo.Text) && this.tbxCorreo.Text != "")
            {
                this.lblCorreoError.Text = "";
                if (this.tbxContraseña.Text != "" && this.tbxContraseña.Text.Equals(this.tbxRepetirContraseña.Text))
                {
                    this.lblRepetirContraseñaError.Text = "";
                    if (this.tbxNombre.Text != "" && this.tbxCorreo.Text != "" 
                        && this.tbxPreguntaSeguridad1.Text != "" && this.tbxPreguntaSeguridad2.Text != "")
                    {
                        this.lblRegistroError.Text = "";
                        uAutenticado = new Usuario(tbxNombre.Text, tbxCorreo.Text, tbxContraseña.Text, tbxPreguntaSeguridad1.Text, tbxPreguntaSeguridad2.Text, Roles.USUARIO);
                        db.InsertaUsuario(uAutenticado);
                        Session["uAutenticado"] = uAutenticado;
                        Response.Redirect("registroExitoso.aspx");
                    }
                    else
                    {
                        this.lblRegistroError.Text = "Uno o varios de los campos están vacíos";
                    }
                    
                }
                else
                {
                    this.lblRepetirContraseñaError.Text = "Las contraseñas no coinciden";
                }
            }
            else
            {
                this.lblCorreoError.Text = "El correo no es válido o ya existe un usuario registrado con este correo";
            }
        }
    }
}