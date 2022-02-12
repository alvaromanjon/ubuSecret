using libreriaClases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICapaDatos
    {
        bool ActualizaSecreto(Secreto secreto);
        bool ActualizaUsuario(Usuario usuario);
        bool BorraSecreto(Usuario destinatario, string nombre);
        bool BorraSecreto(int identificador);
        bool BorraUsuario(string correo);
        bool BorraUsuario(int identificador);
        bool ExisteUsuarioEMail(string correo);
        bool InsertaSecreto(Secreto secreto);
        bool InsertaUsuario(Usuario usuario);
        SortedList<int, Secreto> LeeSecretosUsuario(Usuario usuario);
        Secreto LeeSecreto(Usuario destinatario, string nombre);
        Secreto LeeSecreto(int identificador);
        Usuario LeeUsuario(string correo);
        Usuario LeeUsuario(int identificador);
        int NumeroSecretos();
        int NumeroUsuarios();
        int SiguienteSecreto();
        int SiguienteUsuario();
    }
}
