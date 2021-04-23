using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class IndicadorEntidadDataAccess
    {
        public void GuardarIndicadorEntidad(IndicadorEntidad _indicadorEntidad)
        {
           Convert.ToInt32(MapperPro.Instance().Insert("insert_indicadorEntidad", _indicadorEntidad));
        }

        public void EliminarIndicadorEntidad(IndicadorEntidad _indicadorEntidad)
        {
            MapperPro.Instance().Delete("eliminar_entidad", _indicadorEntidad);
        }
        
    }
}
