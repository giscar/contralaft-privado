#pragma warning disable 1591

using System;

namespace SBS.UIF.CONTRALAFT.Entity.Common
{
    public class Perfil
    {
        public int IdTipo { get; set; }
        public string DesTipo { get; set; }
        public string DetDetalle { get; set; }
        public string DetUsuarioRegistro { get; set; }
        public string DetUsuarioModificacion { get; set; }
        public int FlagEstado { get; set; }
        public DateTime FecModificacion { get; set; }
        public DateTime FecRegistro { get; set; }
    }
}

#pragma warning restore 1591