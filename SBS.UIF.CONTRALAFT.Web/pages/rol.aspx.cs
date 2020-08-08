using SBS.UIF.CONTRALAFT.Web.comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Core;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Web.util;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    
    public partial class rol : PaginaBase
    {
        readonly Logger Log = LogManager.GetCurrentClassLogger();

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
                    if (UsuarioSession() == null)
                    {
                        Response.Redirect("../pages/login.aspx");
                    }
                    CargarLista();
                    CargarCombos();
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
            
        }

        private void CargarCombos()
        {
            LlenarRadioList(ddlCodigoPerfil, new PerfilBusinessLogic().ListarPorPerfil().OrderBy(x => x.DesTipo), "", ""); 
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            try
            {
                Rol rol = new Rol
                {
                    DesTipo = txtNombreRol.Value,
                    DetDetalle = txtDescripcion.Value,
                    FecRegistro = DateTime.Now,
                    DetUsuarioRegistro = UsuarioSession().DetCodigo,
                    FlagEstado = (int)Constantes.EstadoFlag.ACTIVO
                };
                int codigoRol = _rolBusinessLogic.guardarRol(rol);
                int codigoPerfil = int.Parse(ddlCodigoPerfil.SelectedValue);
                PerfilRol _perfilRol = new PerfilRol();
                _perfilRol.codPerfil = codigoPerfil;
                _perfilRol.codRol = codigoRol;

                List<ListItem> selected = new List<ListItem>();
                foreach (ListItem item in ddlCodigoPerfil.Items)
                    if (item.Selected)
                    {
                        _perfilRol.codPerfil = int.Parse(item.Value);
                        _perfilRolBusinessLogic.guardarPerfilRol(_perfilRol);
                    }
                CargarLista();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                CargarLista();
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void CargarLista()
        {
            try
            {
                listadoRoles = _rolBusinessLogic.listarPorRol();
                GridView1.DataSource = listadoRoles;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}