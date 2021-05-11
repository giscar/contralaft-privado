using System;

using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Mapper;
using System.Collections.Generic;

namespace SBS.UIF.CONTRALAFT.DataAccess.Core
{

    public class MetaDataAccess {

        public int GuardarMeta(Meta _meta)
        {
            return Convert.ToInt32(MapperPro.Instance().Insert("insert_meta", _meta));
        }

        public Meta BuscarMetaPorEntidad(Meta _meta)
        {
            return BaseService<Meta>.QueryForObject("select_metas_entidad", _meta);
        }

        public Meta BuscarMetaEnviadUIF(Meta _meta)
        {
            return BaseService<Meta>.QueryForObject("select_metas_enviado_uif", _meta);
        }
        
        public void ActualizarMeta(Meta _meta)
        {
            MapperPro.Instance().Update("update_meta", _meta);
        }

        public void ClasificarUIF(Meta _meta)
        {
            MapperPro.Instance().Update("update_clasificacion", _meta);
        }
        

    }
}
