using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    public class MetaBusinessLogic
    {
        private readonly MetaDataAccess _metaDataAccess;

        public MetaBusinessLogic()
        {
            _metaDataAccess = new MetaDataAccess();
        }

        public int GuardarMeta(Meta _meta)
        {
            return _metaDataAccess.GuardarMeta(_meta);
        }

        public List<Meta> BuscarMetaPorEntidad(Meta _meta)
        {
            return _metaDataAccess.BuscarMetaPorEntidad(_meta);
        }

    }
}
