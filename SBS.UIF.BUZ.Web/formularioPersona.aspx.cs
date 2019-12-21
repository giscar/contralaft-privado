using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Configuration;
using NLog;


using SBS.UIF.BUZ.Web.comun;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.BusinessLogic.Core;





namespace SBS.UIF.BUZ.Web
{
    public partial class formularioPersona :  PaginaBase 
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    logger.ErrorException(ex.Message, ex);
                    
                }
            }
        }

        protected void Button_Guardar(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}