using System;
using System.Linq;
using System.Web.UI;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public partial class admin_Controls_NavigatePath : UserControl
{
    public int ControlId { get; set; }
    protected void BuildNavigatePath()
    {
        lblNavigatePath.Text = string.Format("<a href='{0}/admin/default.aspx?l={2}' style='background:url({0}/admin/styles/icon/icon_home_16x16.gif)  0px center no-repeat; padding-left:21px;' >{1}</a>", Common.GetSiteUrl(), BicResource.GetValue("Admin", "Admin_NavigatePath_Home"), BicHtml.GetRequestString("l", "vi"));
        MenuAdminEntity menuAdminEntity2 = MenuAdminBiz.GetMenuAdminByID(BicHtml.GetRequestString("mid", 0));
        if (menuAdminEntity2 != null)
        {
            string[] navigateArray = BicString.SplitComma(menuAdminEntity2.NavigatePath);
            if (navigateArray.Length > 0)
            {
                foreach (MenuAdminEntity menuAdminEntity in
                    navigateArray.Select(s => MenuAdminBiz.GetMenuAdminByID(BicConvert.ToInt32(s))))
                {
                    if (menuAdminEntity != null)
                    {
                        string item;
                        if (menuAdminEntity.MenuUrl.Contains("http") || menuAdminEntity.MenuUrl.Contains("https"))
                            item = string.Format(" > <a href='{0}' target='{2}'>{1}</a>", menuAdminEntity.MenuUrl, BicResource.GetValue("Admin", menuAdminEntity.Name), menuAdminEntity.Target);
                        else if (menuAdminEntity.MenuUrl.Equals(string.Empty))
                            item = string.Format(" > {0}", BicResource.GetValue("Admin", menuAdminEntity.Name));
                        else
                            item = string.Format(" > <a href='{0}admin/default.aspx?mid={4}&cid={3}&l={5}' target='{2}'>{1}</a>", BicApplication.URLRoot, BicResource.GetValue("Admin", menuAdminEntity.Name), menuAdminEntity.Target, ControlId, BicHtml.GetRequestString("mid"), BicHtml.GetRequestString("l", "vi"));
                        lblNavigatePath.Text += item;
                    }
                }
                string action = BicHtml.GetRequestString("action");
                if (action.Equals("add"))
                    lblNavigatePath.Text += ": <span style='color:#FFF; font-weight:bold'>" + BicResource.GetValue("Admin", "System_Add") + "</span>";
                if (action.Equals("edit"))
                    lblNavigatePath.Text += ": <span style='color:#FFF; font-weight:bold'>" + BicResource.GetValue("Admin", "Admin_NavigatePath_Edit") + "</span>";
                if (action.Equals("view"))
                    lblNavigatePath.Text += ": <span style='color:#FFF; font-weight:bold'>" + BicResource.GetValue("Admin", "Admin_NavigatePath_WatchContent") + "</span>";
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ControlId = BicHtml.GetRequestString("cid", 0);
        if (!IsPostBack)
            BuildNavigatePath();
    }
}