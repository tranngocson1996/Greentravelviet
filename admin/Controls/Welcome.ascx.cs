using System;
using System.Data;
using System.Web.UI;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using Telerik.Web.UI;

public partial class admin_Controls_Welcome : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTree(1, rtCategory, "icon_cms.png");
            LoadTree(4, rtFunction, "icon_cms2.png");
            LoadTree(6, rtUtils, "icon_cms3.png");
            LoadTree(11, rtHelp, "icon_cms4.png");
        }
    }
    private static void LoadTree(int menuid, RadTreeView rtv, string icon)
    {
        rtv.DataSource = BuildTreeMenuAdminByParent(menuid);
        rtv.DataTextField = "Name";
        rtv.DataFieldID = "MenuAdminID";
        rtv.DataValueField = "MenuAdminID";
        rtv.DataFieldParentID = "ParentID";
        rtv.DataBind();
        rtv.ExpandAllNodes();

        rtv.Nodes[0].ImageUrl = string.Format("{0}admin/Styles/icon/{1}", BicApplication.URLRoot, icon);

        foreach (RadTreeNode node in rtv.GetAllNodes())
        {
            node.Text = BicResource.GetValue("Admin", node.Text);
        }


    }
    private static DataTable GetMenuAdminByParent(int parentid)
    {
        var data = new BicGetData { TableName = "MenuAdmin" };
        data.Conditioning.Add(new ConditioningItem { Column = "ParentID", Value = parentid.ToString(), CompareType = CompareType.NUMERIC, Operator = Operator.EQUAL });
        data.Conditioning.Add(new ConditioningItem { Column = "IsActive", Value = "1", CompareType = CompareType.NUMERIC, Operator = Operator.EQUAL });
        data.Sorting.Add(new SortingItem("Priority", false));
        return data.GetAllData();
    }
    private static DataTable GetMenuAdmin(int parentid)
    {
        var data = new BicGetData { TableName = "MenuAdmin" };
        data.Conditioning.Add(new ConditioningItem { Column = "MenuAdminID", Value = parentid.ToString(), CompareType = CompareType.NUMERIC, Operator = Operator.EQUAL });
        data.Conditioning.Add(new ConditioningItem { Column = "IsActive", Value = "1", CompareType = CompareType.NUMERIC, Operator = Operator.EQUAL });
        data.Sorting.Add(new SortingItem("Priority", false));
        return data.GetAllData();
    }
    private static DataTable BuildTreeMenuAdminByParent(int parentid)
    {
        var dataTotal = new DataTable();
        DataTable data0 = GetMenuAdmin(parentid);
        DataTable data = GetMenuAdminByParent(parentid);
        foreach (DataRow dr in data.Rows)
        {
            DataTable subdata = GetMenuAdminByParent(BicConvert.ToInt32(dr["MenuAdminID"]));
            dataTotal.Merge(subdata);
        }
        dataTotal.Merge(data);
        dataTotal.Merge(data0);
        return dataTotal;
    }
    protected void BuildTreeNode(RadTreeNode rtn)
    {
        var drv = (DataRowView)rtn.DataItem;
        string sUrl = drv[MenuAdminEntity.FIELD_MENUURL].ToString();
        rtn.Target = drv[MenuAdminEntity.FIELD_TARGET].ToString();
        if (!sUrl.Equals(string.Empty))
            if (sUrl.Contains("http") || sUrl.Contains("https"))
                rtn.NavigateUrl = sUrl;
            else
                rtn.NavigateUrl = string.Format("{0}" + sUrl + "&l=" + BicHtml.GetRequestString("l", "vi"), BicApplication.URLRoot + "admin/default.aspx?mid=" + drv[MenuAdminEntity.FIELD_MENUADMINID]);
    }
    protected void rtCategory_NodeDataBound(object sender, RadTreeNodeEventArgs e)
    {
        BuildTreeNode(e.Node);
    }
}