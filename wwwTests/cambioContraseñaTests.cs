using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace wwwTests
{
    [TestClass]
    public class cambioContraseñaTests
    {
        private static IWebDriver driver;

        [TestMethod]
        public void TheCambioContraseñaEdgeTest()
        {
            driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/registro");
            driver.FindElement(By.Id("tbxNombre")).Clear();
            driver.FindElement(By.Id("tbxNombre")).SendKeys("Pepe");
            driver.FindElement(By.Id("tbxCorreo")).Clear();
            driver.FindElement(By.Id("tbxCorreo")).SendKeys("pepe@pepeperez.com");
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("pepe");
            driver.FindElement(By.Id("tbxRepetirContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirContraseña")).SendKeys("pepe");
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).SendKeys("Maristas");
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).SendKeys("21");
            driver.FindElement(By.Id("btnRegistro")).Click();
            driver.FindElement(By.Id("btnCambioContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("pepo");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("La contraseña no es correcta", driver.FindElement(By.Id("lblContraseñaAntiguaError")).Text);

            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("pepe");
            driver.FindElement(By.Id("tbxNuevaContraseña")).Click();
            driver.FindElement(By.Id("tbxNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxNuevaContraseña")).SendKeys("pepo");
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("Las contraseñas no coinciden", driver.FindElement(By.Id("lblRepetirContraseñaError")).Text);

            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("pepe");
            driver.FindElement(By.Id("tbxNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).SendKeys("Uno");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("La primera pregunta de seguridad no coincide", driver.FindElement(By.Id("lblPregunta1Error")).Text);

            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("pepe");
            driver.FindElement(By.Id("tbxNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).SendKeys("Maristas");
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).SendKeys("1");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("La segunda pregunta de seguridad no coincide", driver.FindElement(By.Id("lblPregunta2Error")).Text);
        }

        [TestMethod]
        public void TheCambioContraseñaChromeTest()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/registro");
            driver.FindElement(By.Id("tbxNombre")).Clear();
            driver.FindElement(By.Id("tbxNombre")).SendKeys("Manolo");
            driver.FindElement(By.Id("tbxCorreo")).Clear();
            driver.FindElement(By.Id("tbxCorreo")).SendKeys("manolo@manolito.com");
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("manolo");
            driver.FindElement(By.Id("tbxRepetirContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirContraseña")).SendKeys("manolo");
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).SendKeys("Maristas");
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).SendKeys("21");
            driver.FindElement(By.Id("btnRegistro")).Click();
            driver.FindElement(By.Id("btnCambioContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("pepo");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("La contraseña no es correcta", driver.FindElement(By.Id("lblContraseñaAntiguaError")).Text);

            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("manolo");
            driver.FindElement(By.Id("tbxNuevaContraseña")).Click();
            driver.FindElement(By.Id("tbxNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxNuevaContraseña")).SendKeys("pepo");
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("Las contraseñas no coinciden", driver.FindElement(By.Id("lblRepetirContraseñaError")).Text);

            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("manolo");
            driver.FindElement(By.Id("tbxNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).SendKeys("Uno");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("La primera pregunta de seguridad no coincide", driver.FindElement(By.Id("lblPregunta1Error")).Text);

            driver.FindElement(By.Id("tbxContraseñaAntigua")).Click();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).Clear();
            driver.FindElement(By.Id("tbxContraseñaAntigua")).SendKeys("manolo");
            driver.FindElement(By.Id("tbxNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirNuevaContraseña")).SendKeys("pepa");
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad1")).SendKeys("Maristas");
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).Clear();
            driver.FindElement(By.Id("tbxPreguntaSeguridad2")).SendKeys("1");
            driver.FindElement(By.Id("btnCambiarContraseña")).Click();
            Assert.AreEqual("La segunda pregunta de seguridad no coincide", driver.FindElement(By.Id("lblPregunta2Error")).Text);
        }
    }
}
