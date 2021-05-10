#pragma warning disable 1591
using System;
using System.Collections.Generic;

namespace SBS.UIF.CONTRALAFT.Entity.Core
{

    public class Indicador
    {
        public int Id { get; set; }
        public int IdAccion { get; set; }
        public string Detalle { get; set; }
        public string Nombre { get; set; }
        public DateTime FecRegistro { get; set; }
        public string UsuRegistro { get; set; }
        public DateTime FecModificacion { get; set; }
        public string UsuModificacion { get; set; }
        public int FlActivo { get; set; }
        public List<Entidad> ListaEntidades { get; set; }
        public int IdEntidadBusqueda { get; set; }
        public string NombreEntidadBusqueda { get; set; }
        public string Anho { get; set; }
        public int CodEstadoMeta { get; set; }
        public string DetEstadoMeta { get; set; }
        public int CodEstadoIndicador { get; set; }
        public string DetEstadoIndicador { get; set; }
    }
}

#pragma warning restore 1591
