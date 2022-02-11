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
    public class registroTests
    {
        private static IWebDriver driver;

        [TestMethod]
        public void TheRegistroEdgeTest()
        {
            driver = new EdgeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/registro");
            driver.FindElement(By.Id("tbxNombre")).Click();
            driver.FindElement(By.Id("tbxNombre")).Clear();
            driver.FindElement(By.Id("tbxNombre")).SendKeys("Pepe");
            driver.FindElement(By.Id("tbxCorreo")).Click();
            driver.FindElement(By.Id("tbxCorreo")).Clear();
            driver.FindElement(By.Id("tbxCorreo")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("btnRegistro")).Click();
            Assert.AreEqual("El correo no es válido o ya existe un usuario registrado con este correo", driver.FindElement(By.Id("lblCorreoError")).Text);

            driver.FindElement(By.Id("tbxCorreo")).Click();
            driver.FindElement(By.Id("tbxCorreo")).Clear();
            driver.FindElement(By.Id("tbxCorreo")).SendKeys("pepe@pepeperez.com");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("hola");
            driver.FindElement(By.Id("tbxRepetirContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirContraseña")).SendKeys("adios");
            driver.FindElement(By.Id("btnRegistro")).Click();
            Assert.AreEqual("Las contraseñas no coinciden", driver.FindElement(By.Id("lblRepetirContraseñaError")).Text);

            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("hola");
            driver.FindElement(By.Id("tbxRepetirContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirContraseña")).SendKeys("hola");
            driver.FindElement(By.Id("btnRegistro")).Click();
            Assert.AreEqual("Uno o varios de los campos están vacíos", driver.FindElement(By.Id("lblRegistroError")).Text);
            }

        [TestMethod]
        public void TheRegistroChromeTest()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44382/registro");
            driver.FindElement(By.Id("tbxNombre")).Click();
            driver.FindElement(By.Id("tbxNombre")).Clear();
            driver.FindElement(By.Id("tbxNombre")).SendKeys("Pepe");
            driver.FindElement(By.Id("tbxCorreo")).Click();
            driver.FindElement(By.Id("tbxCorreo")).Clear();
            driver.FindElement(By.Id("tbxCorreo")).SendKeys("normal@ubusecret.es");
            driver.FindElement(By.Id("btnRegistro")).Click();
            Assert.AreEqual("El correo no es válido o ya existe un usuario registrado con este correo", driver.FindElement(By.Id("lblCorreoError")).Text);

            driver.FindElement(By.Id("tbxCorreo")).Click();
            driver.FindElement(By.Id("tbxCorreo")).Clear();
            driver.FindElement(By.Id("tbxCorreo")).SendKeys("pepe@pepeperez.com");
            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("hola");
            driver.FindElement(By.Id("tbxRepetirContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirContraseña")).SendKeys("adios");
            driver.FindElement(By.Id("btnRegistro")).Click();
            Assert.AreEqual("Las contraseñas no coinciden", driver.FindElement(By.Id("lblRepetirContraseñaError")).Text);

            driver.FindElement(By.Id("tbxContraseña")).Click();
            driver.FindElement(By.Id("tbxContraseña")).Clear();
            driver.FindElement(By.Id("tbxContraseña")).SendKeys("hola");
            driver.FindElement(By.Id("tbxRepetirContraseña")).Clear();
            driver.FindElement(By.Id("tbxRepetirContraseña")).SendKeys("hola");
            driver.FindElement(By.Id("btnRegistro")).Click();
            Assert.AreEqual("Uno o varios de los campos están vacíos", driver.FindElement(By.Id("lblRegistroError")).Text);
        }
    }
    }
