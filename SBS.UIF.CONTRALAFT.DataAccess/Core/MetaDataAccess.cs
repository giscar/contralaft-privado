using System;

using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;
using System.Collections.Generic;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{

    public class MetaDataAccess {

        public int GuardarMeta(Meta _meta)
        {
            return (Convert.ToInt32(MapperPro.Instance().Insert("insert_meta", _meta)));
        }

        public List<Meta> BuscarMetaPorEntidad(Meta _meta)
        {
            return (BaseService<Meta>.QueryForList("select_metas_entidad", null));
        }

    }
}
