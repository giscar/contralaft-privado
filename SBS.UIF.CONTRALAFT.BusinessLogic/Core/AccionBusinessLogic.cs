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

        public List<Accion> ListarPorAccion()
        {
            return (_accionDataAccess.ListarPorAccion());
        }

        public void GuardarAccion(Accion _accion)
        {
            _accionDataAccess.GuardarAccion(_accion);
        }

        public Accion BuscarAccionForID(int idAccion)
        {
            return _accionDataAccess.BuscarAccionForID(idAccion);
        }

        public void ActualizarAccion(Accion _accion)
        {
            _accionDataAccess.ActualizarAccion(_accion);
        }

        public void InactivarAccion(Accion _accion)
        {
            _accionDataAccess.InactivarAccion(_accion);
        }

    }
}
