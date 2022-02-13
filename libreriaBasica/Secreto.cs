using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace libreriaClases
{
    [JsonObject(MemberSerialization.OptIn)]
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

        [JsonProperty]
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

        [JsonProperty]
        public Usuario Origen
        {
            get
            {
                return this.origen;
            }
        }

        [JsonProperty]
        public Usuario Destino
        {
            get
            {
                return this.destino;
            }
        }

        [JsonProperty]
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        [JsonProperty]
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
