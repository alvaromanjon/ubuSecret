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
        Usuario u3a;
        Usuario u4a;
        Secreto s1a;
        Secreto s2a;
        Secreto s3a;

        [TestInitialize()]
        public void InicializaMetodos()
        {
            data = new DBPruebas();
            this.u1a = new Usuario("Admin", "u1a@ubusecret.es", "Password", "Maristas", "18", Roles.ADMINISTRADOR);
            this.u1b = new Usuario("Admin2", "u1a@ubusecret.es", "Password", "Mendoza", "16", Roles.ADMINISTRADOR);
            this.u2a = new Usuario("Normal", "u2a@ubusecret.es", "Password", "Zapatito", "20", Roles.USUARIO);
            this.u3a = new Usuario("Normal2", "u3a@ubusecret.es", "Password", "Jesuitas", "21", Roles.USUARIO);
            this.u4a = new Usuario("Normal3", "u4a@ubusecret.es", "Password", "Sagrada Familia", "23", Roles.USUARIO);
            this.s1a = new Secreto(u1a, u2a, "Secreto1", "Secreto de prueba");
            this.s2a = new Secreto(u1a, u2a, "Secreto2", "Otro secreto");
            this.s3a = new Secreto(u2a, u1a, "Secreto3", "Otro secreto con distinto usuario");
        }

        [TestMethod()]
        public void DBPruebasTest()
        {
            Assert.AreEqual(this.data.NumeroUsuarios(), 0);
            Assert.AreEqual(this.data.SiguienteUsuario(), 1);
            Assert.AreEqual(this.data.NumeroSecretos(), 0);
            Assert.AreEqual(this.data.SiguienteSecreto(), 1);
        }

        [TestMethod()]
        public void LeeUsuarioTest()
        {
            Assert.IsNull(data.LeeUsuario(u1a.Correo));
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.LeeUsuario(u1a.Correo), u1a);
        }

        [TestMethod()]
        public void InsertaUsuarioTest()
        {
            Assert.AreEqual(-1, u1a.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1a.Estado);
            Assert.IsTrue(data.InsertaUsuario(u1a));
            Assert.AreEqual(1, u1a.IdUsuario);
            Assert.AreEqual(Estados.SOLICITADO, u1a.Estado);
            Assert.IsTrue(data.NumeroUsuarios() == 1);
            Assert.IsFalse(data.InsertaUsuario(u1a));
            Assert.IsTrue(data.NumeroUsuarios() == 1);

            Assert.AreEqual(-1, u1b.IdUsuario);
            Assert.AreEqual(Estados.PRECARGADO, u1b.Estado);
            Assert.IsFalse(data.InsertaUsuario(u1b));
            Assert.AreEqual(-1, u1b.IdUsuario);
            Assert.AreNotEqual(Estados.SOLICITADO, u1b.Estado);
            Assert.IsTrue(data.NumeroUsuarios() == 1);
        }

        [TestMethod()]
        public void BorraUsuarioTest()
        {
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            data.InsertaSecreto(s3a);

            Assert.AreEqual(data.BorraUsuario(u1a.Correo), u1a);
            Assert.IsNull(data.LeeSecreto(s1a.IdSecreto));
            Assert.IsNull(data.LeeSecreto(s2a.IdSecreto));
            Assert.IsTrue(data.NumeroSecretos() == 1);
            Assert.IsTrue(data.NumeroUsuarios() == 1);
            Assert.AreEqual(data.BorraUsuario(u2a.Correo), u2a);
            Assert.IsNull(data.LeeSecreto(s3a.IdSecreto));
            Assert.IsTrue(data.NumeroSecretos() == 0);
            Assert.IsTrue(data.NumeroUsuarios() == 0);
        }

        [TestMethod()]
        public void LeeUsuariosActivosTest()
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();
            data.InsertaUsuario(u1a);
            u1a.CambiarContraseña("Password", "P@ssword");
            u1a.DarAlta(u1a);
            data.InsertaUsuario(u2a);
            u2a.CambiarContraseña("Password", "P@ssword");
            u2a.DarAlta(u1a);
            data.InsertaUsuario(u3a);
            data.InsertaUsuario(u4a);

            listUsuarios.Add(u1a.IdUsuario, u1a);
            listUsuarios.Add(u2a.IdUsuario, u2a);

            Assert.IsTrue(Enumerable.SequenceEqual(listUsuarios, data.LeeUsuariosActivos()));
        }

        [TestMethod()]
        public void LeeUsuariosInactivosTest()
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();
            data.InsertaUsuario(u1a);
            u1a.CambiarContraseña("Password", "P@ssword");
            u1a.DarAlta(u1a);
            data.InsertaUsuario(u2a);
            u2a.CambiarContraseña("Password", "P@ssword");
            u2a.DarAlta(u1a);
            data.InsertaUsuario(u3a);
            data.InsertaUsuario(u4a);

            //listUsuarios.Add(u1a.IdUsuario, u3a);
            //listUsuarios.Add(u2a.IdUsuario, u4a);

            Assert.IsTrue(Enumerable.SequenceEqual(listUsuarios, data.LeeUsuariosInactivos()));
        }

        [TestMethod()]
        public void LeeUsuariosPendientesTest()
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();
            data.InsertaUsuario(u1a);
            u1a.CambiarContraseña("Password", "P@ssword");
            u1a.DarAlta(u1a);
            data.InsertaUsuario(u2a);
            u2a.CambiarContraseña("Password", "P@ssword");
            u2a.DarAlta(u1a);
            data.InsertaUsuario(u3a);
            data.InsertaUsuario(u4a);

            listUsuarios.Add(u3a.IdUsuario, u3a);
            listUsuarios.Add(u4a.IdUsuario, u4a);

            Assert.IsTrue(Enumerable.SequenceEqual(listUsuarios, data.LeeUsuariosPendientes()));
        }

        [TestMethod()]
        public void LeeSecretosEnviadosUsuarioTest()
        {
            SortedList<int, Secreto> secUsuario = new SortedList<int, Secreto>();
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            data.InsertaSecreto(s3a);

            secUsuario.Add(s1a.IdSecreto, s1a);
            secUsuario.Add(s2a.IdSecreto, s2a);

            Assert.IsTrue(Enumerable.SequenceEqual(secUsuario, data.LeeSecretosEnviadosUsuario(u1a)));
        }

        [TestMethod()]
        public void LeeSecretosRecibidosUsuarioTest()
        {
            SortedList<int, Secreto> secUsuario = new SortedList<int, Secreto>();
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            data.InsertaSecreto(s3a);

            secUsuario.Add(s3a.IdSecreto, s3a);

            Assert.IsTrue(Enumerable.SequenceEqual(secUsuario, data.LeeSecretosRecibidosUsuario(u1a)));
        }

        [TestMethod()]
        public void InsertaSecretoTest()
        {
            Assert.AreEqual(-1, s1a.IdSecreto);
            Assert.IsFalse(data.InsertaSecreto(s1a));
            data.InsertaUsuario(u1a);
            Assert.IsFalse(data.InsertaSecreto(s1a));
            data.InsertaUsuario(u2a);
            Assert.IsTrue(data.InsertaSecreto(s1a));
            Assert.AreEqual(1, s1a.IdSecreto);
            Assert.IsTrue(data.NumeroSecretos() == 1);
        }

        [TestMethod()]
        public void LeeSecretoTest()
        {
            Assert.IsNull(data.LeeSecreto(s1a.IdSecreto));
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.LeeSecreto(s1a.IdSecreto), s1a);
        }

        [TestMethod()]
        public void BorraSecretoTest()
        {
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            data.InsertaSecreto(s2a);
            data.InsertaSecreto(s3a);
            Assert.AreEqual(data.BorraSecreto(s1a.IdSecreto), s1a);
            Assert.IsNull(data.LeeSecreto(s1a.IdSecreto));
            Assert.IsTrue(data.NumeroSecretos() == 2);
        }

        [TestMethod()]
        public void NumeroSecretosTest()
        {
            Assert.AreEqual(data.NumeroSecretos(), 0);
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.NumeroSecretos(), 1);
        }

        [TestMethod()]
        public void NumeroUsuariosTest()
        {
            Assert.AreEqual(data.NumeroUsuarios(), 0);
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.NumeroUsuarios(), 1);
        }

        [TestMethod()]
        public void SiguienteSecretoTest()
        {
            Assert.AreEqual(data.SiguienteSecreto(), 1);
            data.InsertaUsuario(u1a);
            data.InsertaUsuario(u2a);
            data.InsertaSecreto(s1a);
            Assert.AreEqual(data.SiguienteSecreto(), 2);
        }

        [TestMethod()]
        public void SiguienteUsuarioTest()
        {
            Assert.AreEqual(data.SiguienteUsuario(), 1);
            data.InsertaUsuario(u1a);
            Assert.AreEqual(data.SiguienteUsuario(), 2);
        }
    }
}