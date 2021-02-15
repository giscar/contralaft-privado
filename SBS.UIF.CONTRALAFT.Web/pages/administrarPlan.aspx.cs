using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Web.util;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class adminiatrarPlan : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        PlanBusinessLogic _planBusinessLogic = new PlanBusinessLogic();

        List<Plan> listadoPlanes;

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

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            try
            {
                Plan validaBorrador;
                validaBorrador = _planBusinessLogic.BuscarPlanBorrador();
                if (validaBorrador != null) {
                    ClientMessageBox.Show("Actualmente existe un plan en estado borrador", this);
                    return;
                }

                Plan plan = new Plan
                {
                    Nombre = txtNombrePlan.Value,
                    Descripcion = txtDescripcion.Value,
                    Estado = (int)Constantes.EstadoPlan.BORRADOR,
                    UsuRegistro = UsuarioSession().DetCodigo,
                    FecRegistro = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO
                };
                _planBusinessLogic.GuardarPlan(plan);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se registro el nuevo Plan", this);
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
                Plan plan = new Plan
                {
                    Id = (int)ViewState["idPlan"],
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.INACTIVO
                };
                _planBusinessLogic.InactivarPlan(plan);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se inactivo el Plan", this);
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
                Plan _plan = new Plan
                {
                    Id = (int)ViewState["idPlan"],
                    Nombre = txtEditarNombre.Value,
                    Descripcion = txtEditarDescripcion.Value,
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now
                };
                _planBusinessLogic.ActualizarPlan(_plan);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se modificó el plan", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CargarLista();
                GridView1.PageIndex = e.NewPageIndex;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void CargarLista()
        {
            listadoPlanes = _planBusinessLogic.BuscarTodos();
            foreach (Plan item in listadoPlanes)
            {
                Console.Write(item.Estado.ToString());
                Console.Write(Constantes.EstadoPlan.BORRADOR.ToString());
                if (item.Estado == (int)Constantes.EstadoPlan.BORRADOR)
                {
                    item.EstadoDescripcion = Constantes.estadoPlanBORRADOR;
                }
                if (item.Estado == (int)Constantes.EstadoPlan.PUBLICADO)
                {
                    item.EstadoDescripcion = Constantes.estadoPlanPUBLICADO;
                }
            }
            GridView1.DataSource = listadoPlanes;
            GridView1.DataBind();
        }

        protected void Submit_publicar(object sender, EventArgs e)
        {
            try
            {
                Plan _plan = new Plan
                {
                    Id = (int)ViewState["idPlan"],
                    Estado = (int)Constantes.EstadoPlan.PUBLICADO,
                    Version = _planBusinessLogic.BuscarVersion(),
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now
                };
                _planBusinessLogic.EstadoPlan(_plan);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se modificó el plan", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


        private void Limpiar()
        {
            txtNombrePlan.Value = "";
            txtDescripcion.Value = "";
        }

        protected void GridPlan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idPlan"] = int.Parse(e.CommandArgument.ToString());

            Plan planlActualizado = _planBusinessLogic.BuscarPlanForID((int)ViewState["idPlan"]);

            if (e.CommandName == "editarPlan")
            {
                txtEditarNombre.Value = planlActualizado.Nombre;
                txtEditarDescripcion.Value = planlActualizado.Descripcion;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#editarPlan').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editarPlan", sb.ToString(), false);
            }

            if (e.CommandName == "inactivarPlan")
            {
                if (planlActualizado.Estado == (int)Constantes.EstadoPlan.PUBLICADO)
                {
                    ClientMessageBox.Show("El plan se encuentra en estado publicado no se puede eliminar", this);
                    return;
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#inactivacion').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivacion", sb.ToString(), false);
            }

             if (e.CommandName == "publicarPlan")
             {
                if (planlActualizado.Estado == (int)Constantes.EstadoPlan.PUBLICADO)
                {
                    ClientMessageBox.Show("El plan se encuentra en estado publicado no se puede volver a publicar", this);
                    return;
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#publicar').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "publicar", sb.ToString(), false);
             }
        }
    }
}