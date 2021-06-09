using System;
using System.Data;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Tour_ListingTour : BaseUserControl
{
    public int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (BicSession.ToString("TourLanguage") != string.Empty)
                ddlLanguage.SelectedValue = BicSession.ToString("TourLanguage");
            MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "tours");
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",
                                                    string.Format("var as;as=confirm('{0}');document.getElementById('confirmdelete').value = as;", BicMessage.Delete));
            
            GetDataSource();
            txtLanguage.Value = ddlLanguage.SelectedValue;
        }
    }

    private void GetDataSource()
    {
        var bicData = new BicGetData
        {
            TableName = "Tour"
        };

      
        bicData.Selecting.Add(TourEntity.FIELD_TOURID);
        bicData.Selecting.Add(TourEntity.FIELD_TENTOUR);
        bicData.Selecting.Add(TourEntity.FIELD_GIAHIENTHI);
        bicData.Selecting.Add(TourEntity.FIELD_SONGAY);
        bicData.Selecting.Add(TourEntity.FIELD_SODEM);
        bicData.Selecting.Add(TourEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(TourEntity.FIELD_LUOTXEM);
        bicData.Selecting.Add(TourEntity.FIELD_ISNEW);
        bicData.Selecting.Add(TourEntity.FIELD_ISACTIVE);
        bicData.Selecting.Add(TourEntity.FIELD_NHOMTOUR);
        bicData.Selecting.Add(TourEntity.FIELD_MODIFIEDDATE);

        bicData.Sorting.Add(new SortingItem(TourEntity.FIELD_MODIFIEDDATE, true));
        bicData.Sorting.Add(new SortingItem(TourEntity.FIELD_PRIORITY, false));
        bicData.Selecting.Add("Mota1");

        bicData.Selecting.Add(string.Format("dbo.MenuUserIdToNames({0}) as Nhom", TourEntity.FIELD_NHOMTOUR));
        bicData.Conditioning.Add(new ConditioningItem("LanguageKey", ddlLanguage.SelectedValue, Operator.EQUAL, CompareType.STRING));
        
      

        if (txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(TourEntity.FIELD_TENTOUR, "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE, CompareType.STRING));
        if (tvMenuUser.CheckedNodes.Count > 0)
        {
            var ciMenuUser = new ConditioningItem
            {
                TypeOfCondition = TypeOfCondition.QUERY,
                Query = string.Format("convert(int,(select * from dbo.ListIsExist(NhomTour,'{0}'))) > 0",
                                     MenuUserBiz.GetCheckedNodes(tvMenuUser))
            };

            bicData.Conditioning.Add(ciMenuUser);
        }
        if (ddlIsActive.SelectedValue != "2")
            bicData.Conditioning.Add(new ConditioningItem("IsActive", ddlIsActive.SelectedValue, Operator.EQUAL, CompareType.NUMERIC));
        string s = bicData.BuildSQLString();
        DataTable data = bicData.GetAllData();
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
        // id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourID"]);
        //TourBiz.DeleteTour(id);
        //GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {
        var ddlCurrentPosition = (DropDownList)e.Item.FindControl("ddlCurrentPosition");
        var drv = (DataRowView)e.Item.DataItem; if (drv == null) return;
        //if (ddlCurrentPosition != null) { TourBiz.PositionWithPriorityEdit(ddlCurrentPosition); ddlCurrentPosition.SelectedValue = BicConvert.ToString(drv["Priority"]); }
        var ibtnIsActive = (ImageButton)e.Item.FindControl("ibtnIsActive");
        if (ibtnIsActive != null) ibtnIsActive.Enabled = Approved;
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        var index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        var id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("TourID"));
        var tourEntity = TourBiz.GetTourByID(id);
        switch (e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if (Deleted && tourEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã duyệt.");
                else
                    if (Deleted)
                    {
                        var c = Request.Form["confirmdelete"];
                        bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                        if (confirm)
                        {
                            TourBiz.DeleteTour(id);
                            GetDataSource();
                            rgManager.DataBind();
                        }
                    }
                    else
                        if (Deleted == false)
                            BicAjax.Alert(BicMessage.DenyDelete);
                break;
            case "Edit":
                if (Edited && tourEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền sửa bản ghi đã duyệt");
                else
                    if (Edited)
                    {
                        BicAdmin.NavigateToEdit(id.ToString());
                    }
                    else
                        if (Edited == false)
                            BicAjax.Alert(BicMessage.DenyEdit);
                break;
        }
    }

    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        MenuUserUtils.BindingRadTreeView(tvMenuUser, ddlLanguage.SelectedValue, "tours");
        txtLanguage.Value = ddlLanguage.SelectedValue;
        BicSession.SetValue("TourLanguage", ddlLanguage.SelectedValue);
        GetDataSource();
        rgManager.DataBind();

    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Change":
                var dhChange = new DataHelper();
                dhChange.ChangePosition(
                    BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourID"]), "TourID",
                    BicConvert.ToInt32(((DropDownList)e.Item.FindControl("ddlCurrentPosition")).SelectedItem.Text),
                    "Tour");
                GetDataSource();
                rgManager.DataBind();
                break;
            case "IsNew":
                var dhIsNew = new DataHelper();
                    string updateIsNew = e.CommandArgument.Equals("True") ? "False" : "True";
                    if (dhIsNew.UpdateColumn("Mota1", updateIsNew, "TourID",e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourID"].ToString(),"Tour"))
                    {
                        GetDataSource();
                        rgManager.DataBind();
                    }
                    else
                        e.Canceled = true;  
                break;
            case "IsActive":
                if (BicRadGrid.ExecuteBooleanCommand(e, e.CommandName, "TourId", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["TourID"].ToString(), "Tour"))
                    GetDataSource();
                else
                    e.Canceled = true;
                rgManager.DataBind();
                break;
            case "DeleteSelected":
                if (!Deleted)
                    BicAjax.Alert(BicMessage.DenyDelete);
                else
                {
                    foreach (GridDataItem item in rgManager.SelectedItems)
                    {
                        if (item.Selected)
                        {
                            // Access data key
                            int id = BicConvert.ToInt32(item.GetDataKeyValue("TourID"));
                            // Access column

                            TourEntity TourEntity = TourBiz.GetTourByID(id);
                            if (TourEntity != null)

                            {if (TourEntity.IsActive && Approved == false)
                                BicAjax.Alert(string.Format(BicResource.GetValue("Admin", "Admin_Article_Message1")));
                            else
                            {
                                TourBiz.DeleteTour(id);
                            }}

                        }
                    }
                    GetDataSource();
                }
                break;
        }
    }

    public string GetCheckId()
    {
        try
        {
            CheckBox checkBox = null;
            string output = string.Empty;
            foreach (GridDataItem item in rgManager.Items)
            {
                TableCell cell = item["column"];
                checkBox = (CheckBox)cell.FindControl("column");
                if (checkBox.Checked)
                {
                    output += item.GetDataKeyValue("TourID") + ",";
                }
            }
            return output.Substring(0, output.Length - 1);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    protected void tvMenuUser_NodeExpand(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
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

    protected void tvMenuUser_NodeCheck(object sender, RadTreeNodeEventArgs e)
    {
        GetDataSource();
        rgManager.DataBind();
    }
}