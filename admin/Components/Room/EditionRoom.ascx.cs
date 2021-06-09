using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Room_EditionRoom : BaseUserControl
{
    protected int Id;

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);

        if (!IsPostBack)
        {
            RoomBiz.PositionWithPriorityEdit(ddlPosition);
            LoadDataFromEntity();

        }
    }

    private void LoadDataFromEntity()
    {
        RoomEntity roomEntity = RoomBiz.GetRoomByID(Id);
        if (roomEntity == null) return;
        ddlLanguage.SelectedValue = roomEntity.LanguageKey;
        txtRoomName.Text = BicConvert.ToString(roomEntity.RoomName);
        txtPrice.Text = BicConvert.ToString(roomEntity.Price);
        isImageID.ImageID = BicConvert.ToString(roomEntity.ImageID);
        ismImageArray.ImageIDArray = BicConvert.ToString(roomEntity.ImageArray);
        reBriefDescription.Content = BicConvert.ToString(roomEntity.BriefDescription);
        reBody.Content = BicConvert.ToString(roomEntity.Description);
        chkIsActive.Checked = BicConvert.ToBoolean(roomEntity.IsActive);
        txtViewed.Text = BicConvert.ToString(roomEntity.Viewed);
        chkHome.Checked = BicConvert.ToBoolean(roomEntity.IsHome);
        txtLink.Text = roomEntity.Link;
        txtSeoTitle.Text = roomEntity.SEOTitle;
        txtTag.Text = roomEntity.Tag;
        txtPromotion.Text = roomEntity.Promotion;
        ddlPosition.SelectedValue = roomEntity.Priority.ToString();
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "room", "cot1");
        MenuUserBiz.SetCheckedNodes(tvMenuUser, roomEntity.MenuUserID);
    }

    private RoomEntity LoadDataToEntity()
    {
        var roomEntity = new RoomEntity
        {
            RoomID = Id,
            MenuUserID = MenuUserBiz.GetCheckedNodes(tvMenuUser),
            LanguageKey = ddlLanguage.SelectedValue,
            RoomName = BicConvert.ToString(txtRoomName.Text),
            Price = BicConvert.ToString(txtPrice.Text),
            ImageID = BicConvert.ToInt32(isImageID.ImageID),
            ImageArray = BicConvert.ToString(ismImageArray.ImageIDArray),
            BriefDescription = Server.HtmlDecode(reBriefDescription.Content),
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
            if (e.CommandName == "Update")
            {

                if (tvMenuUser.CheckedNodes.Count == 0)
                {
                    BicAjax.Alert("Bạn phải chọn ít nhất một danh mục.");
                }
                else
                {
                    if (RoomBiz.UpdateRoom(LoadDataToEntity()))
                        BicAdmin.NavigateToList();
                    else
                        BicAjax.Alert(BicMessage.UpdateFail);
                }

            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("RoomLanguage", ddlLanguage.SelectedValue);
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "room", "cot1");
    }

    protected void tvMenuUser_NodeExpand(object sender, RadTreeNodeEventArgs e)
    {
        var dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "room");
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