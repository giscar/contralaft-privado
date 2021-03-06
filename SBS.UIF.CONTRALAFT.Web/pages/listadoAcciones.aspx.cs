﻿using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Util;
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

        IndicadorBusinessLogic _indicadorBusinessLogic = new IndicadorBusinessLogic();

        EntidadBusinessLogic _entidadBusinessLogic = new EntidadBusinessLogic();

        IndicadorEntidadBusinessLogic _indicadorEntidadBusinessLogic = new IndicadorEntidadBusinessLogic();

        List<Accion> listadoAccion;

        List<Entidad> ListadoEntidad = new List<Entidad>();

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

        private void CargarEntidades()
        {
            LlenarDropDownList(ddlCodigoEntidad, new EntidadBusinessLogic().ListarPorEntidad().OrderBy(x => x.DesTipo), "0", "Seleccione");
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

        protected void Guardar_Indicador(object sender, EventArgs e)
        {
            try
            {
                Indicador indicador = new Indicador
                {
                    Nombre = txtNombreIndicador.Value,
                    Detalle = txtDetalleIndicador.Value,
                    IdAccion = (int)ViewState["idAccion"],
                    UsuRegistro = UsuarioSession().DetCodigo,
                    FecRegistro = DateTime.Now,
                    Anho = ddlCodigoAnho.SelectedValue,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO
                };
                ViewState["idIndicador"] = _indicadorBusinessLogic.GuardarIndicador(indicador);
                CargarEntidades();
                divEntidad.Visible = true;
                btnSeleccionarIndicador.Visible = false;
                upSeccionBotonIndicador.Update();
                upSeccionEntidad.Update();

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
                ie.IdIndicador = (int)ViewState["idIndicador"];
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

        protected void DdlTipoEntidad_SelectedIndexChanged()
        {
            try
            {
                string selectorEntidad = ddlCodigoEntidad.SelectedValue;
                Entidad entidad = _entidadBusinessLogic.EntidadForID(int.Parse(selectorEntidad.ToString()));
                IndicadorEntidad ie = new IndicadorEntidad();
                ie.IdIndicador = (int)ViewState["idIndicador"];
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

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            try
            {
                Accion accion;
                Plan val = _planBusinessLogic.BuscarPlanPublicado();
                if (val == null) {
                    ClientMessageBox.Show("No existe ningun Plan publicado nose puede crear la acción", this);
                    return;
                }

                accion = new Accion
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
                    Codigo = txtEditarCodigo.Value,
                    Nombre = txtEditarAccion.Value,
                    Descripcion = txtEditarDescripcion.Value,
                    FecModificacion = DateTime.Now,
                    UsuModificacion = UsuarioSession().DetCodigo,
                };
                _accionBusinessLogic.ActualizarAccion(_accion);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se modificó la acción seleccionada", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Submit_agregar_indicador(object sender, EventArgs e)
        {
            try
            {
                Indicador _indicador = new Indicador
                {
                    IdAccion = (int)ViewState["idAccion"],
                    Detalle = txtDetalleIndicador.Value,
                    Nombre = txtNombreIndicador.Value,
                    FecModificacion = DateTime.Now,
                    UsuModificacion = UsuarioSession().DetCodigo,
                };
                ViewState["idIndicador"] = _indicadorBusinessLogic.GuardarIndicador(_indicador).ToString();
                Limpiar();
                CargarLista();
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

        protected void GridAccion_RowCommandEntidad(object sender, GridViewCommandEventArgs e)
        {
            IndicadorEntidad _indicadorEntidad = new IndicadorEntidad();
            _indicadorEntidad.IdIndicador = (int)ViewState["idIndicador"];
            _indicadorEntidad.IdEntidad = int.Parse(e.CommandArgument.ToString());
            _indicadorEntidadBusinessLogic.EliminarIndicadorEntidad(_indicadorEntidad);
            ListadoEntidad = _entidadBusinessLogic.ListarPorEntidadforIndicador(_indicadorEntidad.IdIndicador);
            GridView2.DataSource = ListadoEntidad;
            GridView2.DataBind();
            upListadoEntidades.Update();
        }    

        protected void GridAccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idAccion"] = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "editar")
            {
                Accion accionActualizada = _accionBusinessLogic.BuscarAccionForID((int)ViewState["idAccion"]);
                txtEditarCodigo.Value = accionActualizada.Codigo;
                txtEditarAccion.Value = accionActualizada.Nombre;
                txtEditarDescripcion.Value = accionActualizada.Descripcion;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#editar').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editar", sb.ToString(), false);
            }

            if (e.CommandName == "inactivar")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#inactivar').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivar", sb.ToString(), false);
            }

            if (e.CommandName == "indicador")
            {
                divEntidad.Visible = false;
                ListadoEntidad = null;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#indicador').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "indicador", sb.ToString(), false);
            }

        }
    }
}