using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System;
using System.Collections.Generic;
using System.Text;
using libreriaClases;
using System.Linq;

namespace DataTests
{
    [TestClass()]
    public class DBPruebasTests
    {
        DBPruebas data;
        Usuario u1a;
        Usuario u1b;
        Usuario u2a;
        Secreto s1a;
        Secreto s1b;
        Secreto s2a;
        Secreto s3a;

        [TestInitialize()]
        public void InicializaMetodos()
        {
            data = new DBPruebas();
            this.u1a = new Usuario("Admin", "u1a@ubusecret.es", "Password", "Maristas", "18", Roles.ADMINISTRADOR);
            this.u1b = new Usuario("Admin2", "u1a@ubusecret.es", "Password", "Mendoza", "16", Roles.ADMINISTRADOR);
            this.u2a = new Usuario("Normal", "u2a@ubusecret.es", "Password", "Zapatito", "20", Roles.USUARIO);

            this.s1a = new Secreto(u1a, "Secreto1", "Secreto de prueba");
            this.s1b = new Secreto(u1a, "Secreto1", "Esto es un secreto repetido");
            this.s2a = new Secreto(u1a, "Secreto2", "Otro secreto");
            this.s3a = new Secreto(u2a, "Secreto3", "Otro secreto con distinto usuario");
        }

        [TestMethod()]
        public void DBPruebasTest()
        {
            Assert.AreEqual(this.data.NumeroUsuarios(), 2);
            Assert.AreEqual(this.data.SiguienteUsuario(), 3);
            Assert.AreEqual(this.data.NumeroSecretos(), 1);
            Assert.AreEqual(this.data.SiguienteSecreto(), 2);
        }

        [TestMethod()]
        public void ActualizaSecretoTest()
        {
            int idSecreto = 0;
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            idSecreto = s1a.IdSecreto;
            s1a.Texto = "Cambio de texto del secreto";
            Assert.IsFalse(data.ActualizaSecreto(s2a));
            Assert.IsTrue(data.ActualizaSecreto(s1a));
            Assert.AreEqual(data.LeeSecreto(idSecreto), s1a);
        }

        [TestMethod()]
        public void ActualizaUsuarioTest()
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
        public void BorraSecretoTest()
        {
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            Assert.IsTrue(data.BorraSecreto(u1a, s1a.Nombre));
            Assert.IsTrue(data.NumeroSecretos() == 2);
        }

        [TestMethod()]
        public void BorraSecretoTest1()
        {
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            Assert.IsTrue(data.BorraSecreto(s1a.IdSecreto));
            Assert.IsTrue(data.NumeroSecretos() == 2);
        }

        [TestMethod()]
        public void BorraUsuarioTest()
        {
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            Assert.IsTrue(data.BorraUsuario(u1a.Correo));
            Assert.IsTrue(data.NumeroSecretos() == 1);
            Assert.IsTrue(data.NumeroUsuarios() == 3);
        }

        [TestMethod()]
        public void BorraUsuarioTest1()
        {
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            Assert.IsTrue(data.BorraUsuario(u1a.IdUsuario));
            Assert.IsTrue(data.NumeroSecretos() == 1);
            Assert.IsTrue(data.NumeroUsuarios() == 3);
        }

        [TestMethod()]
        public void ExisteUsuarioEMailTest()
        {
            data.InsertaUsuario(u1a);
            Assert.IsFalse(data.ExisteUsuarioEMail("pepitoperez@ubusecret.es"));
            Assert.IsTrue(data.ExisteUsuarioEMail("u1a@ubusecret.es"));
        }

        [TestMethod()]
        public void InsertaSecretoTest()
        {
            Assert.AreEqual(-1, s1a.IdSecreto);
            Assert.IsFalse(data.InsertaSecreto(s1a));
            data.InsertaUsuario(u1a);
            Assert.IsTrue(data.InsertaSecreto(s1a));
            Assert.AreEqual(2, s1a.IdSecreto);
            Assert.IsTrue(data.NumeroSecretos() == 2);
            Assert.IsFalse(data.InsertaSecreto(s1b));
            Assert.IsTrue(data.NumeroSecretos() == 2);
        }

        [TestMethod()]
        public void InsertaUsuarioTest()
        {
            Assert.AreEqual(-1, u1a.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1a.Estado);
            Assert.IsTrue(data.InsertaUsuario(u1a));
            Assert.AreEqual(3, u1a.IdUsuario);
            Assert.AreEqual(Estados.SOLICITADO, u1a.Estado);
            Assert.IsTrue(data.NumeroUsuarios() == 3);
            Assert.IsFalse(data.InsertaUsuario(u1a));
            Assert.IsTrue(data.NumeroUsuarios() == 3);

            Assert.AreEqual(-1, u1b.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1b.Estado);
            Assert.IsFalse(data.InsertaUsuario(u1b));
            Assert.AreEqual(-1, u1b.IdUsuario);
            Assert.AreNotEqual(Estados.SOLICITADO, u1b.Estado);
            Assert.IsTrue(data.NumeroUsuarios() == 3);
        }

        [TestMethod()]
        public void LeeSecretosUsuarioTest()
        {
            SortedList<int, Secreto> secUsuario = new SortedList<int, Secreto>();
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            data.InsertaSecreto(s3a);

            secUsuario.Add(s1a.IdSecreto, s1a);
            secUsuario.Add(s2a.IdSecreto, s2a);

            Assert.IsTrue(Enumerable.SequenceEqual(secUsuario, data.LeeSecretosUsuario(u1a)));
        }

        [TestMethod()]
        public void LeeSecretoTest()
        {
            Assert.IsNull(data.LeeSecreto(u1a, s1a.Nombre));
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.LeeSecreto(u1a, s1a.Nombre), s1a);
            Assert.IsNotNull(data.LeeSecreto(u1a, s1b.Nombre));
            Assert.AreNotEqual(data.LeeSecreto(u1a, s1b.Nombre), s1b);
        }

        [TestMethod()]
        public void LeeSecretoTest1()
        {
            Assert.IsNull(data.LeeSecreto(s1a.IdSecreto));
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.LeeSecreto(s1a.IdSecreto), s1a);
        }

        [TestMethod()]
        public void LeeUsuarioTest()
        {
            Assert.IsNull(data.LeeUsuario(u1a.Correo));
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.LeeUsuario(u1a.Correo), u1a);
        }

        [TestMethod()]
        public void LeeUsuarioTest1()
        {
            Assert.IsNull(data.LeeUsuario(u1a.IdUsuario));
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.LeeUsuario(u1a.IdUsuario), u1a);
        }

        [TestMethod()]
        public void NumeroSecretosTest()
        {
            Assert.AreEqual(data.NumeroSecretos(), 1);
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.NumeroSecretos(), 2);
        }

        [TestMethod()]
        public void NumeroUsuariosTest()
        {
            Assert.AreEqual(data.NumeroUsuarios(), 2);
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.NumeroUsuarios(), 3);
        }

        [TestMethod()]
        public void SiguienteSecretoTest()
        {
            Assert.AreEqual(data.SiguienteSecreto(), 2);
            data.InsertaUsuario(u1a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.SiguienteSecreto(), 3);
        }

        [TestMethod()]
        public void SiguienteUsuarioTest()
        {
            Assert.AreEqual(data.SiguienteUsuario(), 3);
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.SiguienteUsuario(), 4);
        }
    }
}