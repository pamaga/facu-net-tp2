using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        public bool _activado = true;
        private Usuario _usr;

        public Usuario Usr
        {
            get { return _usr; }
            set { _usr = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            Usr = ul.getUsuarioPermitido(this.LoginForm.UserName , this.LoginForm.Password);

            //la propiedad Text de los TextBox contiene el texto escrito en ellos
            if (Usr != null)
            {
                Session["id_usuario"] = Usr.ID;
                Session["tipo_usuario"] = ((int)Usr.TipoUsuario).ToString();
                Session["usuario"] = Usr.NombreUsuario;
                Session["nombre"] = Usr.Nombre;
                Session["apellido"] = Usr.Apellido;
                Response.Redirect("Default.aspx?loggedin=true");
            }
        }
    }
}