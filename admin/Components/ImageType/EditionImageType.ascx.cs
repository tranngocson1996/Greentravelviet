using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_ImageType_EditionImageType : BaseUserControl
{
    private int _id;
    protected void Page_Load(object sender, EventArgs e)
    {
        _id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            GetMenu();
        }
    }
    protected void GetMenu()
    {
        if (_id != 0)
        {
            ddlParentID.Enabled = false;
            ImageTypeBiz.BuildImageTypeTree(ddlParentID);
            LoadDataFromEntity();
        }
    }
    private ImageTypeEntity LoadDataToEntity()
    {
        var imagetypeEntity = new ImageTypeEntity {ImageTypeID = BicConvert.ToInt32(_id), Name = txtName.Text, IsActive = !chkIsActive.Checked};
        if (BicControl.DropExistValue(imagetypeEntity.ParentID, ddlParentID))
            imagetypeEntity.ParentID = BicConvert.ToInt32(ddlParentID.SelectedValue);
        return imagetypeEntity;
    }
    private void LoadDataFromEntity()
    {
        ImageTypeEntity imagetypeEntity = ImageTypeBiz.GetImageTypeByID(_id);
        if (imagetypeEntity == null) return;
        txtName.Text = imagetypeEntity.Name;
        chkIsActive.Checked = !imagetypeEntity.IsActive;
        txtName.Text = imagetypeEntity.Name;
        if (BicControl.DropExistValue(imagetypeEntity.ParentID, ddlParentID))
            ddlParentID.SelectedValue = imagetypeEntity.ParentID.ToString();
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        Update();
    }
    protected void Update()
    {
        if (ImageTypeBiz.UpdateImageType(LoadDataToEntity()))
        {
            BicAdmin.NavigateToList();
        }
        else
            BicAjax.Alert(BicMessage.UpdateFail);
    }
}