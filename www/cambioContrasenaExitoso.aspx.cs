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
    public partial class WebForm7 : System.Web.UI.Page
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

            lblDescripcionCambio.Text = "El usuario " + uAutenticado.Correo + " ha cambiado la contraseña con éxito, ahora deberá de esperar a que un administrador autorice su acceso para poder iniciar sesión.";
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }
    }
}