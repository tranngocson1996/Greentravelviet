using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_AdvVideo_EditionAdvVideo : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if(!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            AdvVideoBiz.PositionWithPriorityEdit(ddlPosition);
            
            MenuUserUtils.BindingRadTreeViewRecursion(tvnews, "vi", "news", true);
            LoadStaticMenu();LoadDataFromEntity();
        }
    }
    private void LoadStaticMenu()
    {
        var xml = new BicXML { XmlPath = "~/admin/XMLData/StaticMenu.xml" };
        DataSet data = xml.GetXMLContent();
        tvOther.DataSource = data;
        tvOther.DataValueField = "key";
        tvOther.DataTextField = "name";
        tvOther.DataBind();
    }
    private void LoadDataFromEntity()
    {
        AdvVideoEntity advvideoEntity = AdvVideoBiz.GetAdvVideoByID(Id);
        if(advvideoEntity != null)
        {
            ddlLanguage.SelectedValue = advvideoEntity.LanguageKey;
            txtName.Text = BicConvert.ToString(advvideoEntity.Name);
            txtLink.Text = BicConvert.ToString(advvideoEntity.Link);
            txtURL.Text = BicConvert.ToString(advvideoEntity.Url);
            if(!string.IsNullOrEmpty(advvideoEntity.Path))
                filePath.Value = BicConvert.ToString(advvideoEntity.Path);
            var hour = advvideoEntity.ThoiGianBatDau.Hour;
            cbTimeSelect.SelectedValue = hour.ToString();
            ddlTarget.SelectedValue = BicConvert.ToString(advvideoEntity.Target);
            txtThoiGianBatDau.Text = BicConvert.ToString(advvideoEntity.ThoiGianBatDau);
            txtKhoangThoiGian.Text = BicConvert.ToString(advvideoEntity.KhoangThoiGian);
            //ddlTypeOfAdvID.SelectedValue = BicConvert.ToString(advvideoEntity.TypeOfAdvID);
            txtMenuUserID.Text = BicConvert.ToString(advvideoEntity.MenuUserID);
            txtTextDisplay.Text = BicConvert.ToString(advvideoEntity.TextDisplay);
            reDescription.Content = BicConvert.ToString(advvideoEntity.Description);
            txtViewCount.Text = BicConvert.ToString(advvideoEntity.ViewCount);
            ddlPosition.SelectedValue = advvideoEntity.Priority.ToString();
            chkIsActive.Checked = BicConvert.ToBoolean(advvideoEntity.IsActive);
            MenuUserUtils.CheckNode(tvOther, advvideoEntity.MenuUserID);
            MenuUserBiz.SetCheckedNodes(tvnews, advvideoEntity.MenuUserID);
        }
    }
    private AdvVideoEntity LoadDataToEntity()
    {
        var advvideoEntity = new AdvVideoEntity
                                 {
                                     AdvVideoID = Id,
                                     LanguageKey = ddlLanguage.SelectedValue,
                                     Name = BicConvert.ToString(txtName.Text),
                                     Url = BicConvert.ToString(txtURL.Text),
                                     Link = BicConvert.ToString(txtLink.Text),
                                     Path = BicConvert.ToString(filePath.Value),
                                     Target = BicConvert.ToString(ddlTarget.SelectedValue),
                                     ThoiGianBatDau = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, BicConvert.ToInt32(cbTimeSelect.SelectedValue), 0, 0),
                                     KhoangThoiGian = BicConvert.ToDouble(txtKhoangThoiGian.Text),
                                     MenuUserID = MenuUserBiz.GetCheckedNodes(tvOther) + MenuUserBiz.GetCheckedNodes(tvnews),
                                     TextDisplay = BicConvert.ToString(txtTextDisplay.Text),
                                     Description = BicConvert.ToString(reDescription.Html),
                                     ViewCount = BicConvert.ToInt32(txtViewCount.Text),
                                     Priority = BicConvert.ToInt32(ddlPosition.SelectedValue),
                                     IsActive = chkIsActive.Checked
                                 };

        //advvideoEntity.TypeOfAdvID = BicConvert.ToInt32(ddlTypeOfAdvID.SelectedValue);
        return advvideoEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if(e.CommandName == "Update")
            {
                AdvVideoBiz.UpdateAdvVideo(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
        catch(Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        string typeofcontrol = ((RadTreeView)sender).ID.Replace("tv", string.Empty);
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "news");
        foreach (DataRow entity in dt.Rows)
        {
            var node = new RadTreeNode();
            node.Value = entity["MenuUserId"].ToString();
            node.Text = entity["Name"].ToString();
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                node.Checkable = true;
            }
            e.Node.Nodes.Add(node);
        }
    }
    protected void tvOther_OnNodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        var dt = new DataTable();
        var radTreeNode = new RadTreeNode();
        if (e.Node.Value == "-1" || e.Node.Value == "-2")
        {
            foreach (RadTreeNode node in tvnews.Nodes)
            {
                foreach (RadTreeNode childNode in node.Nodes)
                {
                    if (e.Node.Value == "-1")
                    {
                        childNode.Checked = e.Node.Checked;
                    }
                    if (e.Node.Value == "-2")
                    {
                        foreach (RadTreeNode radTreeNode2 in childNode.Nodes)
                        {
                            radTreeNode2.Checked = e.Node.Checked;
                        }
                    }
                }
            }
        }
    }
}