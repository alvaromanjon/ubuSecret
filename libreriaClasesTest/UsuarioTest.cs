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
            Assert.IsTrue(u1a.Rol == Roles.ADMINISTRADOR);
        }
    }
}
