using SBS.UIF.BUZ.BusinessLogic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            
            listadoMenu = _menuBusinessLogic.listarPorMenu(1);
            Console.WriteLine(listadoMenu.Count);
            cdcatalog.DataSource = listadoMenu;
            cdcatalog.DataBind();
        }
    }
}