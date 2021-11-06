﻿using libreriaClases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICapaDatos
    {
        bool ActualizaSecreto(Secreto secreto);
        bool ActualizaUsuario(Usuario usuario);
        bool BorraSecreto(string nombre);
        bool BorraSecreto(int identificador);
        bool BorraUsuario(string correo);
        bool BorraUsuario(int identificador);
        bool ExisteUsuarioEMail(string correo);
        bool InsertaSecreto(Secreto secreto);
        bool InsertaUsuario(Usuario usuario);
        Secreto LeeSecreto(string nombre);
        Secreto LeeSecreto(int identificador);
        Usuario LeeUsuario(string correo);
        Usuario LeeUsuario(int identificador);
        int NumeroSecretos();
        int NumeroUsuarios();
        int SiguienteSecreto();
        int SiguienteUsuario();
    }
}
