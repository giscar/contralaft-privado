using NLog;
using SBS.UIF.BUZ.Web.util;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Web.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class listadoAcciones : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        AccionBusinessLogic _accionBusinessLogic = new AccionBusinessLogic();

        PlanBusinessLogic _planBusinessLogic = new PlanBusinessLogic();

        List<Accion> listadoAccion;
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarLista();
            GridView1.PageIndex = e.NewPageIndex;
        }

        private void CargarLista()
        {
            listadoAccion = _accionBusinessLogic.ListarPorAccion();
            GridView1.DataSource = listadoAccion;
            GridView1.DataBind();
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            try
            {
                Accion accion = new Accion
                {
                    Nombre = txtAccion.Value,
                    Codigo = txtCodigoAccion.Value,
                    Descripcion = txtDescripcion.Value,
                    IdPlan = _planBusinessLogic.BuscarPlanPublicado().Id,
                    UsuRegistro = UsuarioSession().DetCodigo,
                    FecRegistro = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO
                };
                _accionBusinessLogic.GuardarAccion(accion);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se registro la nueva Acción", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Submit_inactive(object sender, EventArgs e)
        {
            try
            {
                Accion accion = new Accion
                {
                    Id = (int)ViewState["idAccion"],
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.INACTIVO
                };
                _accionBusinessLogic.InactivarAccion(accion);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se inactivo la acción", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Submit_edit(object sender, EventArgs e)
        {
            try
            {
                Accion _accion = new Accion
                {
                    Id = (int)ViewState["idAccion"],
                    Codigo = txtEditarCodigoAccion.Value,
                    Nombre = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    UsuModificacion = UsuarioSession().DetCodigo,
                };
                _accionBusinessLogic.ActualizarAccion(_accion);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se modificó el perfil seleccionado", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void Limpiar()
        {
            txtCodigoAccion.Value = "";
            txtAccion.Value = "";
            txtDescripcion.Value = "";
        }

        protected void gridAccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idAccion"] = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "editar")
            {
                Accion accionActualizada = _accionBusinessLogic.BuscarAccionForID((int)ViewState["idAccion"]);
                txtEditarCodigoAccion.Value = accionActualizada.Codigo;
                txtEditarDescripcion.Value = accionActualizada.Descripcion;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#editarPerfil').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editarPerfil", sb.ToString(), false);
            }

            if (e.CommandName == "eliminarPerfil")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#inactivacion').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivacion", sb.ToString(), false);
            }
        }
    }
}