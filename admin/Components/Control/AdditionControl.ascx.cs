using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Control_AdditionControl : BaseUserControl
{
    private ControlEntity LoadDataToEntity()
    {
        var controlEntity = new ControlEntity {ControlName = BicConvert.ToString(txtControlName.Text), FolderName = BicConvert.ToString(txtFolderName.Text), ControlUrl = BicConvert.ToString(txtControlUrl.Text), LoadUrl = chkLoadUrl.Checked, IsActive = chkIsActive.Checked};
        return controlEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (ControlBiz.InsertControl(LoadDataToEntity()))
                        BicAdmin.NavigateToList();
                    else
                        BicAjax.Alert(BicMessage.InsertFail);
                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}