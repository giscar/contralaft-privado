using SBS.UIF.BUZ.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Web;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.Entity.Core;

namespace SBS.UIF.BUZ.Web
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