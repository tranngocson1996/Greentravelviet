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
    [WebMethod]
    public bool ViewCount(int advId)
    {
        AdvEntity advEntity = AdvBiz.GetAdvByID(advId);
        if (advEntity != null)
        {
            var dh = new DataHelper();
            if (dh.UpdateColumn("ViewCount", advEntity.ViewCount + 1, "AdvID", advEntity.AdvID.ToString(), "Adv"))
            {
                AdvBiz.PurgeCacheItems("Adv_Adv");
                BicAjax.Open(advEntity.Url, advEntity.Target);
                return true;
            }
            return false;
        }
        return false;
    }
}