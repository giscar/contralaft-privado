﻿using System;
using System.Collections.Generic;

using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    
    public class UsuarioBusinessLogic {

        private readonly UsuarioDataAccess _usuarioDataAccess;

        public UsuarioBusinessLogic()
        {
            _usuarioDataAccess = new UsuarioDataAccess();
        }

        public int GuardarPersona(Usuario _usuario)
        {
            return (_usuarioDataAccess.GuardarPersona(_usuario));   
        }

        public Usuario BuscarUsuario(Usuario _usuario)
        {
            return _usuarioDataAccess.BuscarUsuario(_usuario);
        }

        public List<Usuario> BuscarTodos()
        {
            return _usuarioDataAccess.BuscarTodos();
        }

        public Usuario BuscarUsuarioForID(int idUsuario)
        {
            return _usuarioDataAccess.BuscarUsuarioForID(idUsuario);
        }

        public int ActualizarUsuario(Usuario _usuario)
        {
            return _usuarioDataAccess.ActualizarUsuario(_usuario);
        }

        public void InactivarUsuario(Usuario _usuario)
        {
            _usuarioDataAccess.InactivarUsuario(_usuario);
        }
    }

}
