using System;
using System.Data;
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
            //tvMenuUser.WebServiceSettings.Method = "GetNodesTours";
            //tvMenuUser.WebServiceSettings.Path = BicApplication.URLRoot + "Webservice/MenuService.asmx";
            MenuUserUtils.BindingRadTreeView(tvMenuUser, "en", "hotels");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var tourhotel = (TourHotelEntity)null;
        int id = 0;
        string[] ID = (!string.IsNullOrEmpty(Request.QueryString["id"]))
                          ? Request.QueryString["id"].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                          : null;
        string ThanhPho = MenuUserBiz.GetCheckedNodes(tvMenuUser);
        if (ID != null)
        {
            foreach (string item in ID)
            {
                if (int.TryParse(item, out id))
                {
                    tourhotel = TourHotelBiz.GetTourHotelByID(id);
                    tourhotel.ThanhPho = ThanhPho;
                    TourHotelBiz.UpdateTourHotel(tourhotel);
                }
            }
            //Response.Redirect(Request.Url.AbsolutePath);
        }
    }

    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "hotels");
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