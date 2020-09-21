using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class EntidadDataAccess
    {
        public List<Entidad> ListarPorEntidad()
        {
            return (BaseService<Entidad>.QueryForList("select_entidad", null));
        }

        public void GuardarEntidad(Entidad _entidad)
        {
           Convert.ToInt32(MapperPro.Instance().Insert("insert_entidad", _entidad));
        }

        public Entidad EntidadForId(int _idEntidad)
        {
            return (BaseService<Entidad>.QueryForObject("select_entidad_id", _idEntidad));
        }
        
    }
}
