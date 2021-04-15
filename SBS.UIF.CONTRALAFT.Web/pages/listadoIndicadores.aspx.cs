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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (UsuarioSession() == null)
                    {
                        Response.Redirect(Constantes.PaginaInicioLogin);
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
                    }
                }
            }
            GridView1.DataSource = listadoAccion;
            GridView1.DataBind();
        }

        protected void Submit_guardar_estado(object sender, EventArgs e)
        {

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
                ClientMessageBox.Show("Se modificó el indicador seleccionado", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


        protected void GriIndicador_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idIndicadorAccion"] = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "editar")
            {
                CargarEntidades();
                Indicador _indicador = new Indicador();
                _indicador = _indicadorBusinessLogic.ListarIndicadorForId((int)ViewState["idIndicadorAccion"]);
                txtNombreIndicador.Value = _indicador.Nombre;
                txtDetalleIndicador.Value = _indicador.Detalle;
                ddlCodigoAnho.SelectedValue = _indicador.Anho;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$(document).ready(function() {$('#indicador').modal('show');});");
            sb.Append(@"</script>");
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "indicador", sb.ToString(), false);
        }


        protected void GridAccion2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');
            string idEntidad = arg[0];
            string idIndicador = arg[1];
            string idAccion = arg[2];

            if (e.CommandName == "avance")
            {
                Indicador indicador = _indicadorBusinessLogic.ListarIndicadorForId(int.Parse(idIndicador));
                Accion accion = _accionBusinessLogic.BuscarAccionForID(int.Parse(idAccion));
                Meta meta = new Meta
                {
                    IdEntidad = int.Parse(idEntidad),
                    IdIndicador = int.Parse(idIndicador)
                };
                meta = _metaBusinessLogic.BuscarMetaPorEntidad(meta);
                if (meta == null)
                {
                    Limpiar();
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
                sb.Append("$(document).ready(function() {$('#resultado').modal('show');});");
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
            ViewState["documento"] = meta.CodigoDocumento;
        }

        protected void Submit_descargar(object sender, EventArgs e)
        {
            string filePath = Server.MapPath(Path.Combine("~/App_Data/", ViewState["documento"].ToString()));
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
        

    protected void GridAccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

    }
}