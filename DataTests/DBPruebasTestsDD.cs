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

        public static Usuario CrearUsuario(string nombre, string correo, Roles rol)
        {
            return new Usuario(nombre, correo, "Password", "Maristas", "18", rol);
        }

        public static Secreto CrearSecreto(Usuario u1, Usuario u2)
        {
            return new Secreto(u1, u2, "Titulo", "Texto del secreto");
        }

        public static IEnumerable<object[]> GetLeeUsuarioData()
        {
            Usuario u1a = CrearUsuario("Admin", "u1a@ubusecret.es", Roles.ADMINISTRADOR);
            Usuario u2a = CrearUsuario("Normal", "u2a@ubusecret.es", Roles.USUARIO);
            Usuario u3a = CrearUsuario("Admin", "u3a@ubusecret.es", Roles.USUARIO);
            Usuario u4a = CrearUsuario("Normal", "u4a@ubusecret.es", Roles.USUARIO);
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
            Usuario u1a = CrearUsuario("Admin", "u1a@ubusecret.es", Roles.ADMINISTRADOR);
            Usuario u2a = CrearUsuario("Normal", "u2a@ubusecret.es", Roles.USUARIO);
            Usuario u3a = CrearUsuario("Admin", "u3a@ubusecret.es", Roles.USUARIO);
            Usuario u4a = CrearUsuario("Normal", "u4a@ubusecret.es", Roles.USUARIO);
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

        public static IEnumerable<object[]> GetBorraUsuarioData()
        {
            Usuario u1a = CrearUsuario("Admin", "u1a@ubusecret.es", Roles.ADMINISTRADOR);
            Usuario u2a = CrearUsuario("Normal", "u2a@ubusecret.es", Roles.ADMINISTRADOR);
            yield return new object[] { u1a, "u1a@ubusecret.es", CrearSecreto(u1a, u2a) };
            yield return new object[] { u2a, "u2a@ubusecret.es", CrearSecreto(u2a, u1a) };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetBorraUsuarioData), DynamicDataSourceType.Method)]
        public void BorraUsuarioTest(Usuario u, string correo, Secreto s)
        {
            data.InsertaUsuario(u);
            data.InsertaSecreto(s);

            Assert.AreEqual(data.BorraUsuario(correo), u);
            Assert.IsNull(data.LeeSecreto(s.IdSecreto));
            Assert.IsNull(data.LeeUsuario(correo));
        }

        public static IEnumerable<object[]> GetListaTiposUsuariosData()
        {
            Usuario u1a = CrearUsuario("Admin", "u1a@ubusecret.es", Roles.ADMINISTRADOR);
            Usuario u2a = CrearUsuario("Normal1", "u2a@ubusecret.es", Roles.ADMINISTRADOR);
            Usuario u3a = CrearUsuario("Normal2", "u3a@ubusecret.es", Roles.USUARIO);
            Usuario u4a = CrearUsuario("Normal3", "u4a@ubusecret.es", Roles.USUARIO);
            yield return new object[] { u1a, true, true };
            yield return new object[] { u2a, true, true };
            yield return new object[] { u3a, false, true };
            yield return new object[] { u4a, false, false };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetListaTiposUsuariosData), DynamicDataSourceType.Method)]
        public void LeeUsuariosActivosTest(Usuario u, bool activo, bool insertar)
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();

            if (insertar)
            {
                data.InsertaUsuario(u);
                if (activo)
                {
                    u.CambiarContraseña("Password", "P@ssword");
                    u.DarAlta(u);
                }
            }

            listUsuarios = data.LeeUsuariosActivos();

            if (activo)
            {
                Assert.IsTrue(listUsuarios.ContainsValue(u));
            } else
            {
                Assert.IsFalse(listUsuarios.ContainsValue(u));
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetListaTiposUsuariosData), DynamicDataSourceType.Method)]
        public void LeeUsuariosInactivosTest(Usuario u, bool activo, bool insertar)
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();

            if (insertar)
            {
                data.InsertaUsuario(u);
                if (activo)
                {
                    u.CambiarContraseña("Password", "P@ssword");
                    u.DarAlta(u);
                }
            }

            listUsuarios = data.LeeUsuariosInactivos();

            if (!activo && !insertar)
            {
                if (data.LeeUsuario(u.Correo) != null)
                {
                    Assert.IsTrue(listUsuarios.ContainsValue(u));
                } 
            }
            else
            {
                Assert.IsFalse(listUsuarios.ContainsValue(u));
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(GetListaTiposUsuariosData), DynamicDataSourceType.Method)]
        public void LeeUsuariosPendientesTest(Usuario u, bool activo, bool insertar)
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();

            if (insertar)
            {
                data.InsertaUsuario(u);
                if (activo)
                {
                    u.CambiarContraseña("Password", "P@ssword");
                    u.DarAlta(u);
                }
            }

            listUsuarios = data.LeeUsuariosPendientes();

            if (!activo && insertar)
            {
                Assert.IsTrue(listUsuarios.ContainsValue(u));
            }
            else
            {
                Assert.IsFalse(listUsuarios.ContainsValue(u));
            }
        }

        public static IEnumerable<object[]> GetListaSecretosData()
        {
            Usuario u1a = CrearUsuario("Admin", "u1a@ubusecret.es", Roles.ADMINISTRADOR);
            Usuario u2a = CrearUsuario("Normal1", "u2a@ubusecret.es", Roles.ADMINISTRADOR);
            Secreto s1a = CrearSecreto(u1a, u2a);
            Secreto s2a = CrearSecreto(u1a, u2a);
            Secreto s3a = CrearSecreto(u2a, u1a);
            yield return new object[] { s1a, u1a, u2a };
            yield return new object[] { s2a, u1a, u2a };
            yield return new object[] { s3a, u2a, u1a };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetListaSecretosData), DynamicDataSourceType.Method)]
        public void InsertaSecretoTest(Secreto s, Usuario origen, Usuario destino)
        {
            Assert.AreEqual(-1, s.IdSecreto);
            data.InsertaUsuario(origen);
            data.InsertaUsuario(destino);
            Assert.IsTrue(data.InsertaSecreto(s));
        }

        [DataTestMethod]
        [DynamicData(nameof(GetListaSecretosData), DynamicDataSourceType.Method)]
        public void LeeSecretoTest(Secreto s, Usuario origen, Usuario destino)
        {
            Assert.IsNull(data.LeeSecreto(s.IdSecreto));
            data.InsertaUsuario(origen);
            data.InsertaUsuario(destino);
            data.InsertaSecreto(s);
            Assert.AreEqual(data.LeeSecreto(s.IdSecreto), s);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetListaSecretosData), DynamicDataSourceType.Method)]
        public void BorraSecretoTest(Secreto s, Usuario origen, Usuario destino)
        {
            data.InsertaUsuario(origen);
            data.InsertaUsuario(destino);
            data.InsertaSecreto(s);
            Assert.AreEqual(data.BorraSecreto(s.IdSecreto), s);
            Assert.IsNull(data.LeeSecreto(s.IdSecreto));
        }
    }
}