using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBS.UIF.BUZ.Entity.Common
{
    public class Menu
    {
        public int Id { get; set; }
        public int CodPadre { get; set; }
        public string DesNombre { get; set; }
        public string CodIcon { get; set; }
        public string NomPage { get; set; }
        public int FlActivo { get; set; }

    }
}
