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
        bool BorraSecreto(Secreto secreto);
        bool BorraSecreto(int identificador);
        bool BorraUsuario(string cuenta);
        bool BorraUsuario(int identificador);
        bool ExisteUsuarioEMail(string correo);
        bool InsertaSecreto(Secreto secreto);
        bool InsertaUsuario(Usuario usuario);
        bool LeeSecreto(Secreto secreto);
        bool LeeSecreto(int identificador);
        bool LeeUsuario(int identificador);
        bool LeeUsuario(string cuenta);
        int numeroSecretos();
        int NumeroUsuarios();
        int siguienteSecreto();
        int SiguienteUsuario();
    }
}
