using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    public class AccionBusinessLogic
    {
        private readonly AccionDataAccess _accionDataAccess;

        public AccionBusinessLogic()
        {
            _accionDataAccess = new AccionDataAccess();
        }

        public List<Accion> listarPorAccion()
        {
            return (_accionDataAccess.listarPorAccion());
        }

        public void guardarAccion(Accion _accion)
        {
            _accionDataAccess.guardarAccion(_accion);
        }

    }
}
