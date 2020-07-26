using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Data;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using System.Web.Security;

namespace SBS.UIF.CONTRALAFT.Web.pages
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
                        Response.Redirect("../pages/login.aspx");
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
            LlenarDropDownList(ddlCodigoEntidad, new EntidadBusinessLogic().listarPorEntidad().OrderBy(x => x.DesTipo), "0", "Seleccione");
            LlenarDropDownList(ddlCodigoPerfil, new PerfilBusinessLogic().listarPorPerfil().OrderBy(x => x.DesTipo), "0", "Seleccione"); 
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
            if (GridView1.Columns.Count > 0)
            {
                GridView1.Columns[0].Visible = false;
            }
            this.GridView1.Columns[0].Visible = false;
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            string password = Membership.GeneratePassword(12, 1);
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Usuario _usuario = new Usuario();
            _usuario.DetNombre = txtNombre.Value;
            SHA256Managed sha = new SHA256Managed();
            Console.WriteLine(password);
            byte[] pass = Encoding.Default.GetBytes(password);
            byte[] passCifrado = sha.ComputeHash(pass);
            //_usuario.DetContrasenia = BitConverter.ToString(passCifrado).Replace("-", "");
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

        protected void OnSelectedIndexChanged(Object sender, EventArgs e)
        {

            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;
            Console.WriteLine(row.Cells[0].Text);
            // In this example, the first column (index 0) contains
           // TextBox1.Text = row.Cells[0].Text;

        }


        protected void userProfile_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            Console.WriteLine(id);
            Usuario usu = new UsuarioBusinessLogic().buscarUsuarioForID(id);
            editNombre.Value = usu.DetNombre;
            editDNI.Value = usu.DetCodigo;
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