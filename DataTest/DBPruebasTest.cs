using Data;
using libreriaClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataTest
{
    [TestClass]
    public class DBPruebasTest
    {
        DBPruebas data;
        Usuario u1a;
        Usuario u1b;
        Usuario u2a;

        [TestInitialize()]
        public void InicializaMetodos()
        {
            data = new DBPruebas();
            this.u1a = new Usuario("Admin", "admin@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            data.InsertaUsuario(u1a);
            u1a.DarAlta(u1a);
            u1a.CambiarContraseña("Password", "P@ssword");
            data.ActualizaUsuario(u1a);

            this.u1b = new Usuario("Admin2", "admin@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            data.InsertaUsuario(u1b);
            u1b.DarAlta(u1a);
            u1b.CambiarContraseña("Password", "P@ssword");
            data.ActualizaUsuario(u1b);

            this.u2a = new Usuario("Normal", "normal@ubusecret.es", "Password", Roles.USUARIO);
            data.InsertaUsuario(u2a);
            u2a.DarAlta(u1a);
            u2a.CambiarContraseña("Password", "P@ssword");
            data.ActualizaUsuario(u2a);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
