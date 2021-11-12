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
        Secreto s1a;
        Secreto s1b;
        Secreto s2a;

        [TestInitialize()]
        public void InicializaMetodos()
        {
            data = new DBPruebas();
            this.u1a = new Usuario("Admin", "u1a@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            this.u1b = new Usuario("Admin2", "u1a@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            this.u2a = new Usuario("Normal", "u2a@ubusecret.es", "Password", Roles.USUARIO);

            this.s1a = new Secreto(u1a, "Secreto1", "Secreto de prueba");
            this.s1b = new Secreto(u1a, "Secreto1", "Esto es un secreto repetido");
            this.s2a = new Secreto(u1a, "Secreto2", "Otro secreto");
        }

        [TestMethod()]
        public void DBPruebasComprobacion()
        {
            Assert.AreEqual(this.data.NumeroUsuarios(), 2);
            Assert.AreEqual(this.data.SiguienteUsuario(), 3);
            Assert.AreEqual(this.data.NumeroSecretos(), 1);
            Assert.AreEqual(this.data.SiguienteSecreto(), 2);
        }

        [TestMethod()]
        public void CompruebaInsertarUsuarios()
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

        [TestMethod()]
        public void CompruebaInsertarSecretos()
        { 
            Assert.AreEqual(-1, s1a.IdSecreto);
            Assert.IsFalse(data.InsertaSecreto(s1a));
            data.InsertaUsuario(u1a);
            Assert.IsTrue(data.InsertaSecreto(s1a));
            Assert.AreEqual(2, s1a.IdSecreto);

            Assert.AreEqual(-1, s1b.IdSecreto);
            Assert.IsFalse(data.InsertaSecreto(s1b));
            Assert.AreEqual(-1, s1b.IdSecreto);
        }

        [TestMethod()]
        public void CompruebaSecretos()
        {
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.LeeSecreto(s1a.IdSecreto), s1a);
            Assert.AreEqual(data.LeeSecreto(s1a.Nombre), s1a);
        }

        [TestMethod()]
        public void CompruebaActualizacionUsuario()
        {
            int idUsuario = 0;
            data.InsertaUsuario(u1a);
            idUsuario = u1a.IdUsuario;
            u1a.DarAlta(u1a);
            u1a.CambiarContraseña("Password", "P@ssword");
            Assert.IsFalse(data.ActualizaUsuario(u1b));
            Assert.IsTrue(data.ActualizaUsuario(u1a));
            Assert.AreEqual(data.LeeUsuario(idUsuario), u1a);
        }

        [TestMethod()]
        public void CompruebaActualizacionSecreto()
        {
            int idSecreto = 0;
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            idSecreto = s1a.IdSecreto;
            s1a.Texto = "Cambio de texto del secreto";
            Assert.IsFalse(data.ActualizaSecreto(s1b));
            Assert.IsTrue(data.ActualizaSecreto(s1a));
            Assert.AreEqual(data.LeeSecreto(idSecreto), s1a);
        }

        [TestMethod()]
        public void CompruebaBorrarUsuarios()
        {
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            Assert.IsNotNull(data.LeeUsuario(u1a.IdUsuario));
            Assert.IsNotNull(data.LeeUsuario(u2a.IdUsuario));
            Assert.IsNotNull(data.LeeSecreto(s1a.IdSecreto));
            Assert.IsNotNull(data.LeeSecreto(s2a.IdSecreto));
            data.BorraUsuario(u1a.Correo);
            data.BorraUsuario(u2a.IdUsuario);
            Assert.IsNull(data.LeeUsuario(u1a.IdUsuario));
            Assert.IsNull(data.LeeUsuario(u2a.IdUsuario));
            Assert.IsNull(data.LeeSecreto(s1a.IdSecreto));
            Assert.IsNull(data.LeeSecreto(s2a.IdSecreto));
        }

        [TestMethod()]
        public void CompruebaBorrarSecretos()
        {
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            Assert.IsNotNull(data.LeeSecreto(s1a.IdSecreto));
            Assert.IsNotNull(data.LeeSecreto(s2a.IdSecreto));
            data.BorraSecreto(s1a.Nombre);
            data.BorraSecreto(s2a.IdSecreto);
            Assert.IsNull(data.LeeSecreto(s1a.IdSecreto));
            Assert.IsNull(data.LeeSecreto(s2a.IdSecreto));
        }
    }
}
