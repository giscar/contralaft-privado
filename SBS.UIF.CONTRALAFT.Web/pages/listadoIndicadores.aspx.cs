using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Web.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class listadoIndicadores : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

        IndicadorBusinessLogic _indicadorBusinessLogic = new IndicadorBusinessLogic();

        AccionBusinessLogic _accionBusinessLogic = new AccionBusinessLogic();

        EntidadBusinessLogic _entidadBusinessLogic = new EntidadBusinessLogic();

        List<Accion> listadoAccion;

        List<Indicador> listadoIndicador;

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
                    CargarLista();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }

        private void CargarLista()
        {
            listadoAccion = _accionBusinessLogic.ListarPorAccion();
            foreach (Accion item in listadoAccion)
            {
                item.ListaIndicadores = _indicadorBusinessLogic.ListarIndicadorForAccion(item.Id);
                foreach (Indicador item1 in item.ListaIndicadores)
                {
                    item1.ListaEntidades = _entidadBusinessLogic.ListarPorEntidadforIndicador(item1.Id);
                }
            }
            GridView1.DataSource = listadoAccion;
            GridView1.DataBind();
        }

        

        protected void GridAccion_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

    }
}