#pragma warning disable 1591
using System;

namespace SBS.UIF.CONTRALAFT.Entity.Core
{

    public class Meta
    {
        public int Id { get; set; }
        public int IdIndicador { get; set; }
        public int IdEntidad { get; set; }
        public int NumeroBase { get; set; }
        public string MedioVerificacion { get; set; }
        public string Descripcion { get; set; }
        public string CodDocumento { get; set; }
        public string CodExtension { get; set; }
        public int FlActivo { get; set; }
        public int Estado { get; set; }
        public string UsuRegistro { get; set; }
        public DateTime FecRegistro { get; set; }
        public string UsuModificacion { get; set; }
        public DateTime FecModificacion { get; set; }
        public string ImageFile { get; set; }
    }
}
#pragma warning restore 1591