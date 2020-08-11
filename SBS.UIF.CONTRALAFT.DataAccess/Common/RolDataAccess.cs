using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Common
{
    public class RolDataAccess
    {
        public List<Rol> ListarPorRol()
        {
            return (BaseService<Rol>.QueryForList("select_rol", null));
        }

        public int GuardarRol(Rol _rol)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_rol", _rol)));
        }

        public void ActualizarRol(Rol _rol)
        {
            MapperPro.Instance().Update("update_rol", _rol);
        }

        public void InactivarRol(Rol _rol)
        {
            MapperPro.Instance().Update("inactive_rol", _rol);
        }
        
    }
}
