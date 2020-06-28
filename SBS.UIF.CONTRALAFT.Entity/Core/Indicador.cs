#pragma warning disable 1591
using System;

namespace SBS.UIF.CONTRALAFT.Entity.Core
{

    public class Indicador
    {
        public int Id { get; set; }
        public string IdAccion { get; set; }
        public string Detalle { get; set; }
        public string Estado { get; set; }
        public DateTime FecRegistro { get; set; }
        public string UsuRegistro { get; set; }
        public int FlActivo { get; set; }

    }
}
#pragma warning restore 1591
