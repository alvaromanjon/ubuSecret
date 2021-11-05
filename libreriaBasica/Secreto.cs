using System;
using System.Collections.Generic;
using System.Text;

namespace libreriaClases
{
    public class Secreto
    {
        private Usuario usuario;
        private string nombre;
        private string texto;

        public Secreto(Usuario usuario, string nombre, string texto)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.texto = texto;
        }
    }
}
