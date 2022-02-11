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
    public class inicioSesionTests
    {

        private static IWebDriver driver;

        [TestMethod]
        public void TheInicioDeSesionEdgeTest()
        {
            driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/inicioSesion");
            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("ejemplo");
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("prueba");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            Assert.AreEqual("Este mail no es válido o no existe el usuario", driver.FindElement(By.Id("lblUsuarioError")).Text);

            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("prueba");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            Assert.AreEqual("La contraseña es incorrecta", driver.FindElement(By.Id("lblContraseñaError")).Text);

            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("normal2@ubusecret.es");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("P@ssword");
            driver.FindElement(By.Id("btnIniciarSesion")).Click(); 
            Assert.AreEqual("El usuario no se encuentra autorizado", driver.FindElement(By.Id("lblInicioError")).Text);
        }

        [TestMethod]
        public void TheInicioDeSesionChromeTest()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/inicioSesion");
            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("ejemplo");
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("prueba");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            Assert.AreEqual("Este mail no es válido o no existe el usuario", driver.FindElement(By.Id("lblUsuarioError")).Text);

            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("prueba");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            Assert.AreEqual("La contraseña es incorrecta", driver.FindElement(By.Id("lblContraseñaError")).Text);

            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("normal2@ubusecret.es");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("P@ssword");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            Assert.AreEqual("El usuario no se encuentra autorizado", driver.FindElement(By.Id("lblInicioError")).Text);
        }
    }
}
