using System;
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
        public bool ActualizaSecreto()
        {
            throw new NotImplementedException();
        }

        public bool ActualizaUsuario()
        {
            throw new NotImplementedException();
        }

        public bool BorraSecreto(Secreto secreto)
        {
            throw new NotImplementedException();
        }

        public bool BorraSecreto(int identificador)
        {
            throw new NotImplementedException();
        }

        public bool BorraUsuario(string cuenta)
        {
            throw new NotImplementedException();
        }

        public bool BorraUsuario(int identificador)
        {
            throw new NotImplementedException();
        }

        public bool ExisteUsuarioEMail(string correo)
        {
            throw new NotImplementedException();
        }

        public bool InsertaSecreto(Secreto secreto)
        {
            throw new NotImplementedException();
        }

        public bool InsertaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool LeeSecreto(Secreto secreto)
        {
            throw new NotImplementedException();
        }

        public bool LeeSecreto(int identificador)
        {
            throw new NotImplementedException();
        }

        public bool LeeUsuario(int identificador)
        {
            throw new NotImplementedException();
        }

        public bool LeeUsuario(string cuenta)
        {
            throw new NotImplementedException();
        }

        public int numeroSecretos()
        {
            throw new NotImplementedException();
        }

        public int NumeroUsuarios()
        {
            throw new NotImplementedException();
        }

        public int siguienteSecreto()
        {
            throw new NotImplementedException();
        }

        public int SiguienteUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
