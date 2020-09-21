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

        public void guardarIndicadorEntidad(IndicadorEntidad _indicadorEntidad)
        {
            _indicadorEntidadDataAccess.guardarIndicadorEntidad(_indicadorEntidad);
        }

    }
}
