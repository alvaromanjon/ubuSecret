using Microsoft.VisualStudio.TestTools.UnitTesting;
using libreriaClases;
using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaClases.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        Usuario u1a;
        Usuario u2a;

        [TestInitialize()]
        public void InicializaMetodos()
        {
            u1a = new Usuario("Pepe", "pepepepez@ubu.es", "Password", "Maristas", "18", Roles.USUARIO);
            u2a = new Usuario("Pepa", "pepapepez@ubu.es", "Password", "Jesuitas", "13", Roles.USUARIO);
        }

        [TestMethod()]
        public void UsuarioTest()
        {
            u1a.IdUsuario = 9999;
            Assert.AreEqual(u1a.IdUsuario, 9999);
        }

        [TestMethod()]
        public void CambiarRolTest()
        {
            u1a.CambiarRol(Roles.ADMINISTRADOR);
            Assert.AreEqual(u1a.Rol, Roles.ADMINISTRADOR);
        }

        [TestMethod()]
        public void CargarTest()
        {
            Assert.AreEqual(u1a.Estado, Estados.PRECARGADO);
            u1a.Cargar();
            Assert.AreEqual(u1a.Estado, Estados.SOLICITADO);
        }

        [TestMethod()]
        public void DarAltaTest()
        {
            Assert.IsFalse(u2a.DarAlta(u2a));
            u1a.CambiarRol(Roles.ADMINISTRADOR);
            Assert.IsFalse(u2a.DarAlta(u1a));
            u2a.Cargar();
            Assert.IsFalse(u2a.DarAlta(u1a));
            u2a.CambiarContraseña(u2a.Contraseña, "Password2");
            Assert.IsTrue(u2a.DarAlta(u1a));
        }

        [TestMethod()]
        public void CambiarContraseñaTest()
        {
            Assert.IsFalse(u1a.CambiarContraseña("P1ssword", "Password2"));
            Assert.IsFalse(u1a.CambiarContraseña("Password", null));
            Assert.IsFalse(u1a.CambiarContraseña("Password", "Password"));
            Assert.IsTrue(u1a.CambiarContraseña("Password", "Password2"));
        }

        [TestMethod()]
        public void CompruebaContraseñaTest()
        {
            Assert.IsFalse(u1a.CompruebaContraseña(null));
            Assert.IsFalse(u1a.CompruebaContraseña("P1ssword"));
            Assert.IsTrue(u1a.CompruebaContraseña("Password"));
        }

        [TestMethod()]
        public void CompruebaPreguntaSeguridadTest()
        {
            Assert.IsFalse(u1a.CompruebaPreguntaSeguridad(null, 1));
            Assert.IsFalse(u1a.CompruebaPreguntaSeguridad("Maristas", 0));
            Assert.IsFalse(u1a.CompruebaPreguntaSeguridad("Maristas", 3));
            Assert.IsFalse(u1a.CompruebaPreguntaSeguridad("Maristas", 2));
            Assert.IsTrue(u1a.CompruebaPreguntaSeguridad("Maristas", 1));
            Assert.IsTrue(u1a.CompruebaPreguntaSeguridad("18", 2));
        }
    }
}