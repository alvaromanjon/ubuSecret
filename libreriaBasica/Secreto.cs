using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace libreriaClases
{
    public class Secreto
    {
        private int idSecreto;
        private Usuario usuario;
        private string nombre;
        private string texto;

        public Secreto(Usuario usuario, string nombre, string texto)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.texto = texto;
        }

        public int IdSecreto
        {
            get
            {
                return this.idSecreto;
            }
            set
            {
                this.idSecreto = value;
            }
        }

        public Usuario Usuario
        {
            get
            {
                return this.usuario;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
    }
}
