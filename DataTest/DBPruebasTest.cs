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
            this.u1a = new Usuario("Admin", "u1a@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            //data.InsertaUsuario(u1a);
            //u1a.DarAlta(u1a);
            //u1a.CambiarContraseña("Password", "P@ssword");
            //data.ActualizaUsuario(u1a);

            this.u1b = new Usuario("Admin2", "u1a@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            //data.InsertaUsuario(u1b);
            //u1b.DarAlta(u1a);
            //u1b.CambiarContraseña("Password", "P@ssword");
            //data.ActualizaUsuario(u1b);

            this.u2a = new Usuario("Normal", "u2a@ubusecret.es", "Password", Roles.USUARIO);
            //data.InsertaUsuario(u2a);
            //u2a.DarAlta(u1a);
            //u2a.CambiarContraseña("Password", "P@ssword");
            //data.ActualizaUsuario(u2a);
        }

        [TestMethod()]
        public void DBPruebasComprobacion()
        {
            Assert.AreEqual(this.data.NumeroUsuarios(), 2);
            Assert.AreEqual(this.data.SiguienteUsuario(), 3);
            Assert.AreEqual(this.data.NumeroSecretos(), 1);
        }

        [TestMethod()]
        public void InsertaUsuarioTest()
        {
            Assert.AreEqual(-1, u1a.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1a.Estado);
            Assert.IsTrue(data.InsertaUsuario(u1a));
            Assert.AreEqual(3, u1a.IdUsuario);
            Assert.AreEqual(Estados.SOLICITADO, u1a.Estado);

            Assert.AreEqual(-1, u1b.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1b.Estado);
            Assert.IsFalse(data.InsertaUsuario(u1b));
            Assert.AreEqual(-1, u1b.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1b.Estado);
        }

        [TestMethod()]
        public void CompruebaUsuarios()
        {
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.LeeUsuario(u1a.Correo), u1a);
            Assert.AreEqual(data.LeeUsuario(u1a.IdUsuario), u1a);
        }

    }
}
