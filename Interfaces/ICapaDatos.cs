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
        List<Usuario> LeeUsuariosActivos();
        List<Usuario> LeeUsuariosInactivos();
        List<Usuario> LeeUsuariosPendientes();
        SortedList<int, Secreto> LeeSecretosEnviadosUsuario(Usuario usuario);
        SortedList<int, Secreto> LeeSecretosRecibidosUsuario(Usuario usuario);
        bool InsertaSecreto(Secreto secreto);
        Secreto LeeSecreto(int identificador);
        Secreto BorraSecreto(int identificador);
    }
}
