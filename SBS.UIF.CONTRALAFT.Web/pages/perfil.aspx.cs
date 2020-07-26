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

        PerfilBusinessLogic perfilBusinessLogic = new PerfilBusinessLogic();

        List<Perfil> listadoPerfiles;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioSession() == null) {
                Response.Redirect("../pages/login.aspx");
            }
            cargarLista();
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Perfil perfil = new Perfil
            {
                DesTipo = txtNombrePerfil.Value,
                DetDetalle = txtDescripcion.Value
            };
            perfilBusinessLogic.guardarPerfil(perfil);
            AlertDanger("Debe de ingresar el captcha");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargarLista();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        private void cargarLista()
        {
            listadoPerfiles = perfilBusinessLogic.listarPorPerfil();
            GridView1.DataSource = listadoPerfiles;
            GridView1.DataBind();
        }

        private void AlertDanger(string pmessage)
        {
            /*idModalAlertaServer.Visible = true;
            lblMensajePeligro.Text = pmessage;*/
        }

    }
}