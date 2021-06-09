<%@ WebService Language="C#" Class="AdvService" %>

using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AdvService : WebService
{
  
    [WebMethod(EnableSession = true)]
    public void adv_Click(string adv)
    {
        if (adv == "left")
            BicSession.SetValue("adv_left", "left");
        else
            BicSession.SetValue("adv_right", "right");
    }
}