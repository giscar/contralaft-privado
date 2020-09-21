using System;
using System.Web.UI;

namespace SBS.UIF.BUZ.Web.util
{
    public class ClientMessageBox
    {
        public static void Show(string message, Control owner)
        {
            Page page = (owner as Page) ?? owner.Page;
            if (page == null) return;

            page.ClientScript.RegisterStartupScript(owner.GetType(),
                "ShowMessage", string.Format("<script type='text/javascript'>showInactiv('{0}')</script>",
                message));

        }
    }
}
