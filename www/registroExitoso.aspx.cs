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
    public partial class WebForm5 : System.Web.UI.Page
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
                Response.Redirect("inicioSesion.aspx");
            }

            lblDescripcionRegistro.Text = "El usuario " + uAutenticado.Correo + " acaba de ser registrado en el sistema, ahora deberá de cambiar la contraseña, y a continuación, se deberá de esperar a que un administrador acepte su solicitud para poder iniciar sesión en el sistema.";
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void btnCambioContraseña_Click(object sender, EventArgs e)
        {
            Response.Redirect("cambioContrasena.aspx");
        }
    }
}