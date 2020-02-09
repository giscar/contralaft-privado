using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.BUZ.DataAccess.Mapper;

namespace SBS.UIF.BUZ.DataAccess.Core
{
    public class IndicadorEntidadDataAccess
    {
        public void guardarIndicadorEntidad(IndicadorEntidad _indicadorEntidad)
        {
           Convert.ToInt32(MapperPro.Instance().Insert("insert_indicadorEntidad", _indicadorEntidad));
        }
    }
}
