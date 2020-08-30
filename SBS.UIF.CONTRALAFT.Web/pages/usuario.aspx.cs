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
                    var usuario = HttpContext.Current.Session["Usuario"];
                    if (usuario == null)
                    {
                        Response.Redirect(Constantes.PaginaInicioLogin);
                    }
                    CargarLista();
                    CargarCombos();
                    divEntidad.Visible = false;
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
                listadoUsuarios = _usuarioBusinessLogic.buscarTodos();
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
                Usuario _usuario = new Usuario
                {
                    DetNombre = txtNombre.Value
                };
                SHA256Managed sha = new SHA256Managed();
                Console.WriteLine(password);
                byte[] pass = Encoding.Default.GetBytes(password);
                byte[] passCifrado = sha.ComputeHash(pass);
                _usuario.DetContrasenia = BitConverter.ToString(passCifrado).Replace("-", "");
                _usuario.DetCodigo = txtDocumento.Value;
                _usuario.FecRegistro = DateTime.Today;
                _usuario.FlActivo = (int)Constantes.EstadoFlag.ACTIVO;
                _usuario.IdEntidad = int.Parse(ddlCodigoEntidad.SelectedValue);
                _usuario.IdPerfil = int.Parse(ddlCodigoPerfil.SelectedValue);
                _usuario.UsuRegistro = UsuarioSession().DetCodigo;
                new UsuarioBusinessLogic().guardarPersona(_usuario);
                CargarLista();
                Limpiar();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void DDlCodigoPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(Constantes.codigoPerfilAdministradxor);
            Console.WriteLine(ddlCodigoPerfil.SelectedValue);
            divEntidad.Visible = !ddlCodigoPerfil.SelectedValue.Equals(Constantes.codigoPerfilAdministradxor);
            upEntidad.Update();
        }

        protected void UserProfile_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                Usuario usu = new UsuarioBusinessLogic().buscarUsuarioForID(id);
                editNombre.Value = usu.DetNombre;
                editDNI.Value = usu.DetCodigo;
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

        private void Limpiar() {
            txtNombre.Value = "";
            txtContra.Value = "";
        }
    
    }
}