using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Web;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Entity.Core;

namespace SBS.UIF.CONTRALAFT.Web
{
    public partial class plantilla : System.Web.UI.MasterPage
    {
        MenuBusinessLogic _menuBusinessLogic = new MenuBusinessLogic();

        List<Menu> listadoMenu;

        
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            listadoMenu = _menuBusinessLogic.listarPorMenu(usuarioSession.IdPerfil);
            cdcatalog.DataSource = listadoMenu;
            cdcatalog.DataBind();
        }

        
    }
}