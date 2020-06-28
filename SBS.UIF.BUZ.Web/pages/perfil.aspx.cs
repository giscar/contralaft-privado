using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.Entity.Core;


namespace SBS.UIF.BUZ.Web.pages
{
    public partial class perfil : System.Web.UI.Page
    {
        PerfilBusinessLogic perfilBusinessLogic = new PerfilBusinessLogic();

        List<Perfil> listadoPerfiles;
        protected void Page_Load(object sender, EventArgs e)
        {
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

    }
}