using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.BUZ.DataAccess.Core;

namespace SBS.UIF.BUZ.BusinessLogic.Core
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
