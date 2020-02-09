using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBS.UIF.BUZ.Entity.Core
{
    public class Accion
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int FlActivo { get; set; }

    }
}
