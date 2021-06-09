using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Adv_EditionAdv : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        reDescription.CssFiles.Add(new EditorCssFile("~/BICSkins/BICCMS/Editor/EditorContentAreaStyles_ADV.css"));
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            TypeOfAdvBuilder();
            PositionWithPriority();
            LoadStaticMenu();
            MenuUserUtils.BindingRadTreeViewRecursion(tvnews, "vi", "news", true);
            LoadDataFromEntity();
        }
    }
    private void LoadStaticMenu()
    {
        var xml = new BicXML {XmlPath = "~/admin/XMLData/StaticMenu.xml"};
        DataSet data = xml.GetXMLContent();
        tvOther.DataSource = data;
        tvOther.DataValueField = "key";
        tvOther.DataTextField = "name";
        tvOther.DataBind();
    }
    protected void PositionWithPriority()
    {
        var dh = new DataHelper();
        DataTable dt = dh.PositionWithPriority("AdvId", "Adv");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ddlPosition.Items.Add(new ListItem((i + 1).ToString(), dt.Rows[i]["Priority"].ToString()));
        }
    }
    protected void TypeOfAdvBuilder()
    {
        BicXML.BindDropDownListFromXML(ddlTypeOfAdvID, string.Format("{0}admin/XMLData/TypeOfAdv_{1}.xml", BicApplication.URLRoot, ddlLanguage.SelectedValue));
        ddlTypeOfAdvID.Items.Insert(0, new ListItem("[ Chọn vị trí quảng cáo ]", "0"));
    }
    private void LoadDataFromEntity()
    {
        AdvEntity advEntity = AdvBiz.GetAdvByID(Id);
        if (advEntity != null)
        {
            ddlLanguage.SelectedValue = advEntity.LanguageKey;
            txtName.Text = BicConvert.ToString(advEntity.Name);
            ddlTypeOfAdvID.SelectedValue = BicConvert.ToString(advEntity.TypeOfAdvID);
            txtURL.Text = BicConvert.ToString(advEntity.Url);
            ddlTarget.SelectedValue = BicConvert.ToString(advEntity.Target);
            ddlPosition.SelectedValue = advEntity.Priority.ToString();
            //txtViewCount.Text = BicConvert.ToString(advEntity.ViewCount);
            //txtExpireDate.Text = BicDateTime.FormatDDMMYYYY(advEntity.ExpireDate);
            reDescription.Content = BicConvert.ToString(advEntity.Description);
            chkIsActive.Checked = BicConvert.ToBoolean(advEntity.IsActive);
            MenuUserUtils.CheckNode(tvOther, advEntity.MenuUserID);
            MenuUserBiz.SetCheckedNodes(tvnews, advEntity.MenuUserID);
        }
    }
    private AdvEntity LoadDataToEntity()
    {
        var advEntity = new AdvEntity {AdvID = Id, LanguageKey = ddlLanguage.SelectedValue, Name = BicConvert.ToString(txtName.Text), TypeOfAdvID = BicConvert.ToInt32(ddlTypeOfAdvID.SelectedValue), Url = BicConvert.ToString(txtURL.Text), Target = BicConvert.ToString(ddlTarget.SelectedValue), Priority = BicConvert.ToInt32(ddlPosition.SelectedItem.Text), //ViewCount = BicConvert.ToInt32(txtViewCount.Text),
                                       MenuUserID = MenuUserBiz.GetCheckedNodes(tvOther) + MenuUserBiz.GetCheckedNodes(tvnews), ExpireDate = DateTime.Now, Description = BicConvert.ToString(Server.HtmlDecode(reDescription.Content)), IsActive = chkIsActive.Checked};
        return advEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (ddlTypeOfAdvID.SelectedValue != "0")
                {
                    AdvBiz.UpdateAdv(LoadDataToEntity());
                    BicAdmin.NavigateToList();
                }
                else
                {
                    BicAjax.Alert("Bạn chưa chọn vị trí quảng cáo!");
                    ddlTypeOfAdvID.Focus();
                }
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        BicSession.SetValue("AdvLanguage", ddlLanguage.SelectedValue);
        TypeOfAdvBuilder();
    }
    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        string typeofcontrol = ((RadTreeView) sender).ID.Replace("tv", string.Empty);
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