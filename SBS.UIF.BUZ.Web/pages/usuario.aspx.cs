using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Data;
using SBS.UIF.BUZ.BusinessLogic.Core;
using SBS.UIF.BUZ.BusinessLogic.Common;
using SBS.UIF.BUZ.Entity.Core;
using SBS.UIF.BUZ.Web.comun;
using SBS.UIF.BUZ.Util;

namespace SBS.UIF.BUZ.Web.pages
{
    public partial class usuario : PaginaBase
    {
        UsuarioBusinessLogic usuarioBusinessLogic = new UsuarioBusinessLogic();

        EntidadBusinessLogic entidadBusinessLogic = new EntidadBusinessLogic();

        PerfilBusinessLogic perfilBusinessLogic = new PerfilBusinessLogic();

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
                        Response.Redirect("../login/login.aspx");
                    }
                    cargarLista();
                    cargarCombos();
                }
                catch (Exception ex)
                {
                    //logger.ErrorException(ex.Message, ex);
                    //EventLog.WriteEntry("Application", "Ocurrió el error: " + ex.Message, EventLogEntryType.Error);

                }
            }
        }

        private void cargarCombos()
        {
            LlenarDropDownList(ddlCodigoEntidad, new EntidadBusinessLogic().listarPorEntidad().OrderBy(x => x.DesTipo), "0", Constante.MensajeComboRegistro);
            LlenarDropDownList(ddlCodigoPerfil, new PerfilBusinessLogic().listarPorPerfil().OrderBy(x => x.DesTipo), "0", Constante.MensajeComboRegistro); 
        }

        private void cargarLista() 
        {
            listadoUsuarios = usuarioBusinessLogic.buscarTodos();
            GridView1.DataSource = listadoUsuarios;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargarLista();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Usuario _usuario = new Usuario();
            _usuario.DetNombre = txtNombre.Value;
            SHA256Managed sha = new SHA256Managed();
            byte[] pass = Encoding.Default.GetBytes(txtContra.Value);
            byte[] passCifrado = sha.ComputeHash(pass);
            _usuario.DetContrasenia = BitConverter.ToString(passCifrado).Replace("-", "");
            _usuario.DetCodigo = txtDocumento.Value;
            _usuario.FecRegistro = DateTime.Today;
            _usuario.FlActivo = 1;
            _usuario.IdEntidad = int.Parse(ddlCodigoEntidad.SelectedValue);
            _usuario.IdPerfil = int.Parse(ddlCodigoPerfil.SelectedValue);
            _usuario.UsuRegistro = usuarioSession.DetCodigo;
            new UsuarioBusinessLogic().guardarPersona(_usuario);
            cargarLista();
            limpiar();
        }

        protected void Submit_nuevo_entidad(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Entidad entidad = new Entidad
            {
                DesTipo = txtNombre.Value,
                CodRuc = txtRuc.Value,
                FecRegistro = new DateTime(),
                UsuRegistro = usuarioSession.DetCodigo,
                FlActivo = 1
            };
            entidadBusinessLogic.guardarEntidad(entidad);
        }

        private void limpiar() {
            txtNombre.Value = "";
            txtContra.Value = "";
        }
    
    }
}