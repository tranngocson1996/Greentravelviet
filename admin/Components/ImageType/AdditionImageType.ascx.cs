using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_ImageType_AdditionImageType : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }
    private ImageTypeEntity LoadDataToEntity()
    {
        var imagetypeEntity = new ImageTypeEntity {Name = txtName.Text, IsActive = !chkIsActive.Checked};
        if (BicControl.DropExistValue(imagetypeEntity.ParentID, ddlParentID))
            imagetypeEntity.ParentID = BicConvert.ToInt32(ddlParentID.SelectedValue);
        return imagetypeEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        Insert();
    }
    protected void Insert()
    {
        if (ImageTypeBiz.InsertImageType(LoadDataToEntity()))
        {
            ClearInputData();
            tvMain.BindingTreeView();
            ImageTypeBiz.BuildImageTypeTree(ddlParentID);
        }
        else
            BicAjax.Alert(BicMessage.InsertFail);
    }
    private void ClearInputData()
    {
        txtName.Text = string.Empty;
        chkIsActive.Checked = false;
    }
}