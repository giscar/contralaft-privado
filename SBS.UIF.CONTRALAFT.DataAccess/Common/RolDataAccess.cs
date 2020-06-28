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
        public List<Rol> listarPorRol()
        {
            return (BaseService<Rol>.QueryForList("select_rol", null));
        }

        public int guardarRol(Rol _rol)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_rol", _rol)));
        }
    }
}
