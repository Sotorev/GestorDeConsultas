using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_final
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Lectura().LeerUsuarios();
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var usuario = Lectura.Usuarios.Find(u => u.UserName == Login1.UserName);
            bool esPasswordValido = BCrypt.Net.BCrypt.Verify(Login1.Password,usuario.Password);
            if (esPasswordValido)
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now,
                DateTime.Now.AddMinutes(30), Login1.RememberMeSet, usuario.Level.ToString());
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (Login1.RememberMeSet)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "Default.aspx";
                Response.Redirect(strRedirect, true);
            }
        }
    }
}
