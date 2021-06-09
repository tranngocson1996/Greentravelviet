using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;
using System.Web.UI.WebControls;
using BIC.Handler;

public partial class Admin_Components_Category_EditionCategory : BaseUserControl
{
	protected int Id;
	protected void Page_Load(object sender, EventArgs e)
    {      
        Id = BicHtml.GetRequestString("id", 0);
		if (!IsPostBack)
        {
            chkIsActive.Enabled = Approved;
            TypeOfAdvBuilder();
			LoadDataFromEntity();
            
        }
    }
    protected void TypeOfAdvBuilder()
    {
        BicXML.BindDropDownListFromXML(ddlTypeOfCategory, string.Format("{0}admin/XMLData/TypeOfCategory_{1}.xml", BicApplication.URLRoot, ddlLanguage.SelectedValue));
        ddlTypeOfCategory.Items.Insert(0, new ListItem(string.Format(BicResource.GetValue("Admin", "Admin_Category_DropDownList")), "0"));
    }
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        TypeOfAdvBuilder();
    }
    private void LoadDataFromEntity()
    {
		CategoryEntity categoryEntity = CategoryBiz.GetCategoryByID(Id);
        if (categoryEntity != null)
        {
            if (categoryEntity.TypeOfCategory != 3)
            { divNote.Visible = false; }
            else { divNote.Visible = true; }
     	    txtName.Text = BicConvert.ToString(categoryEntity.Name);
     	    txtValue.Text = BicConvert.ToString(categoryEntity.Value);
            ntxPosition.Text = BicConvert.ToString(categoryEntity.Priority);
            txtNote.Text = BicConvert.ToString(categoryEntity.Note);
            if(!string.IsNullOrEmpty(BicConvert.ToString(categoryEntity.TypeOfCategory)))
            ddlTypeOfCategory.SelectedValue = BicConvert.ToString(categoryEntity.TypeOfCategory);
     	    chkIsActive.Checked = BicConvert.ToBoolean(categoryEntity.IsActive);
        }
    }
	
    private CategoryEntity LoadDataToEntity()
    {
     	CategoryEntity categoryEntity = new CategoryEntity();
		categoryEntity.CategoryID = Id;
		
     	categoryEntity.Name = BicConvert.ToString(txtName.Text);
     	categoryEntity.Value = BicConvert.ToString(txtValue.Text);
        categoryEntity.Priority = BicConvert.ToInt32(ntxPosition.Text);
        categoryEntity.Note = BicConvert.ToString(txtNote.Text);
        categoryEntity.TypeOfCategory = BicConvert.ToInt32(ddlTypeOfCategory.SelectedValue);
     	categoryEntity.IsActive = chkIsActive.Checked;
		return categoryEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                CategoryBiz.UpdateCategory(LoadDataToEntity());
                BicAdmin.NavigateToList();
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.Message);
        }
    }
}
