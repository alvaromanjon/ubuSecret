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
        private Roles rol;

        public Usuario(string nombre, string correo, string contraseña, Roles rol)
        {
            this.idUsuario = -1;
            this.estado = Estados.PRECARGADO;
            this.nombre = nombre;
            this.correo = correo;
            this.contraseña = contraseña;
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

        public void DarAlta(Usuario admin)
        {
            if (admin.Rol == Roles.ADMINISTRADOR)
            {
                if (this.estado == Estados.SOLICITADO)
                {
                    this.estado = Estados.VALIDADO;
                }
            }
        }

        public bool CambiarContraseña(string contraseñaAntigua, string contraseñaNueva)
        {
            bool retorno = false;
            if (contraseñaNueva != null)
            {
                if (CompruebaContraseña(contraseñaAntigua))
                {
                    retorno = true;
                    this.contraseña = contraseñaNueva;
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

        /**
        private string Encriptar(string password)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256.Create();
            bytes = mySHA256.ComputeHash(bytes);
            return (System.Text.Encoding.ASCII.GetString(bytes));
        }
        */
    }
}
