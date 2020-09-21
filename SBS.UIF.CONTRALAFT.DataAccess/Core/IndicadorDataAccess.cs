using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{
    public class IndicadorDataAccess
    {
        public List<Indicador> listarPorIndicador()
        {
            return (BaseService<Indicador>.QueryForList("select_indicador", null));
        }

        public void guardarIndicador(Indicador _indicador)
        {
           Convert.ToInt32(MapperPro.Instance().Insert("insert_indicador", _indicador));
        }
    }
}
