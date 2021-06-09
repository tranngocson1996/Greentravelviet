using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Search_AdditionSearch : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SearchBiz.PositionWithPriorityAdd(ddlPosition);
        }
    }
    private SearchEntity LoadDataToEntity()
    {
        var searchEntity = new SearchEntity();
        searchEntity.LanguageKey = ddlLanguage.SelectedValue;
        searchEntity.Description = BicConvert.ToString(txtDescription.Text);
        searchEntity.Keyword = BicConvert.ToString(txtKeyword.Text);
        searchEntity.ImageID = BicConvert.ToInt32(isImageID.ImageID);
        searchEntity.Link = BicConvert.ToString(txtLink.Text);
        searchEntity.Priority = BicConvert.ToInt32(ddlPosition.SelectedValue);
        searchEntity.IsActive = chkIsActive.Checked;
        searchEntity.DienThoai = txtPhone.Text;
        return searchEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    SearchBiz.InsertSearch(LoadDataToEntity());
                    BicAdmin.NavigateToList();
                    break;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.Message);
        }
    }
}