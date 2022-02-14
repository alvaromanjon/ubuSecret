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
    public class DBPruebasTestsDD
    {
        DBPruebas data;
        static Usuario u1a = null;
        static Usuario u2a = null;
        static Usuario u3a = null;
        static Usuario u4a = null;
        static Secreto s1a = null;
        static Secreto s2a = null;
        static Secreto s3a = null;

        [TestInitialize]
        public void InicializaMetodos()
        {
            data = new DBPruebas();
            u1a = new Usuario("Admin", "u1a@ubusecret.es", "Password", "Maristas", "18", Roles.ADMINISTRADOR);
            u2a = new Usuario("Normal", "u2a@ubusecret.es", "Password", "Zapatito", "20", Roles.USUARIO);
            u3a = new Usuario("Normal2", "u3a@ubusecret.es", "Password", "Jesuitas", "21", Roles.USUARIO);
            u4a = new Usuario("Normal3", "u4a@ubusecret.es", "Password", "Sagrada Familia", "23", Roles.USUARIO);
            s1a = new Secreto(u1a, u2a, "Secreto1", "Secreto de prueba");
            s2a = new Secreto(u1a, u2a, "Secreto2", "Otro secreto");
            s3a = new Secreto(u2a, u1a, "Secreto3", "Otro secreto con distinto usuario");
        }

        [TestMethod]
        public void DBPruebasTest()
        {
            Assert.AreEqual(this.data.NumeroUsuarios(), 0);
            Assert.AreEqual(this.data.SiguienteUsuario(), 1);
            Assert.AreEqual(this.data.NumeroSecretos(), 0);
            Assert.AreEqual(this.data.SiguienteSecreto(), 1);
        }

        public static IEnumerable<object[]> GetLeeUsuarioData()
        {
            yield return new object[] { u1a, "u1a@ubusecret.es", true, u1a  };
            yield return new object[] { u2a, "u2a@ubusecret.es", false, null  };
            yield return new object[] { u3a, "u3a@ubusecret.es", true, u3a  };
            yield return new object[] { u4a, "u4a@ubusecret.es", false, null  };
        }


        [DataTestMethod]
        [DynamicData(nameof(GetLeeUsuarioData), DynamicDataSourceType.Method)]
        public void LeeUsuarioTest(Usuario u, string correo, bool insertar, Usuario esperado)
        {
            Assert.IsNull(data.LeeUsuario(correo));
            if (insertar)
            {
                data.InsertaUsuario(u);
            }
            Assert.AreEqual(data.LeeUsuario(correo), esperado);
        }

        public static IEnumerable<object[]> GetInsertaUsuarioData()
        {
            yield return new object[] { u1a, false, Estados.SOLICITADO, Estados.SOLICITADO };
            yield return new object[] { u2a, true, Estados.PRECARGADO, Estados.SOLICITADO };
            yield return new object[] { u3a, true, Estados.PRECARGADO, Estados.SOLICITADO };
            yield return new object[] { u4a, true, Estados.PRECARGADO, Estados.SOLICITADO };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetInsertaUsuarioData), DynamicDataSourceType.Method)]
        public void InsertaUsuarioTest(Usuario u, bool valido, Estados previo, Estados despues)
        {
            if (previo == Estados.SOLICITADO)
            {
                u.Cargar();
            }
            Assert.AreEqual(data.InsertaUsuario(u), valido);
            Assert.AreEqual(u.Estado, despues);
            Assert.IsFalse(data.InsertaUsuario(u));
        }

        /*
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
        */
    }
}