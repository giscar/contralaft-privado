using SBS.UIF.CONTRALAFT.Web.comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Web.util;
using SBS.UIF.BUZ.Web.util;
using System.Data;

namespace SBS.UIF.CONTRALAFT.Web.pages
{

    public partial class rol : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        RolBusinessLogic _rolBusinessLogic = new RolBusinessLogic();

        PerfilBusinessLogic _perfillBusinessLogic = new PerfilBusinessLogic();

        PerfilRolBusinessLogic _perfilRolBusinessLogic = new PerfilRolBusinessLogic();

        List<Rol> listadoRoles;

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
                    CargarCombos();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }

        private void CargarCombos()
        {
            LlenarCheckList(ddlCodigoPerfil, new PerfilBusinessLogic().ListarPorPerfil().OrderBy(x => x.DesTipo), "", "");
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            try
            {
                Rol rol = new Rol
                {
                    DesTipo = txtNombreRol.Value,
                    DetDetalle = txtDescripcion.Value,
                    FecRegistro = DateTime.Now,
                    DetUsuarioRegistro = UsuarioSession().DetCodigo,
                    FlagEstado = (int)Constantes.EstadoFlag.ACTIVO
                };
                int codigoRol = _rolBusinessLogic.GuardarRol(rol);
                PerfilRol _perfilRol = new PerfilRol
                {
                    CodRol = codigoRol,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO
                };

                List<ListItem> selected = new List<ListItem>();
                foreach (ListItem item in ddlCodigoPerfil.Items)
                    if (item.Selected)
                    {
                        _perfilRol.CodPerfil = int.Parse(item.Value);
                        _perfilRolBusinessLogic.guardarPerfilRol(_perfilRol);
                    }
                CargarLista();
                ClientMessageBox.Show("Se creo el nuevo rol", this);
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
                Rol _rol = new Rol
                {
                    IdTipo = (int)ViewState["idRol"],
                    DetDetalle = txtEditarDescripcion.Value,
                    DetUsuarioModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now
                };
                    _rolBusinessLogic.ActualizarRol(_rol);

                foreach (ListItem item in ddlCodigoPerfilEdit.Items) { 
                PerfilRol _perfilRol = new PerfilRol();
                    if (item.Selected)
                    {
                        _perfilRol.FlActivo = (int)Constantes.EstadoFlag.ACTIVO;
                    }
                    else {
                        _perfilRol.FlActivo = (int)Constantes.EstadoFlag.INACTIVO;
                    }
                _perfilRol.CodRol = _rol.IdTipo;
                _perfilRol.CodPerfil = int.Parse(item.Value);
                _perfilRolBusinessLogic.GuardarActualizarPerfilRol(_perfilRol);
                }
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se modificó el rol seleccionado", this);
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
                Rol _rol = new Rol
                {
                    IdTipo = (int)ViewState["idRol"],
                    DetUsuarioModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlagEstado = (int)Constantes.EstadoFlag.INACTIVO
                };
                _rolBusinessLogic.InactivarRol(_rol);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se inactivo el Rol", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridRol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idRol"] = int.Parse(e.CommandArgument.ToString());
            try
            {
                if (e.CommandName == "editarRol")
                {
                    LlenarCheckList(ddlCodigoPerfilEdit, new PerfilBusinessLogic().ListarPorPerfil().OrderBy(x => x.DesTipo), "", "");

                    Rol rolActualizado = _rolBusinessLogic.RolForId((int)ViewState["idRol"]);
                    rolActualizado.ListaPerfiles = _perfillBusinessLogic.ListarPerfirForRol(rolActualizado.IdTipo);
                    foreach (Perfil _perfil in rolActualizado.ListaPerfiles)
                    {
                        foreach (ListItem item in ddlCodigoPerfilEdit.Items)
                        {
                            if (_perfil.IdTipo == int.Parse(item.Value))
                            {
                                item.Selected = true;
                            }
                        }
                    }

                    txtEditarRol.Value = rolActualizado.DesTipo;
                    txtEditarDescripcion.Value = rolActualizado.DetDetalle;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$(document).ready(function() {$('#editarRol').modal('show');});");
                    sb.Append(@"</script>");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editarPerfil", sb.ToString(), false);
                }

                if (e.CommandName == "eliminarRol")
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$(document).ready(function() {$('#inactivacion').modal('show');});");
                    sb.Append(@"</script>");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivacion", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            
        }

        private void CargarLista()
        {
            try
            {
                listadoRoles = _rolBusinessLogic.ListarPorRol();
                foreach (Rol item in listadoRoles) {
                    item.ListaPerfiles = _perfillBusinessLogic.ListarPerfirForRol(item.IdTipo);
                }
                
                GridView1.DataSource = listadoRoles;
                GridView1.DataBind();
                Limpiar();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void Limpiar()
        {
            txtNombreRol.Value = "";
            txtDescripcion.Value = "";
            CargarCombos();
        }

    }
}