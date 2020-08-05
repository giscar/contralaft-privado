using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using NLog;
using SBS.UIF.BUZ.Web.util;
using SBS.UIF.CONTRALAFT.BusinessLogic.Common;
using SBS.UIF.CONTRALAFT.Entity.Common;
using SBS.UIF.CONTRALAFT.Web.comun;
using SBS.UIF.CONTRALAFT.Web.util;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class perfil : PaginaBase
    {
        Logger Log = LogManager.GetCurrentClassLogger();

        PerfilBusinessLogic _perfilBusinessLogic = new PerfilBusinessLogic();

        List<Perfil> listadoPerfiles;

        Perfil _perfilEdit;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioSession() == null) {
                Response.Redirect("../pages/login.aspx");
            }
            CargarLista();
        }

        protected void Submit_nuevo(object sender, EventArgs e)
        {
            try
            {
                Perfil perfil = new Perfil
                {
                    DesTipo = txtNombrePerfil.Value,
                    DetDetalle = txtDescripcion.Value,
                    DetUsuarioRegistro = UsuarioSession().DetCodigo,
                    FecRegistro = DateTime.Now,
                    FlagEstado = (int)Constantes.EstadoFlag.ACTIVO
                };
                _perfilBusinessLogic.GuardarPerfil(perfil);
                Limpiar();
                CargarLista();
                ClientMessageBox.Show("Se registro el nuevo perfil", this);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            
            
        }

        protected void Submit_inactive(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil
            {
                IdTipo = int.Parse(txtIdInactive.Value),
                DetUsuarioModificacion = UsuarioSession().DetCodigo,
                FecModificacion = DateTime.Now,
                FlagEstado = (int)Constantes.EstadoFlag.INACTIVO
            };
            _perfilBusinessLogic.InactivarPerfil(perfil);
            Limpiar();
            CargarLista();
        }
        

        protected void Submit_edit(object sender, EventArgs e)
        {
            Perfil _perfil = new Perfil
            {
                IdTipo = int.Parse(txtId.Value),
                DetDetalle = txtEditarDescripcion.Value, 
                DetUsuarioModificacion = UsuarioSession().DetCodigo,
                FecModificacion = DateTime.Now
            };
            _perfilBusinessLogic.ActualizarPerfil(_perfil);
            Limpiar();
            CargarLista();
        }

        protected void SeleccionarPerfil_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            Perfil _perfil = _perfilBusinessLogic.ListarPerfilForId(id);
            txtEditarPerfil.Value = _perfil.DesTipo;
            txtEditarDescripcion.Value = _perfil.DetDetalle;
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarLista();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        private void CargarLista()
        {
            listadoPerfiles = _perfilBusinessLogic.ListarPorPerfil();
            GridView1.DataSource = listadoPerfiles;
            GridView1.DataBind();
        }

        private void AlertDanger(string pmessage)
        {
            /*idModalAlertaServer.Visible = true;
            lblMensajePeligro.Text = pmessage;*/
        }

        private void Limpiar() {
            txtNombrePerfil.Value = "";
            txtDescripcion.Value = "";
        }

    }
}