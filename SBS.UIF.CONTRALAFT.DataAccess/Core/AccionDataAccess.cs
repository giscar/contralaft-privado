using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class AccionDataAccess
    {
        public List<Accion> listarPorAccion()
        {
            return (BaseService<Accion>.QueryForList("select_accion", null));
        }

        public void guardarAccion(Accion _accion)
        {
           Convert.ToInt32(MapperPro.Instance().Insert("insert_accion", _accion));
        }
    }
}
