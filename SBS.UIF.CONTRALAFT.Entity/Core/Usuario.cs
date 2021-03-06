﻿#pragma warning disable 1591

using System;

namespace SBS.UIF.CONTRALAFT.Entity.Core
{

    public class Usuario
    {
        public int Id { get; set; }
        public string DetCodigo { get; set; }
        public string DetNombre { get; set; }
        public string DetEmail { get; set; }
        public string CodDocumento { get; set; }
        public string CodExtension { get; set; }
        public int IdPerfil { get; set; }
        public int IdEntidad { get; set; }
        public string DetContrasenia { get; set; }
        public string RazonSocialEntidad { get; set; }
        public int FlActivo { get; set; }
        public DateTime FecRegistro { get; set; }
        public string UsuRegistro { get; set; }
        public DateTime FecModificacion { get; set; }
        public string UsuModificacion { get; set; }
        public string NombrePerfil { get; set; }
        public string ContraseniaEmail { get; set; }
        public string ImageFile { get; set; }
    }
}

#pragma warning restore 1591