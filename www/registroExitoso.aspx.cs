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
                Server.Transfer("inicioSesion.aspx");
            }

            lblDescripcionRegistro.Text = "El usuario " + uAutenticado.Correo + " acaba de ser registrado en el sistema, ahora deberá de esperar a que un administrador acepte la solicitud, y a continuación deberá de cambiar la contraseña antes de poder iniciar sesión.";
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}