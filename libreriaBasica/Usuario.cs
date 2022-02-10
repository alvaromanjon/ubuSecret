using System;
using System.Security.Cryptography;

namespace libreriaClases
{
    public class Usuario
    {
        private int idUsuario;
        private Estados estado;
        private string nombre;
        private string correo;
        private string contraseña;
        private string pregunta1;
        private string pregunta2;
        private bool cambioContraseña;
        private Roles rol;

        public Usuario(string nombre, string correo, string contraseña, string pregunta1, string pregunta2, Roles rol)
        {
            this.idUsuario = -1;
            this.estado = Estados.PRECARGADO;
            this.nombre = nombre;
            this.correo = correo;
            this.contraseña = contraseña;
            this.pregunta1 = pregunta1;
            this.pregunta2 = pregunta2;
            this.cambioContraseña = false;
            this.rol = rol;
        }

        public int IdUsuario
        {
            get
            {
                return this.idUsuario;
            }
            set
            {
                this.idUsuario = value;
            }
        }
        public Estados Estado
        {
            get
            {
                return this.estado;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

        public string Correo
        {
            get 
            {
                return this.correo;        
            }
        }

        public string Contraseña
        {
            get
            {
                return this.contraseña;
            }
        }

        public string Pregunta1
        {
            get
            {
                return this.pregunta1;
            }
        }

        public string Pregunta2
        {
            get
            {
                return this.pregunta2;
            }
        }

        public Roles Rol
        {
            get
            {
                return this.rol;
            }
        }

        public void CambiarRol(Roles nuevoRol)
        {
            this.rol = nuevoRol;
        }

        public void Cargar()
        {
            if (this.estado == Estados.PRECARGADO)
            {
                this.estado = Estados.SOLICITADO;
            }
        }

        public bool DarAlta(Usuario admin)
        {
            bool retorno = false;
            if (admin.Rol == Roles.ADMINISTRADOR)
            {
                if (this.estado == Estados.SOLICITADO && this.cambioContraseña)
                {
                    this.estado = Estados.VALIDADO;
                    retorno = true;
                }
            }
            return retorno;
        }

        public bool CambiarContraseña(string contraseñaAntigua, string contraseñaNueva)
        {
            bool retorno = false;
            if (contraseñaNueva != null)
            {
                if (CompruebaContraseña(contraseñaAntigua) && !contraseñaAntigua.Equals(contraseñaNueva))
                {
                    retorno = true;
                    this.contraseña = contraseñaNueva;
                    this.cambioContraseña = true;
                }
                
            }
            return retorno;
        }

        public bool CompruebaContraseña(string contraseña)
        {
            if (contraseña == null)
                return false;
            return contraseña == this.contraseña;
        }

        public bool CompruebaPreguntaSeguridad(string pregunta, int numPregunta)
        {
            if (pregunta != null && numPregunta >= 1 && numPregunta <= 2)
            {
                if (numPregunta == 1)
                {
                    if (pregunta == this.pregunta1)
                    {
                        return true;
                    }
                } else if (numPregunta == 2)
                {
                    if (pregunta == this.pregunta2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
