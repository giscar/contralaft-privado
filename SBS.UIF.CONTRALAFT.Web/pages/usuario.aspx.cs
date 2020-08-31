﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Data;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using System.Web.Security;
using SBS.UIF.CONTRALAFT.Web.util;
using SBS.UIF.BUZ.Web.util;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class usuario : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        UsuarioBusinessLogic _usuarioBusinessLogic = new UsuarioBusinessLogic();

        EntidadBusinessLogic _entidadBusinessLogic = new EntidadBusinessLogic();

        List<Usuario> listadoUsuarios;

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
            try
            {
                LlenarDropDownList(ddlCodigoEntidad, new EntidadBusinessLogic().listarPorEntidad().OrderBy(x => x.DesTipo), "0", "Seleccione");
                LlenarDropDownList(ddlCodigoPerfil, new PerfilBusinessLogic().ListarPorPerfil().OrderBy(x => x.DesTipo), "0", "Seleccione");
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
                listadoUsuarios = _usuarioBusinessLogic.BuscarTodos();
                GridView1.DataSource = listadoUsuarios;
                GridView1.DataBind();
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
                string password = Membership.GeneratePassword(12, 1);
                SHA256Managed sha = new SHA256Managed();
                byte[] pass = Encoding.Default.GetBytes(password);
                byte[] passCifrado = sha.ComputeHash(pass);
                Usuario _usuario = new Usuario
                {
                    DetNombre = txtNombre.Value,
                    DetContrasenia = BitConverter.ToString(passCifrado).Replace("-", ""),
                    DetCodigo = txtDocumento.Value,
                    DetEmail = txtEmail.Value,
                    FecRegistro = DateTime.Today,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO,
                    IdEntidad = int.Parse(ddlCodigoEntidad.SelectedValue),
                    IdPerfil = int.Parse(ddlCodigoPerfil.SelectedValue),
                    UsuRegistro = UsuarioSession().DetCodigo

                };
                new UsuarioBusinessLogic().GuardarPersona(_usuario);
                CargarLista();
                Limpiar();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idUsuario"] = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "editarUsuario")
            {
                CargarComboEdit();
                divEntidadEdit.Visible = true;
                Usuario usuarioActualizado = _usuarioBusinessLogic.BuscarUsuarioForID((int)ViewState["idUsuario"]);
                foreach (ListItem item in ddlCodigoPerfilEdit.Items)
                    {
                        if (usuarioActualizado.IdPerfil == int.Parse(item.Value))
                        {
                            item.Selected = true;
                        }
                    }

                foreach (ListItem item in ddlCodigoEntidad.Items)
                {
                    if (usuarioActualizado.IdEntidad == int.Parse(item.Value))
                    {
                        item.Selected = true;
                    }
                }

                DNIedit.Value = usuarioActualizado.DetCodigo;
                nombreEdit.Value = usuarioActualizado.DetNombre;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#editarUsuarioModal').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editarPerfil", sb.ToString(), false);
            }

            if (e.CommandName == "eliminarUsuario")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#inactivacion').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivacion", sb.ToString(), false);
            }
        }

        protected void Submit_inactive(object sender, EventArgs e)
        {
            try
            {
                Usuario _usuario = new Usuario
                {
                    Id = (int)ViewState["idUsuario"],
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.INACTIVO
                };
                _usuarioBusinessLogic.InactivarUsuario(_usuario);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se inactivo el Usuario", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void CargarComboEdit()
        {
            try
            {
                LlenarDropDownList(ddlCodigoEntidadEdit, new EntidadBusinessLogic().listarPorEntidad().OrderBy(x => x.DesTipo), Constantes.selectValueDefault, Constantes.selectLabelDefault);
                LlenarDropDownList(ddlCodigoPerfilEdit, new PerfilBusinessLogic().ListarPorPerfil().OrderBy(x => x.DesTipo), Constantes.selectValueDefault, Constantes.selectLabelDefault);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


        protected void DDlCodigoPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            divEntidad.Visible = !ddlCodigoPerfil.SelectedValue.Equals(Constantes.codigoPerfilAdministrador) && !ddlCodigoPerfil.SelectedValue.Equals(Constantes.codigoPerfilGestor);
            upEntidad.Update(); 
        }

        protected void UserProfile_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                Usuario usu = new UsuarioBusinessLogic().BuscarUsuarioForID(id);
                nombreEdit.Value = usu.DetNombre;
                DNIedit.Value = usu.DetCodigo;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Submit_nuevo_entidad(object sender, EventArgs e)
        {
            try
            {
                Entidad entidad = new Entidad
                {
                    DesTipo = txtNombre.Value,
                    CodRuc = txtRuc.Value,
                    FecRegistro = new DateTime(),
                    UsuRegistro = UsuarioSession().DetCodigo,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO
                };
                _entidadBusinessLogic.guardarEntidad(entidad);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Modal_nuevo_usuario(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                divEntidad.Visible = false;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#usuarioModal').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "usuarioModal", sb.ToString(), false);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        

        private void Limpiar()
        {
            txtDocumento.Value = "";
            ddlCodigoPerfil.SelectedValue = "0";
            ddlCodigoEntidad.SelectedValue = "0";
            txtNombre.Value = "";
            txtEmail.Value = "";
        }
    
    }
}