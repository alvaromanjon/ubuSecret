using Microsoft.VisualStudio.TestTools.UnitTesting;
using libreriaClases;
using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaClases.Tests
{
    [TestClass()]
    public class SecretoTests
    {
        [TestMethod()]
        public void SecretoTest()
        {
            Usuario u = new Usuario("Pepe", "pepepepez@ubu.es", "Password", "Maristas", "18", Roles.USUARIO);
            Secreto s = new Secreto(u, "Secreto de prueba", "Esto es un secreto de prueba");
            s.IdSecreto = 9999;
            Assert.AreEqual(s.IdSecreto, 9999);
            s.Texto = "Cambio de texto";
            Assert.AreEqual(s.Texto, "Cambio de texto");
        }
    }
}