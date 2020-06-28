using System.Web.UI;
using System.Web.UI.WebControls;


namespace SBS.UIF.CONTRALAFT.Web.comun {

    public class PaginaBase : Page
    {

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
    }
}