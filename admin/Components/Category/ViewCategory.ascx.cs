using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Category_ViewCategory : BaseUserControl
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
		CategoryEntity categoryEntity = CategoryBiz.GetCategoryByID(Id);
        if (categoryEntity != null)
        {
			lblDBName.Text = BicConvert.ToString(categoryEntity.Name);
			lblDBValue.Text = BicConvert.ToString(categoryEntity.Value);
			chkIsActive.Checked = BicConvert.ToBoolean(categoryEntity.IsActive);
	    }
    }
}
