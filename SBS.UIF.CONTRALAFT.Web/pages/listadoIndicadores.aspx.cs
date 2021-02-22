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

        AccionBusinessLogic _accionBusinessLogic = new AccionBusinessLogic();

        EntidadBusinessLogic _entidadBusinessLogic = new EntidadBusinessLogic();

        MetaBusinessLogic _metaBusinessLogic = new MetaBusinessLogic();

        List<Accion> listadoAccion;

        List<Indicador> listadoIndicador;

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
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
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