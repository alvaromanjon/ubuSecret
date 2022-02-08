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
    public partial class WebForm4 : System.Web.UI.Page
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

            this.lblUsuario.Text = uAutenticado.Correo;
            this.lblNumSecretos.Text = "Número de secretos: " + db.NumeroSecretos();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            uAutenticado = null;
            Session["uAutenticado"] = uAutenticado;
            Server.Transfer("inicioSesion.aspx");
        }

        protected void btnCrearSecreto_Click(object sender, EventArgs e)
        {
            Server.Transfer("crearSecreto.aspx");
        }
    }
}