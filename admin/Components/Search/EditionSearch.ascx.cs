using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Search_EditionSearch : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            SearchBiz.PositionWithPriorityEdit(ddlPosition);
            LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
        SearchEntity searchEntity = SearchBiz.GetSearchByID(Id);
        if (searchEntity != null)
        {
            ddlLanguage.SelectedValue = searchEntity.LanguageKey;
            txtDescription.Text = BicConvert.ToString(searchEntity.Description);
            txtKeyword.Text = BicConvert.ToString(searchEntity.Keyword);
            isImageID.ImageID = BicConvert.ToString(searchEntity.ImageID);
            txtLink.Text = BicConvert.ToString(searchEntity.Link);
            ddlPosition.SelectedValue = searchEntity.Priority.ToString();
            chkIsActive.Checked = BicConvert.ToBoolean(searchEntity.IsActive);
            txtPhone.Text = searchEntity.DienThoai;
        }
    }
    private SearchEntity LoadDataToEntity()
    {
        var searchEntity = new SearchEntity();
        searchEntity.SearchID = Id;
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
            if (e.CommandName == "Update")
            {
                SearchBiz.UpdateSearch(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.Message);
        }
    }
}