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
    public class crearSecretoTests
    {
        private static IWebDriver driver;

        [TestMethod]
        public void TheCreacionSecretoEdgeTest()
        {
            driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/inicioSesion");
            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("P@ssword");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            driver.FindElement(By.Id("btnCrearSecreto")).Click();
            driver.FindElement(By.Id("tbxDestinatario")).Click();
            driver.FindElement(By.Id("tbxDestinatario")).Clear();
            driver.FindElement(By.Id("tbxDestinatario")).SendKeys("prueba");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El destinatario no está registrado o no existe", driver.FindElement(By.Id("lblDestinatarioError")).Text);
            
            driver.FindElement(By.Id("tbxDestinatario")).Click();
            driver.FindElement(By.Id("tbxDestinatario")).Clear();
            driver.FindElement(By.Id("tbxDestinatario")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("tbxTitulo")).Click();
            driver.FindElement(By.Id("tbxTitulo")).Clear();
            driver.FindElement(By.Id("tbxTitulo")).SendKeys("El primer secreto");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El secreto y/o título están vacíos", driver.FindElement(By.Id("lblSecretoError")).Text);
            
            driver.FindElement(By.Id("tbxSecreto")).Click();
            driver.FindElement(By.Id("tbxSecreto")).Clear();
            driver.FindElement(By.Id("tbxSecreto")).SendKeys("faerg");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El destinatario ya tiene un secreto con ese título", driver.FindElement(By.Id("lblSecretoError")).Text);
            
            driver.FindElement(By.Id("tbxSecreto")).Click();
            driver.FindElement(By.Id("tbxSecreto")).Clear();
            driver.FindElement(By.Id("tbxSecreto")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El secreto supera los 255 caracteres de longitud", driver.FindElement(By.Id("lblSecretoError")).Text);
        }

        [TestMethod]
        public void TheCreacionSecretoChromeTest()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/inicioSesion");
            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("P@ssword");
            driver.FindElement(By.Id("btnIniciarSesion")).Click();
            driver.FindElement(By.Id("btnCrearSecreto")).Click();
            driver.FindElement(By.Id("tbxDestinatario")).Click();
            driver.FindElement(By.Id("tbxDestinatario")).Clear();
            driver.FindElement(By.Id("tbxDestinatario")).SendKeys("prueba");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El destinatario no está registrado o no existe", driver.FindElement(By.Id("lblDestinatarioError")).Text);

            driver.FindElement(By.Id("tbxDestinatario")).Click();
            driver.FindElement(By.Id("tbxDestinatario")).Clear();
            driver.FindElement(By.Id("tbxDestinatario")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("tbxTitulo")).Click();
            driver.FindElement(By.Id("tbxTitulo")).Clear();
            driver.FindElement(By.Id("tbxTitulo")).SendKeys("El primer secreto");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El secreto y/o título están vacíos", driver.FindElement(By.Id("lblSecretoError")).Text);

            driver.FindElement(By.Id("tbxSecreto")).Click();
            driver.FindElement(By.Id("tbxSecreto")).Clear();
            driver.FindElement(By.Id("tbxSecreto")).SendKeys("faerg");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El destinatario ya tiene un secreto con ese título", driver.FindElement(By.Id("lblSecretoError")).Text);

            driver.FindElement(By.Id("tbxSecreto")).Click();
            driver.FindElement(By.Id("tbxSecreto")).Clear();
            driver.FindElement(By.Id("tbxSecreto")).SendKeys("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec.");
            driver.FindElement(By.Id("btnCreacionSecretos")).Click();
            Assert.AreEqual("El secreto supera los 255 caracteres de longitud", driver.FindElement(By.Id("lblSecretoError")).Text);
        }
    }
}
