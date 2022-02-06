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
    public partial class WebForm1 : System.Web.UI.Page
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
                this.lblUsuarioError.Text = "";
                this.lblContraseñaError.Text = "";
                this.lblInicioError.Text = "";
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (this.db.ExisteUsuarioEMail(this.tbxUsuario.Text))
            {
                this.lblUsuarioError.Text = "";
                uAutenticado = this.db.LeeUsuario(this.tbxUsuario.Text);
                if (uAutenticado != null && uAutenticado.CompruebaContraseña(this.tbxContraseña.Text))
                {
                    this.lblContraseñaError.Text = "";

                    if (uAutenticado.Estado.Equals(Estados.VALIDADO))
                    {
                        Session["uAutenticado"] = uAutenticado;
                        Server.Transfer("panel.aspx"); 
                    }
                    else
                    {
                        this.lblInicioError.Text = "El usuario no se encuentra autorizado";
                    }
                    
                }
                else
                {
                    this.lblContraseñaError.Text = "La contraseña es incorrecta";
                }
            }
            else
            {
                this.lblUsuarioError.Text = "Este mail no es válido o no existe el usuario";
            }
        }
    }
}