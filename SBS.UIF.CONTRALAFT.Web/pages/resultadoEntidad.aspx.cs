using SBS.UIF.CONTRALAFT.Web.comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Web.util;
using System.Data;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;

namespace SBS.UIF.CONTRALAFT.Web.pages
{

    public partial class resultadoEntidad : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        MetaBusinessLogic _metaBusinessLogic = new MetaBusinessLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (UsuarioSession() == null)
                    {
                        Response.Redirect(Constantes.PaginaInicioLogin);
                    }
                    
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }

       
        

        

       

        }

     

    }
}