using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.DataAccess.Core;

namespace SBS.UIF.CONTRALAFT.BusinessLogic.Core
{
    public class IndicadorEntidadBusinessLogic
    {
        private readonly IndicadorEntidadDataAccess _indicadorEntidadDataAccess;

        public IndicadorEntidadBusinessLogic()
        {
            _indicadorEntidadDataAccess = new IndicadorEntidadDataAccess();
        }

        public void GuardarIndicadorEntidad(IndicadorEntidad _indicadorEntidad)
        {
            _indicadorEntidadDataAccess.GuardarIndicadorEntidad(_indicadorEntidad);
        }

        public void EliminarIndicadorEntidad(IndicadorEntidad _indicadorEntidad)
        {
            _indicadorEntidadDataAccess.EliminarIndicadorEntidad(_indicadorEntidad);
        }
    }
}
