using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.BUZ.DataAccess.Mapper;

namespace SBS.UIF.BUZ.DataAccess.Core
{
    public class EntidadDataAccess
    {
        public List<Entidad> listarPorEntidad()
        {
            return (BaseService<Entidad>.QueryForList("select_entidad", null));
        }
    }
}
