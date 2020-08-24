using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Common
{
    public class PerfilRolDataAccess
    {

        public int GuardarPerfilRol(PerfilRol _perfilRol)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_perfilRol", _perfilRol)));
        }

        public List<PerfilRol> ValidarPerfilRol(PerfilRol _perfilRol)
        {
            return (BaseService<PerfilRol>.QueryForList("count_perfil_rol", _perfilRol));   
        }

        public void ActualizarPerfilRol(PerfilRol _perfilRol)
        {
            MapperPro.Instance().Update("update_perfil_rol", _perfilRol);
        }
        
    }
}
