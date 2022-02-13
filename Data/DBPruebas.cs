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

        public bool InsertaUsuario(Usuario usuario)
        {
            bool retorno = false;

            if (usuario.Estado == Estados.PRECARGADO)
            {
                if (this.LeeUsuario(usuario.Correo) == null)
                {
                    usuario.IdUsuario = this.siguienteIdUsuario;
                    usuario.Cargar();
                    this.siguienteIdUsuario += 1;
                    tblUsuarios.Add(usuario.IdUsuario, usuario);
                    retorno = true;
                }
            }
            return retorno;
        }

        public Usuario BorraUsuario(string correo)
        {
            Usuario u = null;
            List<int> secretosABorrar = new List<int>();

            u = this.LeeUsuario(correo);
            if (u != null)
            {
                foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
                {
                    if (correo == kvp.Value.Origen.Correo)
                    {
                        secretosABorrar.Add(kvp.Value.IdSecreto);
                    }
                }

                foreach (int elemento in secretosABorrar)
                {
                    BorraSecreto(elemento);
                }

                u = LeeUsuario(correo);
                tblUsuarios.Remove(u.IdUsuario);
            }
            return u;
        }

        public SortedList<int, Usuario> LeeUsuariosActivos()
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();
            foreach (KeyValuePair<int, Usuario> kvp in tblUsuarios)
            {
                if (kvp.Value.Estado == Estados.VALIDADO)
                {
                    listUsuarios.Add(kvp.Value.IdUsuario, kvp.Value);
                }
            }
            return listUsuarios;
        }

        public SortedList<int, Usuario> LeeUsuariosInactivos()
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();
            foreach (KeyValuePair<int, Usuario> kvp in tblUsuarios)
            {
                if (kvp.Value.Estado == Estados.PRECARGADO)
                {
                    listUsuarios.Add(kvp.Value.IdUsuario, kvp.Value);
                }
            }
            return listUsuarios;
        }

        public SortedList<int, Usuario> LeeUsuariosPendientes()
        {
            SortedList<int, Usuario> listUsuarios = new SortedList<int, Usuario>();
            foreach (KeyValuePair<int, Usuario> kvp in tblUsuarios)
            {
                if (kvp.Value.Estado == Estados.SOLICITADO)
                {
                    listUsuarios.Add(kvp.Value.IdUsuario, kvp.Value);
                }
            }
            return listUsuarios;
        }

        public SortedList<int, Secreto> LeeSecretosEnviadosUsuario(Usuario usuario)
        {
            SortedList<int, Secreto> secUsuarios = new SortedList<int, Secreto>();
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (String.Equals(kvp.Value.Origen.Correo, usuario.Correo))
                {
                    secUsuarios.Add(kvp.Value.IdSecreto, kvp.Value);
                }
            }
            return secUsuarios;
        }

        public SortedList<int, Secreto> LeeSecretosRecibidosUsuario(Usuario usuario)
        {
            SortedList<int, Secreto> secUsuarios = new SortedList<int, Secreto>();
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (String.Equals(kvp.Value.Destino.Correo, usuario.Correo))
                {
                    secUsuarios.Add(kvp.Value.IdSecreto, kvp.Value);
                }
            }
            return secUsuarios;
        }

        public bool InsertaSecreto(Secreto secreto)
        {
            bool retorno = false;

            if (LeeUsuario(secreto.Origen.Correo) != null && LeeUsuario(secreto.Destino.Correo) != null)
            {
                secreto.IdSecreto = this.siguienteIdSecreto;
                this.siguienteIdSecreto += 1;
                tblSecretos.Add(secreto.IdSecreto, secreto);
                retorno = true;
            }
            return retorno;
        }

        public Secreto LeeSecreto(int identificador)
        {
            Secreto s = null;
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (kvp.Key == identificador)
                {
                    s = kvp.Value;
                }
            }
            return s;
        }

        public Secreto BorraSecreto(int identificador)
        {
            Secreto s = null;

            s = LeeSecreto(identificador);
            if (s != null)
            {
                tblSecretos.Remove(identificador);
            }
            return s;
        }

        private int SiguienteSecreto()
        {
            return this.siguienteIdSecreto;
        }

        private int SiguienteUsuario()
        {
            return this.siguienteIdUsuario;
        }
    }
}
