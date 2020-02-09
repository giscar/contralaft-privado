using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBS.UIF.BUZ.Entity.Core
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
