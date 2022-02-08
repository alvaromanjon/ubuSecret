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
    public partial class WebForm8 : System.Web.UI.Page
    {
        Usuario uAutenticado = null;
        Secreto s = null;
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

            if (!IsPostBack)
            {
                this.lblDestinatarioError.Text = "";
                this.lblSecretoError.Text = "";
            }
        }

        protected void btnCreacionSecretos_Click(object sender, EventArgs e)
        {
            if (db.LeeUsuario(this.tbxDestinatario.Text) != null)
            {
                this.lblDestinatarioError.Text = "";
                if (this.tbxSecreto.Text.Length <= 255)
                {
                    if (this.tbxTitulo.Text != "" && this.tbxSecreto.Text != "")
                    {
                        this.lblSecretoError.Text = "";
                        s = new Secreto(db.LeeUsuario(tbxDestinatario.Text), tbxTitulo.Text, tbxSecreto.Text);
                        db.InsertaSecreto(s);
                        Server.Transfer("panel.aspx");
                    }
                    else
                    {
                        this.lblSecretoError.Text = "El secreto y/o título están vacíos";
                    }
                }
                else
                {
                    this.lblSecretoError.Text = "El secreto supera los 255 caracteres de longitud";
                }
            }
            else
            {
                this.lblDestinatarioError.Text = "El usuario no está registrado o no existe";
            }

        }

        protected void btnPanel_Click(object sender, EventArgs e)
        {
            Server.Transfer("panel.aspx");
        }
    }
}