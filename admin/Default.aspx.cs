using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BIC.Biz;
using BIC.Components;
using BIC.WebControls;
using BIC.Entity;
using BIC.Utils;

public partial class admin_Default : BasePageAdmin
{
    private void LoadUserControls()
    {
        int controlId = BicHtml.GetRequestString("cid", 0);
        string key = "Default_" + controlId + "_" + ActionType.GetActionName();
        string url;
        hdfLang.Value = BicHtml.GetRequestString("l") == "" ? BicXML.ToString("DefaultLanguageAdmin", "SearchEngine") : BicHtml.GetRequestString("l");
        if (BicCache.ReadCache(key) == null)
        {
            if (controlId.Equals(0))
                url = BicApplication.URLRoot + "admin/Controls/Home.ascx";

            else if (controlId.Equals(1000))
                url = BicApplication.URLRoot + "admin/Controls/AccessDeny.ascx";
                
            else
            {
                url = ActionType.GetControl();
            }
            BicCache.CacheData(key, url);
        }
        else
        {
            url = BicCache.ReadCache(key).ToString();
        }
        if (controlId != 0 && controlId != 1000)
            RoutingPage();
        phMainUserControl.Controls.Clear();
        phMainUserControl.Controls.Add(LoadControl(url));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!HttpContext.Current.Profile.GetPropertyValue("TypeOfUser").ToString().Equals("System") &&
                BicMemberShip.CurrentUserName.ToLower() != "administrator")
                //Kiem tra co phai tai khoan he thong khong, neu khong phai chuyen ve trang login
                BicHtml.Navigate("Login.aspx");

        }

        LoadUserControls();
    }

    public void RemoveCache()
    {
        var keyList = new List<string>();
        IDictionaryEnumerator cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (string key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    protected void lbtnClearCache_Click(object sender, EventArgs e)
    {
        RemoveCache();
        //Mobile.ClearCacheService mb = new Mobile.ClearCacheService();
        //mb.ClearCache();
    }

    private void RoutingPage()
    {
        PermissionEntity permissionEntity = ControlRoleBiz.CheckPermistion();
        string action = BicHtml.GetRequestString("action", string.Empty);

        switch (action)
        {
            case "edit":
                if (permissionEntity.Edited == false)
                    BicAdmin.NavigateToDenyPage();
                break;
            case "del":
                if (permissionEntity.Deleted == false)
                    BicAdmin.NavigateToDenyPage();
                break;
            case "list":
                if (permissionEntity.Viewed == false)
                    BicAdmin.NavigateToDenyPage();
                break;
            case "view":
                if (permissionEntity.Viewed == false)
                    BicAdmin.NavigateToDenyPage();
                break;
        }
    }
}