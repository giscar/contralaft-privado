using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using SBS.UIF.BUZ.Entity.Core;

namespace SBS.UIF.BUZ.Util
{

    public class Constante {

        

        public const String MensajeComboRegistro = "- Seleccione -";
        public const String MensajeComboReporte = "- Todos -";
        

        

        #region Enumeradores SIGSO
        //SIGSO: int_sso_tipos{amb_tipo='DOCU'}
        public enum TipoDocumentoIdentidad {
            DNI = 1,
            RUC = 2,
            CE = 3,
            PAS = 187
        }

        //SIGSO: int_sso_tipos{amb_tipo='TIDI'}
        public enum TipoDireccion {
            OficinaPrincipal = 13,
            Almacen = 14,
            Sucursal = 15,
            Domicilio = 200
        }

        //SIGSO: int_sso_tipos{amb_tipo='TIPE'}
        public enum TipoPersona {
            PN = 35,
            PJ = 34
        }

        //SIGSO: int_sso_tipos{amb_tipo='ESTS'}
        public enum EstadoSunat {
            Activo = 0,
            BajaProvisional = 1,
            BajaProvisionalPorOficio = 2,
            SuspensionTemporal = 3,
            BajaDefinitiva = 10,
            BajaOficio = 11,
            BajaMultipleInscripcion = 12
        }

        //SIGSO: int_sso_estados{amb_estado='ESSO'}
        public enum EstadoSOSIGSO {
            Aprobado = 4,
            DeBaja = 6,
            Identificado = 461,
            Rechazado = 463,
            Eliminado = 465
        }

        //SIGSO: int_sso_estados{amb_estado='ESOC'}
        public enum EstadoOCSIGSO {
            Aprobado = 8,
            DeBaja = 9,
            Tramite = 7,
            Rechazado = 14
        }

        //PLAFT: listas{n_c_listapadre=4}
        public enum EstadoOCPLAFT {
            Activo = 68,
            Inactivo = 69,
            Inicial = 70,
            Bloqueado = 2083
        }

        //SIGSO: int_sso_tipos_sujeto{}
        public enum TipoSujetoObligado {
            CompraVentaDivisas = 31,
            PrestamosEmpeniosGarantiaPignatoria = 35,
            Notarios = 75,
            PrestamosEmpeniosDL1249 = 319
        }

        //SIGSO: int_sso_tipos{amb_tipo='TITE'}
        public enum TipoTelefono {
            Celular = 21,
            OficinaFijo = 19,
            OFicinaFax = 20,
            Casa = 199
        }

        //SIGSO: int_sso_tipos{amb_tipo='CAOC'}
        public enum TipoCategoria {
            Principal = 180,
            Alterno = 76
        }

        //SIGSO: view_ubigeo{}
        public enum Departamento {
            Lima = 15
        }

        //SIGSO: view_ubigeo{}
        public enum Provincia {
            Lima = 01
        }

        //SIGSO: int_sso_tipos{amb_tipo='PRCE'}
        public enum TipoCorreo {
            Personal = 1205,
            Empresarial = 1206
        }

        //SIGSO: int_sso_estados{amb_tipo='ESRE'}
        public enum EstadoRegistroSIGSO {
            Activo = 2,
            Inactivo = 3
        }

        //SIGSO: int_sso_tipos{amb_tipo='COMN'}
        public enum TipoComunicacionSIGSO {
            Estado = 22,
            MotivoRegistro = 24
        }

        //SIGSO: int_sso_tipos{amb_tipo='MORE'}
        public enum TipoSeleccionSIGSO {
            RecepcionDesignacionOC = 33,
            SISDEL = 93149
        }

        //SIGSO: int_sso_tipos{amb_tipo='DIM'}
        public enum TipoDocumentoSIGSO {
            Carta = 10,
            Expediente = 11,
            Resolucion = 12,
            Circular = 64,
            Oficio = 112,
            Memorando = 316,
            SobreCerrado = 93091
        }

        public enum FuentesSIGSO {
            SISGED = 1,
            STD = 2
        }

        //SIGSO: int_sso_tipos{amb_tipo='MOCS'}
        public enum MotivoAsigSIGSO {
            Extravio = 78,
            Inicio = 251,
            SuspensionTemporal = 253
        }

        //SIGSO: int_sso_tipos{amb_tipo='ORCS'}
        public enum OrigenSIGSO {
            HeredadoLotusNotes = 1087,
            GeneracionCombinada = 1088
        }

        //SIGSO: int_sso_tipos{amb_tipo='OFCU'}
        public enum TipoOCSIGSO {
            Simple = 4,
            Corporativo = 5
        }

        #endregion

        #region Enumeradores SISDEL

        //SISDEL: int_spac_maestro_tabla{cod_tabla=1}
        public enum EstadoRegistro {
            Activo = 1,
            Inactivo = 2
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=2}
        public enum EstadoUsuario {
            Inicial = 1,
            Activo = 2,
            Bloqueado = 3,
            Inactivo = 4
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=5}
        public enum EstadoSolicitud {
            RegistradoSO = 1,
            RegistradoOC = 2,
            RegistradoDA = 3,
            RevisadoMP = 4,
            RevisadoJA = 5,
            RevisadoCA = 6,
            RevisadoAA = 7
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=15}
        public enum EstadoSolicitudExt {
            Borrador = 1,
            Enviado = 2
        }


        //SISDEL: int_spac_maestro_tabla{cod_tabla=6}
        public enum TipoOperacionLogClave {
            NuevaClave = 1,
            CambioClave = 2
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=7}
        public enum EstadoLogClave {
            ClaveSolicitada = 1,
            ClaveAsignada = 2
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=3}
        public enum TipoDesignacionOC {
            CambioOC = 1,
            NuevoOC = 2
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=8}
        public enum TipoDocSustentatorio {
            HojaVida = 1,
            DJ = 2,
            Carta = 3,
            Otros = 4,
            ActaSesion = 5
        }

        //SISDEL: int_spac_maestro_tabla{cod_tabla=17}
        public enum TipoAlcanceFin {
            ActualizarEnSIGSO = 1,
            NoActualizarEnSIGSO = 2
        }

        //SISDEL: int_sso_paises{}
        public enum Pais {
            Peru = 283
        }

        //SISDEL: Temporal
        public enum EstadoRegistroTemp {
            Nuevo = 1,
            Igual = 0,
            Eliminado = -1
        }
        //Tipo Dedicacion OC
        public enum TipoDedicacionOC {
            Exclusivo = 8,
            NoExclusivo = 9
        }

        //tipo de formatos de documentos (dj y cartas)
        public enum TipoDocumentoFormatoCodigo {
            DJ = 1,
            CARTA = 2
        }

        public enum TipoDocumentoFormatoValor {
            DJ = 9,
            CARTA = 12
        }

        public enum TituloCarta {
            Formato1 = 1
        }

        public enum Prioridad {
            Normal = 1,
            Prioritario = 2,
            Urgente = 3
        }


        #endregion

        #region Funciones de Igualdad
        public static string ObtieneTipoDocumentoIdentidadSPP(int pcodTipoDocumentoIdentidadSISDEL) {
            string rpta = "";
            switch (pcodTipoDocumentoIdentidadSISDEL){
                case (int)TipoDocumentoIdentidad.DNI: 
                    rpta = "00";
                    break;
                case (int)TipoDocumentoIdentidad.CE:
                    rpta = "01";
                    break;
                case (int)TipoDocumentoIdentidad.PAS:
                    rpta = "04";
                    break;
            }
            return (rpta);
        }

        public static string ObtieneTipoDocumentoIdentidadROSEL(int pcodTipoDocumentoIdentidadSISDEL) {
            string rpta = "";
            switch (pcodTipoDocumentoIdentidadSISDEL) {
                case (int)TipoDocumentoIdentidad.DNI:
                    rpta = "729";
                    break;
                case (int)TipoDocumentoIdentidad.CE:
                    rpta = "725";
                    break;
                case (int)TipoDocumentoIdentidad.PAS:
                    rpta = "730";
                    break;
            }
            return (rpta);
        }

        #endregion
    }
}