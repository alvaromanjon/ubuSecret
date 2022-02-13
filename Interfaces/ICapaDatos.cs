using libreriaClases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICapaDatos
    {
        Usuario LeeUsuario(string correo);
        bool InsertaUsuario(Usuario usuario);
        Usuario BorraUsuario(string correo);
        SortedList<int, Usuario> LeeUsuariosActivos();
        SortedList<int, Usuario> LeeUsuariosInactivos();
        SortedList<int, Usuario> LeeUsuariosPendientes();
        SortedList<int, Secreto> LeeSecretosEnviadosUsuario(Usuario usuario);
        SortedList<int, Secreto> LeeSecretosRecibidosUsuario(Usuario usuario);
        bool InsertaSecreto(Secreto secreto);
        Secreto LeeSecreto(int identificador);
        Secreto BorraSecreto(int identificador);
    }
}
