using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class perfil : PaginaBase
    {
        Logger log = LogManager.GetCurrentClassLogger();

        PerfilBusinessLogic _perfilBusinessLogic = new PerfilBusinessLogic();

        List<Perfil> listadoPerfiles;

        Perfil _perfilEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioSession() == null) {
                Response.Redirect("../pages/login.aspx");
            }
            CargarLista();
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil
            {
                DesTipo = txtNombrePerfil.Value,
                DetDetalle = txtDescripcion.Value
            };
            _perfilBusinessLogic.GuardarPerfil(perfil);
            Limpiar();
            AlertDanger("Debe de ingresar el captcha");
        }

        protected void Submit_edit(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Perfil perfil = new Perfil
            {
                DesTipo = txtNombrePerfil.Value,
                DetDetalle = txtDescripcion.Value
            };
            _perfilBusinessLogic.GuardarPerfil(perfil);
            Limpiar();
            AlertDanger("Debe de ingresar el captcha");
        }

        protected void SeleccionarPerfil_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            Perfil _perfil = _perfilBusinessLogic.ListarPerfilForId(id);
            txtEditarPerfil.Value = _perfil.DesTipo;
            txtEditarDescripcion.Value = _perfil.DetDetalle;
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarLista();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        private void CargarLista()
        {
            listadoPerfiles = _perfilBusinessLogic.ListarPorPerfil();
            GridView1.DataSource = listadoPerfiles;
            GridView1.DataBind();
        }

        private void AlertDanger(string pmessage)
        {
            /*idModalAlertaServer.Visible = true;
            lblMensajePeligro.Text = pmessage;*/
        }

        private void Limpiar() {
            txtNombrePerfil.Value = "";
            txtDescripcion.Value = "";
        }

    }
}