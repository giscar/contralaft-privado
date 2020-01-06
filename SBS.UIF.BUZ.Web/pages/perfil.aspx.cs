using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SBS.UIF.BUZ.BusinessLogic.Common;
using SBS.UIF.BUZ.Entity.Common;
using SBS.UIF.BUZ.Entity.Core;


namespace SBS.UIF.BUZ.Web.pages
{
    public partial class perfil : System.Web.UI.Page
    {
        PerfilBusinessLogic perfilBusinessLogic = new PerfilBusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            Perfil perfil = new Perfil
            {
                DetNombre = txtNombrePerfil.Value,
                DetDetalle = txtDescripcion.Value
            };
            perfilBusinessLogic.guardarPerfil(perfil);
        }

    }
}