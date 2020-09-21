using System;
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
using System.IO;
using System.Text.RegularExpressions;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class usuario : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        UsuarioBusinessLogic _usuarioBusinessLogic = new UsuarioBusinessLogic();

        EntidadBusinessLogic _entidadBusinessLogic = new EntidadBusinessLogic();

        PerfilBusinessLogic _perfilBusinessLogic = new PerfilBusinessLogic();

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
                LlenarDropDownList(ddlCodigoEntidad, new EntidadBusinessLogic().ListarPorEntidad().OrderBy(x => x.DesTipo), "0", "Seleccione");
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
            HttpPostedFile file = Request.Files["fileDocumento"];
            try
            {
                string fname = "";
                if (file != null && file.ContentLength > 0)
                {
                    fname = Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath(Path.Combine("~/App_Data/", fname)));
                }
                string password = Membership.GeneratePassword(12, 1);
                password = Regex.Replace(password, @"[^a-zA-Z0-9]", m => "9");
                SHA256Managed sha = new SHA256Managed();
                byte[] pass = Encoding.Default.GetBytes(password);
                byte[] passCifrado = sha.ComputeHash(pass);
                Usuario _usuario = new Usuario
                {
                    DetNombre = txtNombre.Value,
                    DetContrasenia = BitConverter.ToString(passCifrado).Replace("-", ""),
                    DetCodigo = txtDocumento.Value,
                    DetEmail = txtEmail.Value,
                    FecRegistro = DateTime.Now,
                    CodDocumento = fname,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO,
                    IdEntidad = int.Parse(ddlCodigoEntidad.SelectedValue),
                    IdPerfil = int.Parse(ddlCodigoPerfil.SelectedValue),
                    UsuRegistro = UsuarioSession().DetCodigo,
                    ContraseniaEmail = password
                };
                new UsuarioBusinessLogic().GuardarPersona(_usuario);
                EnviarEmail(_usuario);
                CargarLista();
                Limpiar();
                ClientMessageBox.Show("Se creo el usuario", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["parametro"] = e.CommandArgument.ToString();
            try
            {
                if (e.CommandName == "editarUsuario")
                {
                    CargarComboEdit();
                    Usuario usuarioActualizado = _usuarioBusinessLogic.BuscarUsuarioForID(int.Parse(ViewState["parametro"].ToString()));
                    if (usuarioActualizado.IdPerfil == int.Parse(Constantes.codigoPerfilAdministrador))
                    {
                        divEntidadEdit.Visible = false;
                    }
                    else {
                        divEntidadEdit.Visible = true;
                        foreach (ListItem item in ddlCodigoEntidadEdit.Items)
                        {
                            if (usuarioActualizado.IdEntidad == int.Parse(item.Value))
                            {
                                item.Selected = true;
                            }
                        }
                    }
                    upEntidadEdit.Update();
                    foreach (ListItem item in ddlCodigoPerfilEdit.Items)
                    {
                        if (usuarioActualizado.IdPerfil == int.Parse(item.Value))
                        {
                            item.Selected = true;
                        }
                    }
                    DNIedit.Value = usuarioActualizado.DetCodigo;
                    nombreEdit.Value = usuarioActualizado.DetNombre;
                    txtEmailEdit.Value = usuarioActualizado.DetEmail;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$(document).ready(function() {$('#editarUsuarioModal').modal('show');});");
                    sb.Append(@"</script>");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "editarUsuario", sb.ToString(), false);
                }

                if (e.CommandName == "eliminarUsuario")
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$(document).ready(function() {$('#inactivacion').modal('show');});");
                    sb.Append(@"</script>");
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "inactivacion", sb.ToString(), false);
                }

                if (e.CommandName == "downloadDocumento")
                {
                    string filePath = Server.MapPath(Path.Combine("~/App_Data/", ViewState["parametro"].ToString()));
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
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void Submit_editar_usuario(object sender, EventArgs e)
        {
            try
            {
                Usuario _usuario = new Usuario
                {
                    Id = int.Parse(ViewState["parametro"].ToString()),
                    UsuModificacion = UsuarioSession().DetCodigo,
                    FecModificacion = DateTime.Now,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO,
                    DetNombre = nombreEdit.Value,
                    DetEmail = txtEmailEdit.Value,
                    IdPerfil = int.Parse(ddlCodigoPerfilEdit.SelectedValue),
                    IdEntidad = int.Parse(ddlCodigoEntidadEdit.SelectedValue),
                };
                _usuarioBusinessLogic.ActualizarUsuario(_usuario);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se edito el usuario", this);
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
                Usuario _usuario = new Usuario
                {
                    Id = int.Parse(ViewState["parametro"].ToString()),
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
                LlenarDropDownList(ddlCodigoEntidadEdit, new EntidadBusinessLogic().ListarPorEntidad().OrderBy(x => x.DesTipo), Constantes.selectValueDefault, Constantes.selectLabelDefault);
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

        protected void DDlCodigoPerfilEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            divEntidadEdit.Visible = !ddlCodigoPerfilEdit.SelectedValue.Equals(Constantes.codigoPerfilAdministrador) && !ddlCodigoPerfilEdit.SelectedValue.Equals(Constantes.codigoPerfilGestor);
            upEntidadEdit.Update();
        }

        protected void Submit_nuevo_entidad(object sender, EventArgs e)
        {
            try
            {
                Entidad entidad = new Entidad
                {
                    DesTipo = txtEntidad.Value,
                    CodRuc = txtRuc.Value,
                    FecRegistro = DateTime.Now,
                    UsuRegistro = UsuarioSession().DetCodigo,
                    FlActivo = (int)Constantes.EstadoFlag.ACTIVO
                };
                _entidadBusinessLogic.GuardarEntidad(entidad);
                CargarCombos();
                CargarComboEdit();
                ClientMessageBox.Show("Se creo la Entidad", this);
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

        protected void Modal_nuevo_entidad(object sender, EventArgs e)
        {
            try
            {
                LimpiarEntidad();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(@"<script type='text/javascript'>");
                sb.Append("$(document).ready(function() {$('#entidadModal').modal('show');});");
                sb.Append(@"</script>");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "entidadModal", sb.ToString(), false);
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

        private void LimpiarEntidad()
        {
            txtEntidad.Value = "";
            txtRuc.Value = "";
        }

        private void EnviarEmail(Usuario _usuario)
        {
            Comunicacion comunicacion = new Comunicacion();
            comunicacion.CorreoUsuario = _usuario.DetEmail;
            comunicacion.UserId = _usuario.DetCodigo;
            comunicacion.NombreUsuario = _usuario.DetNombre;
            comunicacion.Pass = _usuario.ContraseniaEmail;
            if(_usuario.IdPerfil > 2)
            comunicacion.Entidad = _entidadBusinessLogic.EntidadForID(_usuario.IdEntidad).DesTipo;
            comunicacion.Perfil = _perfilBusinessLogic.PerfilForId(_usuario.IdPerfil).DesTipo;
            comunicacion.IdPerfil = _usuario.IdPerfil;
            comunicacion.Subject = Constantes.textoSubject;
            Correo correo = new Correo();
            correo.SendMail(comunicacion);
        }
    }
}