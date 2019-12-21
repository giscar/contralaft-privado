using System;

using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.DataAccess.Mapper;
using System.Collections.Generic;

namespace SBS.UIF.BUZ.DataAccess.Core
{

    public class UsuarioDataAccess {

        public int guardarPersona(Usuario _usuario)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_usuario", _usuario)));
        }

        public Usuario buscarUsuario(Usuario _usuario)
        {
            return (BaseService<Usuario>.QueryForObject("select_usuario", _usuario));
        }

        public List<Usuario> buscarTodos()
        {
            return (BaseService<Usuario>.QueryForList("select_todos", null));
        }

    }
}
