using System;
using BIC.WebControls;
using Oauth2Login.Service;

public partial class Controls_User_ModalLogin : BaseUIControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnLoginFacebook_OnClick(object sender, EventArgs e)
    {
        var service = BaseOauth2Service.GetService("facebook");
        if (service != null)
        {
            var url = service.BeginAuthentication();
            Response.Redirect(url);
        }
    }
    protected void btnLoginGoogle_OnClick(object sender, EventArgs e)
    {
        var service = BaseOauth2Service.GetService("Google");
        if (service != null)
        {
            var url = service.BeginAuthentication();
            Response.Redirect(url);
        }
    }
}