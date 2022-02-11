﻿using System;
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
            Usuario admin = new Usuario("Admin", "admin@ubusecret.es", "Password", "Maristas", "12", Roles.ADMINISTRADOR);
            this.InsertaUsuario(admin);
            admin.CambiarContraseña("Password", "P@ssword");
            admin.DarAlta(admin);
            this.ActualizaUsuario(admin);

            //Usuario normal
            Usuario normal = new Usuario("Normal", "normal@ubusecret.es", "Password", "Jesuitas", "21", Roles.USUARIO);
            this.InsertaUsuario(normal);
            normal.CambiarContraseña("Password", "P@ssword");
            normal.DarAlta(admin);
            this.ActualizaUsuario(normal);

            //Usuario normal2 sin tener acceso autorizado
            Usuario normal2 = new Usuario("Normal2", "normal2@ubusecret.es", "Password", "Sagrada Familia", "23", Roles.USUARIO);
            this.InsertaUsuario(normal2);
            normal2.CambiarContraseña("Password", "P@ssword");

            //Secreto
            Secreto s = new Secreto(normal, "El primer secreto", "Texto del primer secreto");
            this.InsertaSecreto(s);
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

        public bool BorraSecreto(Usuario destinatario, string nombre)
        {
            bool retorno = false;
            Secreto s;
            s = this.LeeSecreto(destinatario, nombre);
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
            List<int> secretosABorrar = new List<int>();

            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (identificador == kvp.Value.Usuario.IdUsuario)
                {
                    secretosABorrar.Add(kvp.Value.IdSecreto);
                }
            }

            foreach (int elemento in secretosABorrar)
            {
                BorraSecreto(elemento);
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

            if (LeeUsuario(secreto.Usuario.Correo) != null)
            {
                if (LeeSecreto(secreto.Usuario, secreto.Nombre) == null)
                {
                    secreto.IdSecreto = this.siguienteIdSecreto;
                    this.siguienteIdSecreto += 1;
                    tblSecretos.Add(secreto.IdSecreto, secreto);
                    retorno = true;
                }
            }
            return retorno;
        }

        public bool InsertaUsuario(Usuario usuario)
        {
            bool retorno = false;

            if (usuario.Estado == Estados.PRECARGADO)
            {
                if (!ExisteUsuarioEMail(usuario.Correo))
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

        public SortedList<int, Secreto> LeeSecretosUsuario(Usuario usuario)
        {
            SortedList<int, Secreto> secUsuarios = new SortedList<int, Secreto>();
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (String.Equals(kvp.Value.Usuario, usuario))
                {
                    secUsuarios.Add(kvp.Value.IdSecreto, kvp.Value);
                }
            }
            return secUsuarios;
        }

        public Secreto LeeSecreto(Usuario destinatario, string nombre)
        {
            Secreto s = null;
            foreach (KeyValuePair<int, Secreto> kvp in tblSecretos)
            {
                if (String.Equals(kvp.Value.Nombre, nombre) && destinatario == kvp.Value.Usuario)
                {
                    s = kvp.Value;
                }
            }
            return s;
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
            Usuario u = null;
            foreach (KeyValuePair<int, Usuario> kvp in tblUsuarios)
            {
                if (kvp.Key == identificador)
                {
                    u = kvp.Value;
                }
            }
            return u;
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
