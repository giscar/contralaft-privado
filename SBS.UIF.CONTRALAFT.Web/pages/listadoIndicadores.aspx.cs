using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class listadoIndicadores : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        IndicadorBusinessLogic _indicadorBusinessLogic = new IndicadorBusinessLogic();

        IndicadorEntidadBusinessLogic _indicadorEntidadBusinessLogic = new IndicadorEntidadBusinessLogic();

        AccionBusinessLogic _accionBusinessLogic = new AccionBusinessLogic();

        EntidadBusinessLogic _entidadBusinessLogic = new EntidadBusinessLogic();

        MetaBusinessLogic _metaBusinessLogic = new MetaBusinessLogic();

        List<Accion> listadoAccion;

        List<Indicador> listadoIndicador;

        List<Entidad> ListadoEntidad = new List<Entidad>();

        public string tipoDocumentoMeta;

        public string rutaDocumento;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (UsuarioSession() == null)
                    {
                        Response.Redirect(Constantes.paginaInicioLogin);
                    }
                    CargarLista();
                    CargarAnho();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }

        private void CargarAnho()
        {
            int year = DateTime.Now.Year;
            for (int i = year - 2; i <= year + 2; i++)
            {
                ListItem li = new ListItem(i.ToString());
                ddlCodigoAnho.Items.Add(li);
            }
            ddlCodigoAnho.Items.FindByText(year.ToString()).Selected = true;
        }

        private void CargarEntidades()
        {
            LlenarDropDownList(ddlCodigoEntidad, new EntidadBusinessLogic().ListarPorEntidad().OrderBy(x => x.DesTipo), "0", "Seleccione");
        }

        private void CargarLista()
        {
            listadoAccion = _accionBusinessLogic.ListarPorAccion();
            foreach (Accion item in listadoAccion)
            {
                item.ListaIndicadores = _indicadorBusinessLogic.ListarIndicadorForAccion(item.Id);
                foreach (Indicador item1 in item.ListaIndicadores)
                {
                    item1.IdAccion = item.Id;
                    item1.ListaEntidades = _entidadBusinessLogic.ListarPorEntidadforIndicador(item1.Id);
                    
                    foreach (Entidad item2 in item1.ListaEntidades)
                    {
                        item2.IdIndicador = item1.Id;
                        item2.IdAccion = item1.IdAccion;
                        item2.DetEstadoEntidadIndicador = Constantes.estadoIndicadorNoRecibido;
                        Meta _meta = new Meta();
                        _meta.IdEntidad = item2.IdTipo;
                        _meta.IdIndicador = item1.Id;
                        _meta = _metaBusinessLogic.BuscarMetaPorEntidad(_meta);
                        item1.DetEstadoMeta = Constantes.estadoMetaSinRegistro;
                        if (_meta != null)
                        {
                            item1.CodEstadoMeta = _meta.Estado;
                          
                            if (item1.CodEstadoMeta == 1)
                            {
                                item2.DetEstadoEntidadIndicador = Constantes.estadoIndicadorRecibido;
                                if (_meta.EstadoUIF == (int)Constantes.IndicadorEstadoFlag.PENDIENTE) {
                                    item2.DetEstadoEntidadIndicador = Constantes.estadoIndicadorPendiente;
                                }
                                if (_meta.EstadoUIF == (int)Constantes.IndicadorEstadoFlag.CULMINADO)
                                {
                                    item2.DetEstadoEntidadIndicador = Constantes.estadoIndicadorCulminado;
                                }
                            }

                        }
                    }
                }
            }
            GridView1.DataSource = listadoAccion;
            GridView1.DataBind();
        }

        protected void Submit_guardar_clasificacion(object sender, EventArgs e)
        {
            try
            {
                Meta _meta = new Meta();
                _meta.IdEntidad = int.Parse(hddIdCodigoEntidad.Value);
                _meta.IdIndicador = int.Parse(hddIdCodigoIndicador.Value);
                _meta.EstadoUIF = int.Parse(ddlCodigoClasificacionUIF.SelectedValue);
                _metaBusinessLogic.ClasificarUIF(_meta);
                ClientMessageBox.Show("Se realizo la clasificacion del estado de la meta", this);
                upListadoEntidades.Update();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void DdlTipoEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectorEntidad = ddlCodigoEntidad.SelectedValue;
                Entidad entidad = _entidadBusinessLogic.EntidadForID(int.Parse(selectorEntidad.ToString()));
                IndicadorEntidad ie = new IndicadorEntidad();
                ie.IdIndicador = (int)ViewState["idIndicadorAccion"];
                ie.IdEntidad = entidad.IdTipo;
                ie.FlActivo = (int)Constantes.EstadoFlag.ACTIVO;
                ie.Estado = (int)Constantes.EstadoFlag.ACTIVO;
                _indicadorEntidadBusinessLogic.GuardarIndicadorEntidad(ie);
                ListadoEntidad = _entidadBusinessLogic.ListarPorEntidadforIndicador(ie.IdIndicador);
                GridView2.DataSource = ListadoEntidad;
                GridView2.DataBind();
                upListadoEntidades.Update();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Editar_Indicador(object sender, EventArgs e)
        {
            try
            {
                Indicador _indicador = new Indicador();
                _indicador.Id = (int)ViewState["idIndicadorAccion"];
                _indicador.Nombre = txtNombreIndicador.Value;
                _indicador.Detalle = txtDetalleIndicador.Value;
                _indicador.Anho = ddlCodigoAnho.SelectedValue;
                _indicador.FecModificacion = DateTime.Now;
                _indicador.UsuModificacion = UsuarioSession().DetCodigo;
                _indicadorBusinessLogic.ActualizarIndicador(_indicador);
                CargarLista();
                Response.Redirect("listadoIndicadores.aspx");
                ClientMessageBox.Show("Se modificó el indicador seleccionado", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridAccion_RowCommandEntidad(object sender, GridViewCommandEventArgs e)
        {
            IndicadorEntidad _indicadorEntidad = new IndicadorEntidad();
            _indicadorEntidad.IdIndicador = (int)ViewState["idIndicadorAccion"];
            _indicadorEntidad.IdEntidad = int.Parse(e.CommandArgument.ToString());
            _indicadorEntidadBusinessLogic.EliminarIndicadorEntidad(_indicadorEntidad);
            ListadoEntidad = _entidadBusinessLogic.ListarPorEntidadforIndicador(_indicadorEntidad.IdIndicador);
            GridView2.DataSource = ListadoEntidad;
            GridView2.DataBind();
            upListadoEntidades.Update();
        }

        protected void GriIndicador_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idIndicadorAccion"] = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "editar")
            {
                CargarEntidades();
                ListadoEntidad = _entidadBusinessLogic.ListarPorEntidadforIndicador((int)ViewState["idIndicadorAccion"]);
                Indicador _indicador = new Indicador();
                _indicador = _indicadorBusinessLogic.ListarIndicadorForId((int)ViewState["idIndicadorAccion"]);
                txtNombreIndicador.Value = _indicador.Nombre;
                txtDetalleIndicador.Value = _indicador.Detalle;
                ddlCodigoAnho.SelectedValue = _indicador.Anho;
                GridView2.DataSource = ListadoEntidad;
                GridView2.DataBind();
                upListadoEntidades.Update();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() { $('#indicador').modal({backdrop: 'static',keyboard: false}); });");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "indicador", sb.ToString(), false);
            }

            if (e.CommandName == "inactivar")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#inactivar').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivar", sb.ToString(), false);
            }
        }

        protected void GridAccion2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            string idEntidad = arg[0];
            string idIndicador = arg[1];
            string idAccion = arg[2];

            hddIdCodigoEntidad.Value = idEntidad;
            hddIdCodigoIndicador.Value = idIndicador;

            if (e.CommandName == "avance")
            {
                Indicador indicador = _indicadorBusinessLogic.ListarIndicadorForId(int.Parse(idIndicador));
                Accion accion = _accionBusinessLogic.BuscarAccionForID(int.Parse(idAccion));
                Meta meta = new Meta
                {
                    IdEntidad = int.Parse(idEntidad),
                    IdIndicador = int.Parse(idIndicador)
                };
                meta = _metaBusinessLogic.BuscarMetaEnviadUIF(meta);
                if (meta == null)
                {
                    Limpiar();
                    divVisualizarDocumento.Visible = false;
                    borradorMeta.Visible = false;
                }
                else
                {
                    Cargar(meta);
                }

                lblAccionTitulo.Text = accion.Nombre;
                lblIndicadorTitulo.Text = indicador.Nombre;
                lblIndicadorAnho.Text = indicador.Anho;

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() { $('#resultado').modal({backdrop: 'static',keyboard: false}); });");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "resultado", sb.ToString(), false);
            }
        }

        private void Limpiar()
        {
            txtMedioVerificacion.Value = "";
            txtDescripcion.Value = "";
            txtNumero.Value = "";
        }

        private void Cargar(Meta meta)
        {
            txtMedioVerificacion.Value = meta.MedioVerificacion;
            txtDescripcion.Value = meta.Descripcion;
            txtNumero.Value = meta.NumeroBase.ToString();
            ViewState["documento"] = meta.CodDocumento;
            rutaDocumento = "../App_Data/" + meta.CodDocumento;
            if (meta.CodExtension != null)
            {
                tipoDocumentoMeta = Constantes.iconoOtros;
                if (meta.CodExtension == Constantes.extensionDoc)
                {
                    tipoDocumentoMeta = Constantes.iconoDoc;
                }
                if (meta.CodExtension == Constantes.extensionPdf)
                {
                    tipoDocumentoMeta = Constantes.iconoPdf;
                }
                if (meta.CodExtension == Constantes.extensionZip)
                {
                    tipoDocumentoMeta = Constantes.iconoZip;
                }
            }

            if (meta.CodDocumento != null)
            {
                divVisualizarDocumento.Visible = true;
            }
            else
            {
                divVisualizarDocumento.Visible = false;
            }

        }

        protected void Submit_descargar(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(Path.Combine(Constantes.uploadFile, ViewState["documento"].ToString()));
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }

        protected void Submit_inactiveIndicador(object sender, EventArgs e)
        {
            try
            {
                Indicador indicador = new Indicador
                {
                    Id = (int)ViewState["idIndicadorAccion"],
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.INACTIVO
                };
                _indicadorBusinessLogic.InactivarIndicador(indicador);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se inactivo el indicador", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridAccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

    }
}