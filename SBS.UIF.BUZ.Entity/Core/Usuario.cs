using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBS.UIF.BUZ.Entity.Core
{
    public class Usuario
    {
        public int Id { get; set; }

        public String DetCodigo { get; set; }

        public String DetNombre { get; set; }

        public int IdPerfil { get; set; }

        public int IdEntidad { get; set; }

        public int FlActivo { get; set; }

        public DateTime FecRegistro { get; set; }

        public String UsuRegistro { get; set; }

        public String DetContrasenia { get; set; }

        public String RazonSocialEntidad { get; set; }
        

    }
}