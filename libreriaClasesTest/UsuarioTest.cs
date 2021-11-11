using libreriaClases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace libreriaClasesTest
{
    [TestClass]
    public class UsuarioTest
    {
        Usuario u1a;
        Usuario u2a;

        [TestInitialize()]
        public void InicializaMetodos()
        {
            u1a = new Usuario("Pepe", "pepepepez@ubu.es", "Password", Roles.USUARIO);
            u2a = new Usuario("Pepa", "pepapepez@ubu.es", "Password", Roles.USUARIO);
        }
        
        [TestMethod()]
        public void CompruebaCambioRol()
        {
            u1a.CambiarRol(Roles.ADMINISTRADOR);
            Assert.AreEqual(u1a.Rol, Roles.ADMINISTRADOR);
        }

        [TestMethod()]
        public void CompruebaDarAlta()
        {
            Assert.IsFalse(u2a.DarAlta(u2a));
            Assert.IsFalse(u2a.DarAlta(u1a));
            u2a.Cargar();
            Assert.AreEqual(u2a.Estado, Estados.SOLICITADO);
            u2a.CambiarContraseña(u2a.Contraseña, "Password2");
            Assert.IsTrue(u2a.CompruebaContraseña("Password2"));
            Assert.IsTrue(u2a.DarAlta(u1a));
        }
    }
}
