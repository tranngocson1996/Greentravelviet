using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Room_AdditionRoom : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            if (BicSession.ToString("RoomLanguage") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("RoomLanguage");
            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "room","cot1");
            RoomBiz.PositionWithPriorityAdd(ddlPosition);
        }
    }

    private RoomEntity LoadDataToEntity()
    {
        var roomEntity = new RoomEntity
                             {
                                 MenuUserID = MenuUserBiz.GetCheckedNodes(tvMenuUser),
                                 LanguageKey = ddlLanguage.SelectedValue,
                                 RoomName = BicConvert.ToString(txtRoomName.Text),
                                 Price = BicConvert.ToString(txtPrice.Text),
                                 ImageID = BicConvert.ToInt32(isImageID.ImageID),
                                 ImageArray = BicConvert.ToString(ismImageArray.ImageIDArray),
                                 BriefDescription = reBriefDescription.Content,
                                 Description = Server.HtmlDecode(reBody.Content),
                                 Viewed = BicConvert.ToInt32(txtViewed.Text),
                                 Link = BicConvert.ToString(txtLink.Text),
                                 Tag = BicConvert.ToString(txtTag.Text),
                                 SEOTitle = BicConvert.ToString(txtSeoTitle.Text),
                                 IsActive = chkIsActive.Checked,
                                 IsHome = chkHome.Checked,
                                 Priority = BicConvert.ToInt32(ddlPosition.SelectedItem.Text),
                                 Vote = 0,
                                 Promotion = txtPromotion.Text
                             };
        return roomEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (tvMenuUser.CheckedNodes.Count == 0)
                    {
                        BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
                    }
                    else
                    {
                        RoomBiz.InsertRoom(LoadDataToEntity());
                        BicAdmin.NavigateToList();
                    }
                    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.Message);
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("RoomLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "room", "cot1");
    }

    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "room");
        foreach (DataRow entity in dt.Rows)
        {
            var node = new RadTreeNode
                           {
                               Value = entity["MenuUserId"].ToString(),
                               Text = entity["Name"].ToString(),
                               Enabled = BicConvert.ToBoolean(entity["EnableCheck"])
                           };
            if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
            {
                node.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
            }
            e.Node.Nodes.Add(node);
        }
    }
}