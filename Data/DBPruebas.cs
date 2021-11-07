using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using libreriaClases;

namespace Data
{
    public class DBPruebas : ICapaDatos
    {
        int siguienteIdUsuario = 1;
        int siguienteIdSecreto = 1;
        private SortedList<int, Usuario> tblUsuarios = new SortedList<int, Usuario>();
        private SortedList<int, Secreto> tblSecretos = new SortedList<int, Secreto>();

        public DBPruebas()
        {
            //Datos iniciales simulados
            //Usuario admin
            Usuario admin = new Usuario("Admin", "admin@ubusecret.es", "Password", Roles.ADMINISTRADOR);
            this.InsertaUsuario(admin);
            admin.DarAlta(admin);
            admin.CambiarContraseña("Password", "P@ssword");
            this.ActualizaUsuario(admin);

            Usuario normal = new Usuario("Normal", "normal@ubusecret.es", "Password", Roles.USUARIO);
            this.InsertaUsuario(normal);
            normal.DarAlta(admin);
            normal.CambiarContraseña("Password", "P@ssword");
            this.ActualizaUsuario(normal);
        }

        public bool ActualizaSecreto(Secreto secreto)
        {
            bool retorno = false;
            int idSecreto = secreto.IdSecreto;
            if (LeeSecreto(idSecreto) != null)
            {
                tblSecretos.Remove(idSecreto);
                tblSecretos.Add(idSecreto, secreto);
                retorno = true;
            }
            return retorno;
        }

        public bool ActualizaUsuario(Usuario usuario)
        {
            bool retorno = false;
            int idUsuario = usuario.IdUsuario;
            if (LeeUsuario(idUsuario) != null)
            {
                tblUsuarios.Remove(idUsuario);
                tblUsuarios.Add(idUsuario, usuario);
                retorno = true;
            }
            return retorno;
        }

        public bool BorraSecreto(string nombre)
        {
            bool retorno = false;
            Secreto s;
            s = this.LeeSecreto(nombre);
            if (s != null)
            {
                retorno = this.BorraSecreto(s.IdSecreto);
            }
            return retorno;
        }

        public bool BorraSecreto(int identificador)
        {
            return tblSecretos.Remove(identificador);
        }

        public bool BorraUsuario(string correo)
        {
            bool retorno = false;
            Usuario u;
            u = this.LeeUsuario(correo);
            if (u != null)
            {
                retorno = this.BorraUsuario(u.IdUsuario);
            }
            return retorno;
        }

        public bool BorraUsuario(int identificador)
        {
            bool retorno = false;
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (identificador == kvp.Value.Usuario.IdUsuario)
                {
                    BorraSecreto(kvp.Value.IdSecreto);
                }
            }
            retorno = tblUsuarios.Remove(identificador);

            return retorno;
        }

        public bool ExisteUsuarioEMail(string correo)
        {
            bool retorno = false;
            if (this.LeeUsuario(correo) != null)
            {
                retorno = true;
            }
            return retorno;
        }

        public bool InsertaSecreto(Secreto secreto)
        {
            bool retorno = false;
            if (this.LeeSecreto(secreto.Nombre) == null)
            {
                secreto.IdSecreto = this.siguienteIdSecreto;
                this.siguienteIdSecreto += 1;
                tblSecretos.Add(secreto.IdSecreto, secreto);
                retorno = true;
            }
            return retorno;
        }

        public bool InsertaUsuario(Usuario usuario)
        {
            bool retorno = false;
            if (usuario.Alta)
            {
                if (!ExisteUsuarioEMail(usuario.Correo))
                {
                    usuario.IdUsuario = this.siguienteIdUsuario;
                    // Método grabar?
                    this.siguienteIdUsuario += 1;
                    tblUsuarios.Add(usuario.IdUsuario, usuario);
                    retorno = true;
                }
            }
            return retorno;
        }

        public Secreto LeeSecreto(string nombre)
        {
            Secreto s = null;
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (String.Equals(kvp.Value.Nombre, nombre))
                {
                    s = kvp.Value;
                }
            }
            return s;
        }

        public Secreto LeeSecreto(int identificador)
        {
            int index = tblSecretos.IndexOfKey(identificador);
            return tblSecretos.Values[index];
        }

        public Usuario LeeUsuario(string cuenta)
        {
            Usuario u = null;
            foreach (KeyValuePair<int, Usuario> kvp in tblUsuarios)
            {
                if (String.Equals(kvp.Value.Correo, cuenta))
                {
                    u = kvp.Value;
                }
            }
            return u;
        }

        public Usuario LeeUsuario(int identificador)
        {
            int index = tblUsuarios.IndexOfKey(identificador);
            return tblUsuarios.Values[index];
        }

        public int NumeroSecretos()
        {
            return this.tblSecretos.Count;
        }

        public int NumeroUsuarios()
        {
            return this.tblUsuarios.Count;
        }

        public int SiguienteSecreto()
        {
            return this.siguienteIdSecreto;
        }

        public int SiguienteUsuario()
        {
            return this.siguienteIdUsuario;
        }
    }
}
