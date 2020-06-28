using SBS.UIF.CONTRALAFT.Web.comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Entity.Common;
using System.Web.UI.WebControls;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    
    public partial class rol : PaginaBase
    {
        RolBusinessLogic _rolBusinessLogic = new RolBusinessLogic();

        PerfilBusinessLogic _perfillBusinessLogic = new PerfilBusinessLogic();

        PerfilRolBusinessLogic _perfilRolBusinessLogic = new PerfilRolBusinessLogic();

        List<Rol> listadoRoles;

        Usuario usuarioSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
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

        private void cargarLista()
        {
            listadoRoles = _rolBusinessLogic.listarPorRol();
        }

        private void cargarCombos()
        {
            LlenarCheckList(ddlCodigoPerfil, new PerfilBusinessLogic().listarPorPerfil().OrderBy(x => x.DesTipo), "", "");
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Rol rol = new Rol
            {
                DesTipo = txtNombreRol.Value,
                DetDetalle = txtDescripcion.Value
            };
            int codigoRol = _rolBusinessLogic.guardarRol(rol);
            int codigoPerfil = int.Parse(ddlCodigoPerfil.SelectedValue);
            PerfilRol _perfilRol = new PerfilRol();
            _perfilRol.codPerfil = codigoPerfil;
            _perfilRol.codRol = codigoRol;

            List<System.Web.UI.WebControls.ListItem> selected = new List<ListItem>();
            foreach (ListItem item in ddlCodigoPerfil.Items)
                if (item.Selected) {
                    _perfilRol.codPerfil = int.Parse(item.Value);
                    _perfilRolBusinessLogic.guardarPerfilRol(_perfilRol);
                }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            cargarLista();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}