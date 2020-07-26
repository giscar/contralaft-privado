using System.Web;
using System.Web.UI.WebControls;
using SBS.UIF.CONTRALAFT.Entity.Core;

namespace SBS.UIF.CONTRALAFT.Web.comun {

    public class PaginaBase : System.Web.UI.Page {

        public void LlenarDropDownList(DropDownList Combo, object Lista, string ValorRegistroVacio, string TextoRegistroVacio) {
            Combo.Items.Clear();
            Combo.DataSource = Lista;
            Combo.DataBind();
            if (ValorRegistroVacio != "") {
                Combo.Items.Insert(0, new ListItem(TextoRegistroVacio, ValorRegistroVacio));
            }
        }

        public void LlenarCheckList(CheckBoxList Combo, object Lista, string ValorRegistroVacio, string TextoRegistroVacio)
        {
            Combo.Items.Clear();
            Combo.DataSource = Lista;
            Combo.DataBind();
            if (ValorRegistroVacio != "")
            {
                Combo.Items.Insert(0, new ListItem(TextoRegistroVacio, ValorRegistroVacio));
            }
        }

        public Usuario UsuarioSession() {
            Usuario usuarioSession = (Usuario)HttpContext.Current.Session["Usuario"];
            return usuarioSession;
        }
    }
}