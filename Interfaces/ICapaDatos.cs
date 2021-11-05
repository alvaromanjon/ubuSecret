using libreriaClases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICapaDatos
    {
        bool ActualizaSecreto(); //TO-DO
        bool ActualizaUsuario();//TO-DO
        Secreto BorraSecreto(string nombre);
        Secreto BorraSecreto(int identificador);
        Usuario BorraUsuario(string cuenta);
        Usuario BorraUsuario(int identificador);
        bool ExisteUsuarioEMail(string correo);
        bool InsertaSecreto(Secreto secreto);
        bool InsertaUsuario(Usuario usuario);
        Secreto LeeSecreto(string nombre);
        Secreto LeeSecreto(int identificador);
        Usuario LeeUsuario(int identificador);
        Usuario LeeUsuario(string cuenta);
        int numeroSecretos();
        int NumeroUsuarios();
        int siguienteSecreto();
        int SiguienteUsuario();
    }
}
