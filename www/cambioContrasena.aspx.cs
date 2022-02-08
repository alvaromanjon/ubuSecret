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
    public partial class WebForm6 : System.Web.UI.Page
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

            uAutenticado = (Usuario)Session["uAutenticado"];
            if (uAutenticado == null)
            {
                Server.Transfer("inicioSesion.aspx");
            }

            lblUsuario.Text = uAutenticado.Correo;

            if (!IsPostBack)
            {
                this.lblContraseñaAntiguaError.Text = "";
                this.lblRepetirContraseñaError.Text = "";
                this.lblPregunta1Error.Text = "";
                this.lblPregunta2Error.Text = "";
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            if (this.tbxContraseñaAntigua.Text != "" && uAutenticado.CompruebaContraseña(this.tbxContraseñaAntigua.Text))
            {
                this.lblContraseñaAntiguaError.Text = "";
                if (this.tbxNuevaContraseña.Text != "" && this.tbxNuevaContraseña.Text.Equals(this.tbxRepetirNuevaContraseña.Text))
                {
                    this.lblRepetirContraseñaError.Text = "";
                    if (this.tbxPreguntaSeguridad1.Text != "" && uAutenticado.CompruebaPreguntaSeguridad(this.tbxPreguntaSeguridad1.Text, 1))
                    {
                        this.lblPregunta1Error.Text = "";
                        if (this.tbxPreguntaSeguridad2.Text != "" && uAutenticado.CompruebaPreguntaSeguridad(this.tbxPreguntaSeguridad2.Text, 2))
                        {
                            this.lblPregunta2Error.Text = "";
                            uAutenticado.CambiarContraseña(tbxContraseñaAntigua.Text, tbxNuevaContraseña.Text);
                            Server.Transfer("cambioContrasenaExitoso.aspx");
                        }
                        else
                        {
                            this.lblPregunta2Error.Text = "La segunda pregunta de seguridad no coincide";
                        }
                    }
                    else
                    {
                        this.lblPregunta1Error.Text = "La primera pregunta de seguridad no coincide";
                    }
                }
                else 
                {
                    this.lblRepetirContraseñaError.Text = "Las contraseñas no coinciden";
                }
            }
            else
            {
                this.lblContraseñaAntiguaError.Text = "La contraseña no es correcta";
            }
        }
    }
}