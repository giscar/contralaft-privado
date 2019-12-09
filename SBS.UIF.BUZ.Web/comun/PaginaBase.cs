using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace SBS.UIF.BUZ.Web.comun {

    public class PaginaBase : System.Web.UI.Page {

        public void LlenarDropDownList(DropDownList Combo, object Lista, string ValorRegistroVacio, string TextoRegistroVacio) {
            Combo.Items.Clear();
            Combo.DataSource = Lista;
            Combo.DataBind();
            if (ValorRegistroVacio != "") {
                Combo.Items.Insert(0, new ListItem(TextoRegistroVacio, ValorRegistroVacio));
            }
        }
    }
}