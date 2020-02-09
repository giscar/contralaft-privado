﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.BUZ.DataAccess.Core;

namespace SBS.UIF.BUZ.BusinessLogic.Core
{
    public class IndicadorBusinessLogic
    {
        private readonly IndicadorDataAccess _indicadorDataAccess;

        public IndicadorBusinessLogic()
        {
            _indicadorDataAccess = new IndicadorDataAccess();
        }

        public List<Indicador> listarPorIndicador()
        {
            return (_indicadorDataAccess.listarPorIndicador());
        }

        public void guardarIndicador(Indicador _indicador)
        {
            _indicadorDataAccess.guardarIndicador(_indicador);
        }

    }
}
