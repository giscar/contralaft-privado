using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Util;
using SBS.UIF.CONTRALAFT.Web.comun;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class perfil : PaginaBase
    {
        PerfilBusinessLogic perfilBusinessLogic = new PerfilBusinessLogic();
        List<Entity.Common.Perfil> listadoPerfiles;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetUsuarioSession();
            CargarLista();
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil
            {
                DesTipo = txtNombrePerfil.Value,
                DetDetalle = txtDescripcion.Value,
                FlagEstado = (int)Constante.FlagEstado.ACTIVO,
                DetUsuarioRegistro = usuarioSession.DetCodigo,
                DetUsuarioModificacion = usuarioSession.DetCodigo,
                FecRegistro = DateTime.Today,
                FecModificacion = DateTime.Today
        };
            perfilBusinessLogic.guardarPerfil(perfil);
            Limpiar();
            CargarLista();
            AlertDanger("Se realizaron los cambios");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarLista();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        private void CargarLista()
        {
            listadoPerfiles = perfilBusinessLogic.listarPorPerfil();
            GridView1.DataSource = listadoPerfiles;
            GridView1.DataBind();
        }

        private void Limpiar() {
            txtNombrePerfil.Value = "";
            txtDescripcion.Value = "";
        }

        protected void AlertDanger(string pmessage)
        {
            idModalInfoServer.Visible = true;
            lblMensajeOk.Text = pmessage;
        }

    }
}