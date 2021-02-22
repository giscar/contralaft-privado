using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Util;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class perfil : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        PerfilBusinessLogic _perfilBusinessLogic = new PerfilBusinessLogic();

        List<Perfil> listadoPerfiles;

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
                Perfil perfil = new Perfil
                {
                    DesTipo = txtNombrePerfil.Value,
                    DetDetalle = txtDescripcion.Value,
                    DetUsuarioRegistro = UsuarioSession().DetCodigo,
                    FecRegistro = DateTime.Now,
                    FlagEstado = (int)Constantes.EstadoFlag.ACTIVO
                };
                _perfilBusinessLogic.GuardarPerfil(perfil);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se registro el nuevo perfil", this);
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
                Perfil perfil = new Perfil
                {
                    IdTipo = (int)ViewState["idPerfil"],
                    DetUsuarioModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlagEstado = (int)Constantes.EstadoFlag.INACTIVO
                };
                _perfilBusinessLogic.InactivarPerfil(perfil);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se inactivo el perfil", this);
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
                Perfil _perfil = new Perfil
                {
                    IdTipo = (int)ViewState["idPerfil"],
                    DetDetalle = txtEditarDescripcion.Value,
                    DetUsuarioModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now
                };
                _perfilBusinessLogic.ActualizarPerfil(_perfil);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se modificó el perfil seleccionado", this);
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
            listadoPerfiles = _perfilBusinessLogic.ListarPorPerfil();
            GridView1.DataSource = listadoPerfiles;
            GridView1.DataBind();
        }

        private void Limpiar()
        {
            txtNombrePerfil.Value = "";
            txtDescripcion.Value = "";
        }

        protected void gridPerfil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idPerfil"] = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "editarPerfil")
            {
                Perfil perfilActualizado = _perfilBusinessLogic.PerfilForId((int)ViewState["idPerfil"]);
                txtEditarPerfil.Value = perfilActualizado.DesTipo;
                txtEditarDescripcion.Value = perfilActualizado.DetDetalle;
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