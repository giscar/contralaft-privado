using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    public class IndicadorBusinessLogic
    {
        private readonly IndicadorDataAccess _indicadorDataAccess;

        public IndicadorBusinessLogic()
        {
            _indicadorDataAccess = new IndicadorDataAccess();
        }

        public Indicador ListarIndicadorForId(int idIndicador)
        {
            return _indicadorDataAccess.ListarIndicadorForId(idIndicador);
        }

        public List<Indicador> ListarIndicadorAll()
        {
            return _indicadorDataAccess.ListarIndicadorAll();
        }

        public List<Indicador> ListarIndicadorForAccionEntidad(Indicador indicador)
        {
            return _indicadorDataAccess.ListarIndicadorForAccionEntidad(indicador);
        }

        public List<Indicador> ListarIndicadorForAccion(int idAccion)
        {
            return _indicadorDataAccess.ListarIndicadorForAccion(idAccion);
        }

        public int GuardarIndicador(Indicador _indicador)
        {
            return _indicadorDataAccess.GuardarIndicador(_indicador);
        }

        public void ActualizarIndicador(Accion _accion)
        {
            _indicadorDataAccess.ActualizarIndicador(_accion);
        }

        public void InactivarAccion(Accion _accion)
        {
            _indicadorDataAccess.InactivarAccion(_accion);
        }

    }
}
