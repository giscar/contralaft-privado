#pragma warning disable 1591
using System;

namespace SBS.UIF.CONTRALAFT.Entity.Core
{

    public class Plan
    {
     public int Id { get; set; }
     public string Nombre { get; set; }
     public string Descripcion { get; set; }
     public int Version { get; set; }
     public int Estado { get; set; }
     public int FlActivo { get; set; }
     public DateTime FecRegistro { get; set; }
     public string UsuRegistro { get; set; }
     public DateTime FecModificacion { get; set; }
     public string UsuModificacion { get; set; }
     public string EstadoDescripcion { get; set; }
    }
}
#pragma warning restore 1591
