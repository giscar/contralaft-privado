using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class EntidadDataAccess
    {
        public List<Entidad> listarPorEntidad()
        {
            return (BaseService<Entidad>.QueryForList("select_entidad", null));
        }

        public void guardarEntidad(Entidad _entidad)
        {
           Convert.ToInt32(MapperPro.Instance().Insert("insert_entidad", _entidad));
        }
    }
}
