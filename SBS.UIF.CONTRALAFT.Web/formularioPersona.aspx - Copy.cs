using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Configuration;
using NLog;

using SBS.UIF.BUZ.Util;
using SBS.UIF.BUZ.Web.comun;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.BusinessLogic.Common;
using SBS.UIF.BUZ.BusinessLogic.Core;
using Newtonsoft.Json;
using Sbs.Web.Util;
using System.Data;





namespace SBS.UIF.BUZ.Web
{
    public partial class formularioPersona :  PaginaBase 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        List<BienRelacionado> listadoBienes;

        List<Ayuda> listadoAyudaPorTipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            AlertDanger(string.Empty, false, false);
            if (!Page.IsPostBack)
            {
                try
                {
                    CargarTipoPersona();
                    CargarCombos();
                    cargarDepartamento();
                    listadoBienes = new List<BienRelacionado>();
                    limpiarFormulario();
                }
                catch (Exception ex)
                {
                    logger.ErrorException(ex.Message, ex);
                    
                }
            }
        }

        private void CargarCombos()
        {
            LlenarDropDownList(ddlTipoDocumentoPersona, new TiposBusinessLogic().listarPorTipo(17).OrderBy(x => x.CodTipo), "0", Constante.MensajeComboRegistro);
            LlenarDropDownList(ddlBienRelacionado, null, "0", Constante.MensajeComboRegistro);
        }


        private void limpiarFormulario() {
            txtNombrePersona.Value = "";
            ddlTipoDocumentoPersona.SelectedValue = "0";
            ddlTipoPersona.SelectedValue = null;
            txtApellidoPaternoPersona.Value = null;
            txtApellidoMaternoPersona.Value = null;
            txtNroDocumentoPersona.Value = null;
            ddlDepartamento.SelectedValue = "0";
            ddlProvincia.SelectedValue = "0";
            ddlTipoHechoInformarPersona.SelectedValue = "0";
            txtNombresOpcional.Value = null;
            txtApellidoPaternoOpcional.Value = null;
            txtApellidoMaternoOpcional.Value = null;
            txtEmailOpcional.Value = null;
            txtDireccion.Value = null;
            txtDescripcionHecho.Value = null;
            txtRuc.Value = null;
            txtRazonSocial.Value = null;
            
        }
        private void CargarTipoPersona() {
            ddlTipoPersona.Items.Add(new ListItem("Persona <img src='/BC/img/persona.png' alt='persona' height='42' width='42'/>", "P"));
            ddlTipoPersona.Items.Add(new ListItem("Empresa <img src='/BC/img/empresa.png' alt='empresa' height='42' width='42'/>", "E"));
        }

        private void cargarDepartamento() {
            LlenarDropDownList(ddlDepartamento, new UbigeoBusinessLogic().ListarDepartamento().OrderBy(x => x.CodDepartamento), "0", Constante.MensajeComboRegistro);
        }
        protected void Button_Guardar(object sender, EventArgs e)
        {
            string EncodedResponse = Request.Form["g-Recaptcha-Response"];
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "true" ? true : false);

            if (!IsCaptchaValid)
            {
               AlertDanger("Debe de ingresar el captcha", true, false);
               return;
            }

            string cIpAddress = Request.UserHostAddress; 

            string cIpAddress2 = Request.ServerVariables["REMOTE_ADDR"];


            DataGen datagen = new DataGen();
            datagen.codigoDepartamento = ddlDepartamento.SelectedValue;
            datagen.codigoProvincia = ddlProvincia.SelectedValue;
            datagen.direccion = txtDireccion.Value;
            datagen.codigoHechoInformar = int.Parse(ddlTipoHechoInformarPersona.SelectedValue);
            datagen.descripcionHechoInformar = txtDescripcionHecho.Value;
            datagen.nombre = txtNombresOpcional.Value.ToUpper();
            datagen.apellidoPaterno = txtApellidoPaternoOpcional.Value.ToUpper();
            datagen.apellidoMaterno = txtApellidoMaternoOpcional.Value.ToUpper();
            datagen.correo = txtEmailOpcional.Value;
            datagen.ipCreacion= cIpAddress;
            
            string validacion1 = null;
            string validacion2 = null;
            string validacion3 = null;
            if (txtNombrePersona.Value.Length + txtApellidoPaternoPersona.Value.Length + txtApellidoMaternoPersona.Value.Length <= 6)
            {
                validacion1 = "NO";
            }
            if(txtRazonSocial.Value.Length == 0){
                validacion2 = "NO";
            }
            HttpFileCollection hfc = Request.Files;
            int contadorArchivos = 0;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    contadorArchivos++;
                }
            }
            if (contadorArchivos == 0 && datagen.descripcionHechoInformar.Length < 250)
            {
                validacion3 = "NO";
            }

            if (validacion1 == "NO" && validacion3 == "NO" && ddlTipoPersona.SelectedValue == "P")
            {
                datagen.codigoclase = 1;
            }
            if (validacion2 == "NO" && validacion3 == "NO" && ddlTipoPersona.SelectedValue == "E")
            {
                datagen.codigoclase = 1;
            }
            /*if (datagen.codigoclase  null) {
                datagen.codigoclase = 0;
            }*/
 
            int numSecuencia = new DataGenBusinessLogic().guardarCabecera(datagen);


                Persona _persona = new Persona();
                _persona.idSecuencia = numSecuencia;
                _persona.descripcionNombre = txtNombrePersona.Value.ToUpper();
                _persona.tipoDocumento = int.Parse(ddlTipoDocumentoPersona.SelectedValue);
                _persona.descripcionApellidoPaterno = txtApellidoPaternoPersona.Value.ToUpper();
                _persona.descripcionApellidoMaterno = txtApellidoMaternoPersona.Value.ToUpper();
                _persona.descripcionDocumento = txtNroDocumentoPersona.Value;
                _persona.tipoPersona = ddlTipoPersona.SelectedValue;
                if (_persona.tipoPersona == "E")
                {
                    _persona.tipoDocumento = 731;//ruc
                    _persona.descripcionNombre = null;
                    _persona.descripcionApellidoPaterno = null;
                    _persona.descripcionApellidoMaterno = null;
                    _persona.descripcionRazonSocial = txtRazonSocial.Value.ToUpper();
                    _persona.descripcionDocumento = txtRuc.Value;

                }
                else {
                    _persona.descripcionRazonSocial = null;
                }
                new PersonaBusinessLogic().guardarPersona(_persona);

                string jsonObjeto = hdnJsonListaBien.Value;

                var productos = jsonObjeto;

                var listProductos = JsonConvert.DeserializeObject<List<BienRelacionado>>(productos);

                if (listProductos != null)
                    foreach (BienRelacionado prod in listProductos)
                    {
                        BienRelacionado bien = new BienRelacionado();
                        bien.idSecuencia = numSecuencia;
                        bien.descripcionAdicional = prod.descripcionAdicional;
                        bien.codigoBien = prod.codigoBien;
                        bien.descripcionOtros = prod.descripcionOtros;
                        int idbien = new BienRelacionadoBusinessLogic().guardarBienRelacionado(bien);
                    }

                //HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {

                        Byte[] byteFile = new Byte[hpf.ContentLength];
                        hpf.InputStream.Read(byteFile, 0, fileDocumento.PostedFile.ContentLength);
                        Documento documento = new Documento();
                        documento.idSecuencia = numSecuencia;
                        documento.descripcionDocumento = hpf.FileName;
                        documento.blbDocumento = byteFile;
                        new DocumentoBusinessLogic().guardarDocumento(documento);
                    }
                }
                AlertDanger("Tu información es importante para el Perú, sigue colaborando", false, true);
                limpiarFormulario();
        }

        protected void ddlTipoPersona_SelectedIndexChanged(object sender, EventArgs e) {
            string selectorPersona = ddlTipoPersona.SelectedValue;
            if (ddlTipoPersona.SelectedValue.Equals("P")) {
                LlenarDropDownList(ddlTipoHechoInformarPersona, new TiposBusinessLogic().listarPorTipo(92).OrderBy(x => x.DesTipo), "0", Constante.MensajeComboRegistro); //Producción
                LlenarDropDownList(ddlTipoHechoInformarPersona, new TiposBusinessLogic().listarPorTipo(98).OrderBy(x => x.DesTipo), "0", Constante.MensajeComboRegistro); //Desarrollo
            }
            if (ddlTipoPersona.SelectedValue.Equals("E")) {
                LlenarDropDownList(ddlTipoHechoInformarPersona, new TiposBusinessLogic().listarPorTipo(93).OrderBy(x => x.DesTipo), "0", Constante.MensajeComboRegistro); //Producción
                LlenarDropDownList(ddlTipoHechoInformarPersona, new TiposBusinessLogic().listarPorTipo(99).OrderBy(x => x.DesTipo), "0", Constante.MensajeComboRegistro); //Desarrollo
            }
            cargarAyuda();
            upHechoInformar.Update();
        }

        protected void ddlTipoHechoInformarPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectorHecho = int.Parse(ddlTipoHechoInformarPersona.SelectedValue);
            if (selectorHecho == 0)
            {
                LlenarDropDownList(ddlBienRelacionado, null, "0", Constante.MensajeComboRegistro);
            }
            else {
                LlenarDropDownList(ddlBienRelacionado, new TiposBusinessLogic().listarPorSubTipoHecho(selectorHecho).OrderBy(x => x.CodTipo), "0", Constante.MensajeComboRegistro);
            }
            upBienRelacionado.Update();
        }
        

        protected void Button_Valida_SUNAT(object sender, EventArgs e)
        {
            Sunat _sunat = new Sunat();
            _sunat = new SunatBusinessLogic().ObtenerInformacionSunat(txtRuc.Value);
            if (_sunat == null) {
                txtRazonSocial.Value = null;
                AlertDanger("Verificar el Nro. de RUC", true, false);
                return;
            }
            txtRazonSocial.Value = _sunat.RazSoc;
            upRazonSocial.Update();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e) {
            Ubigeo u = new Ubigeo();
            u.CodDepartamento = ddlDepartamento.SelectedValue;
            LlenarDropDownList(ddlProvincia, new UbigeoBusinessLogic().ListarProvincia(u).OrderBy(x => x.CodDepartamento), "0", Constante.MensajeComboRegistro);
            upProvincia.Update();
        }

        private void AlertDanger(string pmessage, bool pvisibleD, bool pvisibleS)
        {
            idModalAlertaServer.Visible = pvisibleD;
            lblMensajePeligro.Text = pmessage;

             idModalInfoServer.Visible = pvisibleS;
             lblMensajeOk.Text = pmessage;
        }

        private void cargarAyuda() {
            listadoAyudaPorTipo = null;
            if(ddlTipoPersona.SelectedValue == "P" )
                listadoAyudaPorTipo = new AyudaBusinessLogic().buscarAyudaPersona();
            if (ddlTipoPersona.SelectedValue == "E")
                listadoAyudaPorTipo = new AyudaBusinessLogic().buscarAyudaEmpresa();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("detalleLista", typeof(string)); 
            dt.Columns.Add("detalle", typeof(string));
            
            foreach (Ayuda a in listadoAyudaPorTipo){
                DataRow row = dt.NewRow();
                row["detalleLista"] = a.detalleLista;
                row["detalle"] = a.detalle;
                dt.Rows.Add(row);
            }
            GridView_Ayuda.DataSource = dt;
            GridView_Ayuda.DataBind();
        }

    }

}