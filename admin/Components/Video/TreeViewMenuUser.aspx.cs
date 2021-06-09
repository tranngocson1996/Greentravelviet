using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_Video_TreeViewMenuUser : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        string lang = BicHtml.GetRequestString("l", "vi");
        MenuUserUtils.BindingRadTreeView(tvMenuUser, lang, "video");
    }

    protected void btnMove_Click(object sender, EventArgs e)
    {
        MoveItem();
    }

    protected void MoveItem()
    {
        string items = BicString.Trim(BicHtml.GetRequestString("id", "0"));
        string menuUserID = tvMenuUser.SelectedNode.Value;
        if (items == "0" || string.IsNullOrEmpty(menuUserID)) return;
        try
        {
            string sql = string.Format(@"Update Article set MenuUserId= ',{0},' ,MainMenuUserID = {0} ,
            MenuUserName=isnull((select dbo.GetBuildStringToLink(MenuUser.Name,Article.LanguageKey) from MenuUser where MenuUser.MenuUserID = {0}),'')
            where ArticleID in ({1})", menuUserID, items);
            var dh = new DataHelper();
            dh.ExecuteSQL(sql);
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
        BizObject.PurgeCacheItems("Article_Article");
        BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message6")));
    }

    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "news");
        foreach (DataRow entity in dt.Rows)
        {
            var node = new RadTreeNode {Value = entity["MenuUserId"].ToString(), Text = entity["Name"].ToString()};
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            }
            e.Node.Nodes.Add(node);
        }
    }
}