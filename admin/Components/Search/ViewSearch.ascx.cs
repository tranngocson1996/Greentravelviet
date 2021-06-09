using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Search_ViewSearch : BaseUserControl
{
    public int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
            LoadDataFromEntity();
    }
    private void LoadDataFromEntity()
    {
        SearchEntity searchEntity = SearchBiz.GetSearchByID(Id);
        if (searchEntity != null)
        {
            lblDBDescription.Text = BicConvert.ToString(searchEntity.Description);
            lblDBKeyword.Text = BicConvert.ToString(searchEntity.Keyword);
            BicImage.ViewImage(isImageID, searchEntity.ImageID, 120, 90, true);
            lblDBLink.Text = BicConvert.ToString(searchEntity.Link);
            chkIsActive.Checked = BicConvert.ToBoolean(searchEntity.IsActive);
        }
    }
}