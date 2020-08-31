using System;

using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;
using System.Collections.Generic;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{

    public class UsuarioDataAccess {

        public int GuardarPersona(Usuario _usuario)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_usuario", _usuario)));
        }

        public Usuario BuscarUsuario(Usuario _usuario)
        {
            return (BaseService<Usuario>.QueryForObject("select_usuario", _usuario));
        }

        public List<Usuario> BuscarTodos()
        {
            return (BaseService<Usuario>.QueryForList("select_todos", null));
        }

        public Usuario BuscarUsuarioForID(int idUsuario)
        {
            return (BaseService<Usuario>.QueryForObject("select_usuario_id", idUsuario));
        }

        public int ActualizarUsuario(Usuario _usuario)
        {
            return (Convert.ToInt32(MapperPro.Instance().Update("update_usuario", _usuario)));
        }

        public void InactivarUsuario(Usuario _usuario)
        {
            MapperPro.Instance().Update("inactive_usustio", _usuario);
        }

    }
}
