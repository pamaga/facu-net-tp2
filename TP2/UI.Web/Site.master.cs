using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void MenuPrincipal_DataBound(object sender, MenuEventArgs e)
        {
            SiteMapNode node = (SiteMapNode)e.Item.DataItem;
            string[] accesos = node["tipoUsuario"].Split(',');
            if (!accesos.Contains(Session["tipo_usuario"]))
            {
                if (e.Item.Parent != null) //if this item has a parent..
                    e.Item.Parent.ChildItems.Remove(e.Item); //use parent to remove child..
                else
                    MenuPrincipal.Items.Remove(e.Item); //else.. remove from menu itself.
            }
        }

        protected void MenuPrincipal_MenuItemClick(object sender, MenuEventArgs e)
        {

        }
    }
}
