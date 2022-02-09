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
                Response.Redirect("inicioSesion.aspx");
            }

            this.lblUsuario.Text = uAutenticado.Correo;
            this.lblNumSecretos.Text = "Número de secretos: " + db.NumeroSecretos();

            SortedList<int, Secreto> secUsuarios = db.LeeSecretosUsuario(uAutenticado);
            foreach (KeyValuePair<int, Secreto> kvp in secUsuarios)
            {
                Secretos.InnerHtml += String.Format(@"
                <a href=""secreto.aspx"">
                        <div style=""width: 40%"" >
                            {0}
                        </div>
                        <div style=""width: 60%"" >
                            {1}
                        </div>
                </ a >", kvp.Value.Nombre, kvp.Value.Texto);


            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            uAutenticado = null;
            Session["uAutenticado"] = uAutenticado;
            Response.Redirect("inicioSesion.aspx");
        }

        protected void btnCrearSecreto_Click(object sender, EventArgs e)
        {
            Response.Redirect("crearSecreto.aspx");
        }
    }
}