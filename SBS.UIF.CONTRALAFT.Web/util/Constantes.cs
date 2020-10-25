using System;
namespace SBS.UIF.CONTRALAFT.Web.util
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

        public enum PerfilFlag
        {
            ADMINISTRADOR = '1'
        }

        public const String PaginaInicioLogin = "../pages/login.aspx";
        public const String codigoPerfilAdministrador = "1";
        public const String codigoPerfilGestor = "2";
        public const String selectValueDefault = "0";
        public const String selectLabelDefault = "Seleccione";
        public const String textoSubject = "Se le ha creado el acceso para ingresar al módulo de monitoreo en el cumplimiento de las acciones del Plan Nacional contra el LA/FT 2018-2021:";
        public const String estadoPlanBORRADOR = "Borrador";
        public const String estadoPlanPUBLICADO = "Publicado";

    }
}
