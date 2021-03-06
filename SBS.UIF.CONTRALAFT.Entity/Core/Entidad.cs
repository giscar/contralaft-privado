﻿#pragma warning disable 1591

using System;

namespace SBS.UIF.CONTRALAFT.Entity.Core
{
    public class Entidad
    {
        public int IdTipo { get; set; }
        public string DesTipo { get; set; }
        public string CodRuc { get; set; }
        public string UsuRegistro { get; set; }
        public DateTime FecRegistro { get; set; }
        public int FlActivo { get; set; }
        public int IdIndicador { get; set; }
        public int IdAccion { get; set; }
        public int CodEstadoEntidadIndicador { get; set; }
        public string DetEstadoEntidadIndicador { get; set; }
    }
}
#pragma warning restore 1591