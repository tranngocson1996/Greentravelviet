using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Components_Room_ListingRoom : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
        radMenuContext.Items[2].Attributes.Add("onclick",
                                               string.Format(
                                                   "var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;",
                                                   BicMessage.Delete));
        if (BicSession.ToString("RoomLanguage") != string.Empty)
            ddlLanguage.SelectedValue = BicSession.ToString("RoomLanguage");
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "room", "cot1");
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData { TableName = "Room" };
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(RoomEntity.FIELD_ROOMID);
        bicData.Selecting.Add(RoomEntity.FIELD_ROOMNAME);
        bicData.Selecting.Add(RoomEntity.FIELD_PRICE);
        bicData.Selecting.Add(RoomEntity.FIELD_ISACTIVE);
        bicData.Selecting.Add(RoomEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(RoomEntity.FIELD_ISHOME);
        bicData.Selecting.Add(RoomEntity.FIELD_VIEWED);
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", ddlLanguage.SelectedValue, Operator.EQUAL,
                                                      CompareType.STRING));
        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(RoomEntity.FIELD_ROOMNAME,
                                                          "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE,
                                                          CompareType.STRING));
        if (tvMenuUser.CheckedNodes.Count > 0)
        {
            var ciMenuUser = new ConditioningItem
            {
                TypeOfCondition = TypeOfCondition.QUERY,
                Query = string.Format("convert(int,(select * from dbo.ListIsExist(MenuUserID,'{0}'))) > 0",
                                     MenuUserBiz.GetCheckedNodes(tvMenuUser))
            };

            bicData.Conditioning.Add(ciMenuUser);
        }

        if (ddlIsActive.SelectedValue != "2")
        {
            bicData.Conditioning.Add(new ConditioningItem("IsActive",
                                                          BicConvert.ToString(ddlIsActive.SelectedValue), Operator.EQUAL,
                                                          CompareType.NUMERIC));
        }
        DataTable data = bicData.GetPagingData();
        rgManager.VirtualItemCount = bicData.TotalItems;
        rgManager.DataSource = data;
    }

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RoomID"]);
        RoomBiz.DeleteRoom(id);
        rgManager.DataBind();
    }

    protected void ddlHotel_SelectedIndexChanged(object o, EventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
            int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("RoomID"));
            RoomEntity roomEntity = RoomBiz.GetRoomByID(id);
            switch (e.Item.Value)
            {
                case "Add":
                    BicAdmin.NavigateToAdd();
                    break;
                case "View":
                    BicAdmin.NavigateToView(id.ToString());
                    break;
                case "Delete":
                    if (Deleted && roomEntity.IsActive && Approved == false)
                        BicAjax.Alert("Bạn không có quyền xóa bản ghi đã được duyệt");
                    else if (Deleted)
                    {
                        bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            RoomBiz.DeleteRoom(id);
                            rgManager.Rebind();
                        }
                    }
                    else if (Deleted == false)
                        BicAjax.Alert(BicMessage.DenyDelete);
                    break;

                case "Edit":
                    BicAdmin.NavigateToEdit(id.ToString());
                    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "room", "cot1");
        BicSession.SetValue("RoomLanguage", ddlLanguage.SelectedValue);
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "IsHome":
                var dhIsHome = new DataHelper();
                int updateIsHome = e.CommandArgument.Equals("True") ? 0 : 1;
                if (
                    dhIsHome.UpdateColumn("IsHome", updateIsHome, "RoomID",
                                            e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RoomID"].ToString(),
                                            "Room") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                if (
                    dhIsActive.UpdateColumn("IsActive", updateIsActive, "RoomID",
                                            e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RoomID"].ToString(),
                                            "Room") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
            case "Change":
                var dhChange = new DataHelper();
                dhChange.ChangePosition(
                    BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["RoomID"]), "RoomID",
                    BicConvert.ToInt32(((DropDownList)e.Item.FindControl("ddlCurrentPosition")).SelectedItem.Text),
                    "Room");
                GetDataSource();
                rgManager.DataBind();
                break;
        }
    }

    protected void tvMenuUser_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {
     
        var ddlCurrentPosition = (DropDownList)e.Item.FindControl("ddlCurrentPosition");
        var drv = (DataRowView)e.Item.DataItem;
        if (drv == null) return;
        if (ddlCurrentPosition != null)
        {
            RoomBiz.PositionWithPriorityEdit(ddlCurrentPosition);
            ddlCurrentPosition.SelectedValue = BicConvert.ToString(drv["Priority"]);
        }
    }
    protected void tvMenuUser_NodeExpand(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(e.Node.Value), "room");
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