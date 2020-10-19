using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    public class EntidadBusinessLogic
    {
        private readonly EntidadDataAccess _entidadDataAccess;

        public EntidadBusinessLogic()
        {
            _entidadDataAccess = new EntidadDataAccess();
        }

        public List<Entidad> ListarPorEntidad()
        {
            return (_entidadDataAccess.ListarPorEntidad());
        }

        public void GuardarEntidad(Entidad _entidad)
        {
            _entidadDataAccess.GuardarEntidad(_entidad);
        }

        public Entidad EntidadForID(int _idEntidad)
        {
            return (_entidadDataAccess.EntidadForId(_idEntidad));
        }

        public List<Entidad> ListarPorEntidadforIndicador(int _idIndicador)
        {
            return _entidadDataAccess.ListarPorEntidadIndicador(_idIndicador);
        }

    }
}
