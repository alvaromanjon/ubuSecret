using System;
using System.Security.Cryptography;
namespace libreriaClases
{
    public class Usuario
    {
        private string contraseña;
        private string correo;
        private bool alta;
        private bool cambiarContraseña; // Por ver
        private Roles rol;

        public Usuario(string correo, string contraseña)
        {
            this.correo = correo;
            this.contraseña = Encriptar(contraseña);
            this.alta = false;
            this.rol = Roles.USUARIO;
            this.cambiarContraseña = false;
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

        public bool Alta
        {
            get
            {
                return this.alta;
            }
        }

        public void CambiarRol(Roles nuevoRol)
        {
            this.rol = nuevoRol;
        }

        public void DarAlta(Usuario admin)
        {
            if (admin.Rol == Roles.ADMINISTRADOR)
            {
                this.alta = true;
                this.cambiarContraseña = true;
            }
        }

        public bool CompruebaContraseña(string contraseña)
        {
            if (contraseña == null)
                return false;
            return contraseña == this.contraseña;
        }
        private string Encriptar(string password)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
            SHA256 mySHA256 = SHA256.Create();
            bytes = mySHA256.ComputeHash(bytes);
            return (System.Text.Encoding.ASCII.GetString(bytes));
        }
    }
}
