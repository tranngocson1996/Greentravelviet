using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using Telerik.Web.UI;

[ScriptService]
public class MenuService : WebService
{
    [WebMethod(EnableSession = true)]
    public RadMenuItemData[] GetMenuCategories(RadMenuItemData item, object context)
    {
        List<MenuUserEntity> menu = MenuUserBiz.GetByParentId(BicConvert.ToInt32(item.Value));
        var result = new List<RadMenuItemData>();
        foreach (MenuUserEntity entity in menu)
        {
            if (entity.IsNew)
                entity.Name += string.Format(" <img src='{0}Styles/img/newicon.gif' />", BicApplication.URLRoot);
            var itemData = new RadMenuItemData
            {
                Text = entity.Name,
                Value = entity.MenuUserId.ToString(),
                NavigateUrl = entity.URL,
                Target = entity.Target
            };

            if (entity.TypeID > 0)
            {
                itemData.ExpandMode = MenuItemExpandMode.WebService;
            }
            result.Add(itemData);
        }

        return result.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public RadTreeNodeData[] GetNodesNews(RadTreeNodeData node, IDictionary context)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(node.Value), "news");
        var result = new List<RadTreeNodeData>();
        foreach (DataRow entity in dt.Rows)
        {
            var radTreeNode = new RadTreeNodeData
                                  {
                                      Value = entity["MenuUserId"].ToString(),
                                      Text = entity["Name"].ToString(),
                                      Enabled = BicConvert.ToBoolean(entity["EnableCheck"])
                                  };
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                radTreeNode.ExpandMode = TreeNodeExpandMode.WebService;
            }

            result.Add(radTreeNode);
        }

        return result.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public RadTreeNodeData[] GetNodesProducts(RadTreeNodeData node, IDictionary context)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(node.Value), "products");
        var result = new List<RadTreeNodeData>();
        foreach (DataRow entity in dt.Rows)
        {
            var radTreeNode = new RadTreeNodeData
            {
                Value = entity["MenuUserId"].ToString(),
                Text = entity["Name"].ToString(),
                Enabled = BicConvert.ToBoolean(entity["EnableCheck"])
            };
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                radTreeNode.ExpandMode = TreeNodeExpandMode.WebService;
            }

            result.Add(radTreeNode);
        }

        return result.ToArray();
    }
}