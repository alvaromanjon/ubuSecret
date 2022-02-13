using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace libreriaClases
{
    public class Secreto
    {
        private int idSecreto;
        private Usuario origen;
        private Usuario destino;
        private string nombre;
        private string texto;

        public Secreto(Usuario origen, Usuario destino, string nombre, string texto)
        {
            this.idSecreto = -1;
            this.origen = origen;
            this.destino = destino;
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

        public Usuario Origen
        {
            get
            {
                return this.origen;
            }
        }

        public Usuario Destino
        {
            get
            {
                return this.destino;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Texto
        {
            get
            {
                return this.texto;
            }
            set
            {
                this.texto = value;
            }
        }
    }
}
