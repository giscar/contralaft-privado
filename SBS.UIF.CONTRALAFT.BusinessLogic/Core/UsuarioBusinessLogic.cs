using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    
    public class UsuarioBusinessLogic {
        private readonly UsuarioDataAccess _usuarioDataAccess;

        public UsuarioBusinessLogic()
        {
            _usuarioDataAccess = new UsuarioDataAccess();
        }

        public int guardarPersona(Usuario _usuario)
        {
            return (_usuarioDataAccess.guardarPersona(_usuario));   
        }

        public Usuario buscarUsuario(Usuario _usuario)
        {
            return _usuarioDataAccess.buscarUsuario(_usuario);
        }

        public List<Usuario> buscarTodos() {
            return _usuarioDataAccess.buscarTodos();
        }

        public Usuario buscarUsuarioForID(int idUsuario) {
            return _usuarioDataAccess.buscarUsuarioForID(idUsuario);
        }
    }

}
