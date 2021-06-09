using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class admin_Components_Tour_TreeViewMenuUser : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // tvMenuUser.WebServiceSettings.Method = "GetNodesTours";
            //tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
            MenuUserUtils.BindingRadTreeView(tvMenuUser, Request["l"].ToString(), "tours");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var tour = (TourEntity)null;
        int id = 0;
        string[] ID = (!string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries) : null;
        string NhomTour = MenuUserBiz.GetCheckedNodes(tvMenuUser);
        if (ID != null)
        {
            foreach (string item in ID)
            {
                if (int.TryParse(item, out id))
                {
                    tour = TourBiz.GetTourByID(id);
                    tour.NhomTour = NhomTour;
                    TourBiz.UpdateTour(tour);
                }
            }
            //Response.Redirect(Request.Url.AbsolutePath);
        }
    }

    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "tours");
        foreach (DataRow entity in dt.Rows)
        {
            var node = new RadTreeNode();
            node.Value = entity["MenuUserId"].ToString();
            node.Text = entity["Name"].ToString();
            node.Enabled = BicConvert.ToBoolean(entity["EnableCheck"]);
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            }
            e.Node.Nodes.Add(node);
        }
    }
}