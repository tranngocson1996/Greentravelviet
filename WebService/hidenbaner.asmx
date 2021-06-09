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
     public void close_Click()
    {
        if (BicSession.ToString("hidenbaner") == "hiden") 
       BicSession.SetValue("hidenbaner","block");
        else
            BicSession.SetValue("hidenbaner", "hiden");
        //Session.Add("hidenbaner", "hiden");
    }
}