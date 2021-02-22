using System;
namespace SBS.UIF.CONTRALAFT.Util
{
    public class Constantes
    {
        public enum EstadoFlag
        {
            ACTIVO = 1,
            INACTIVO = 0
        }

        public enum EstadoPlan
        {
            BORRADOR = 0,
            PUBLICADO = 1,
            DESPUBLICADO = 2
        }

        public enum EstadoMeta
        {
            BORRADOR = 0,
            PUBLICADO = 1
        }

        public enum EstadoVigencia
        {
            NOVIGENTE = 0,
            VIGENTE = 1
        }

        public enum PerfilFlag
        {
            ADMINISTRADOR = 1,
            GESTOR = 2,
            TITULAR = 3,
            SUPLEMENTARIO = 4
        }

        public enum EntidadFlag
        {
            SBS = 2
        }

        public const String PaginaInicioLogin = "../pages/login.aspx";
        public const String selectValueDefault = "0";
        public const String selectLabelDefault = "Seleccione";
        public const String textoSubject = "Creación de usuario del modulo de CONTRALAFT";
        public const String estadoPlanBORRADOR = "Borrador";
        public const String estadoPlanPUBLICADO = "Publicado";
        public const String estadoVigente = "Vigente";
        public const String estadoNoVigente = "No Vigente";

    }
}
