using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.Data;
using BIC.WebControls;
using BIC.Handler;

public partial class Admin_Components_Category_AdditionCategory : BaseUserControl
{
	protected void Page_Load(object sender, EventArgs e)
    {      
        if (!IsPostBack)
        {
            PositionWithPriorityAdd();
            TypeOfAdvBuilder();
        }
    }
    public void PositionWithPriorityAdd()
    {
        try
        {
            var dh = new DataHelper();
            int maxPosition = BicConvert.ToInt32(dh.CountItem("CategoryId", "Category"));
            if (maxPosition < 1)
                maxPosition = 1;
            ntxPosition.MaxValue = maxPosition;
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
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
    private CategoryEntity LoadDataToEntity()
    {
     	var categoryEntity = new CategoryEntity();
     	categoryEntity.Name = BicConvert.ToString(txtName.Text);
     	categoryEntity.Value = BicConvert.ToString(txtValue.Text);
     	categoryEntity.IsActive = chkIsActive.Checked;
        categoryEntity.Note = BicConvert.ToString(txtNote.Text);
        categoryEntity.TypeOfCategory = Convert.ToInt32(ddlTypeOfCategory.SelectedValue);
		return categoryEntity;
    }

    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    CategoryBiz.InsertCategory(LoadDataToEntity());
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
