using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Control_EditionControl : BaseUserControl
{
    protected int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
        ControlEntity controlEntity = ControlBiz.GetControlByID(Id);
        if (controlEntity != null)
        {
            txtControlName.Text = BicConvert.ToString(controlEntity.ControlName);
            txtFolderName.Text = BicConvert.ToString(controlEntity.FolderName);
            txtControlUrl.Text = BicConvert.ToString(controlEntity.ControlUrl);
            chkLoadUrl.Checked = BicConvert.ToBoolean(controlEntity.LoadUrl);
            chkIsActive.Checked = BicConvert.ToBoolean(controlEntity.IsActive);
        }
    }
    private ControlEntity LoadDataToEntity()
    {
        var controlEntity = new ControlEntity {ControlID = Id, ControlName = BicConvert.ToString(txtControlName.Text), FolderName = BicConvert.ToString(txtFolderName.Text), ControlUrl = BicConvert.ToString(txtControlUrl.Text), LoadUrl = chkLoadUrl.Checked, IsActive = chkIsActive.Checked};
        return controlEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (ControlBiz.UpdateControl(LoadDataToEntity()))
                    BicAdmin.NavigateToList();
                else
                    BicAjax.Alert(BicMessage.UpdateFail);
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}