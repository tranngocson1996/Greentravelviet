using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Document_ListingDocument : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/Edit_View_Delete.xml");
            radMenuContext.Items[2].Attributes.Add("onclick",string.Format("var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;",BicMessage.Delete));
            ddlDocumentTypeID.Language = ddlLanguage.SelectedValue;
            ddlDocumentTypeID.TypeOfControl = BIC.WebControls.TypeOfControl.Docs;
            ddlDocumentTypeID.LoadData();
        }
    }
    

    private void GetDataSource()
    {
        
        var bicData = new BicGetData();
        bicData.TableName = "Document";
        bicData.PageSize = rgManager.MasterTableView.PageSize;
        bicData.PageIndex = rgManager.MasterTableView.CurrentPageIndex;
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(DocumentEntity.FIELD_DOCUMENTID);
        bicData.Selecting.Add(DocumentEntity.FIELD_DISPLAYNAME);
        bicData.Selecting.Add(DocumentEntity.FIELD_VIEWNO);
        bicData.Selecting.Add(DocumentEntity.FIELD_BRIEFDESCRIPTION);
        bicData.Selecting.Add(DocumentEntity.FIELD_PRIORITY);
        bicData.Selecting.Add(DocumentEntity.FIELD_USERNAMEVIEW);
        bicData.Selecting.Add(DocumentEntity.FIELD_ISACTIVE);
        bicData.Conditioning.Add(new ConditioningItem(DocumentEntity.FIELD_USERNAMEVIEW, ddlLanguage.SelectedValue, Operator.LIKE, CompareType.STRING));
        if(txtSearch.Text != String.Empty)
            bicData.Conditioning.Add(new ConditioningItem(DocumentEntity.FIELD_DISPLAYNAME,
                                                          "%" + BicConvert.ToString(txtSearch.Text) + "%", Operator.LIKE,
                                                          CompareType.STRING));
       
        if (ddlDocumentTypeID.SelectedIndex != 0)
        {
            bicData.Conditioning.Add(new ConditioningItem
            {
                TypeOfCondition = TypeOfCondition.QUERY,
                Query = string.Format("DocumentTypeID = '{0}'", ddlDocumentTypeID.SelectedValue)
            });
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
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        ddlDocumentTypeID.Items.Clear();
        ddlDocumentTypeID.Language = ddlLanguage.SelectedValue;
        ddlDocumentTypeID.TypeOfControl = BIC.WebControls.TypeOfControl.Docs;
        ddlDocumentTypeID.LoadData();
        GetDataSource();
        rgManager.DataBind();
    }

    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        int id = BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DocumentID"]);
        DocumentBiz.DeleteDocument(id);
        rgManager.DataBind();
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetDataSource();
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        int id = Convert.ToInt32(rgManager.Items[index].GetDataKeyValue("DocumentID"));
        DocumentEntity documentEntity = DocumentBiz.GetDocumentByID(id);
        switch(e.Item.Value)
        {
            case "Add":
                BicAdmin.NavigateToAdd();
                break;
            case "View":
                BicAdmin.NavigateToView(id.ToString());
                break;
            case "Delete":
                if(Deleted && documentEntity.IsActive && Approved == false)
                    BicAjax.Alert("Bạn không có quyền xóa bản ghi đã được duyệt");
                else if(Deleted)
                {
                    bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                    if(confirm)
                    {
                        DocumentBiz.DeleteDocument(id);
                        rgManager.Rebind();
                    }
                }
                else if(Deleted == false)
                    BicAjax.Alert(BicMessage.DenyDelete);
                break;

            case "Edit":
                BicAdmin.NavigateToEdit(id.ToString());
                break;
        }
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch(e.CommandName)
        {
            case "IsActive":
                var dhIsActive = new DataHelper();
                int updateIsActive = e.CommandArgument.Equals("True") ? 0 : 1;
                if(
                    dhIsActive.UpdateColumn("IsActive", updateIsActive, "DocumentID",
                                            e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DocumentID"].ToString
                                                (), "Document") == false)
                    e.Canceled = true;
                else
                    rgManager.Rebind();
                break;
            case "Change":
                var dhChange = new DataHelper();
                dhChange.ChangePosition(
                    BicConvert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DocumentID"]), "DocumentID",
                    BicConvert.ToInt32(((DropDownList)e.Item.FindControl("ddlCurrentPosition")).SelectedItem.Text),
                    "Document");
                GetDataSource();
                rgManager.DataBind();
                break;
        }
    }

    protected void rgManager_ItemDataBound(object sender, GridItemEventArgs e)
    {
        var ibtnIsActive = (ImageButton)e.Item.FindControl("ibtnIsActive");
        //var ddlCurrentPosition = (DropDownList)e.Item.FindControl("ddlCurrentPosition");
        var imgImageId = (HtmlImage)e.Item.FindControl("imgImageID");
        if(ibtnIsActive != null)
        {
            ibtnIsActive.Enabled = Approved;
        }
        var drv = (DataRowView)e.Item.DataItem;
        if(drv == null) return;
        if(imgImageId != null)
        {
            BicImage.ViewImageFix(imgImageId, BicConvert.ToInt32(drv["ImageID"]), 50, 36, true);
        }
        //if(ddlCurrentPosition != null)
        //{
        //    DocumentBiz.PositionWithPriorityEdit(ddlCurrentPosition);
        //    ddlCurrentPosition.SelectedValue = BicConvert.ToString(drv["Priority"]);
        //}
    }
}