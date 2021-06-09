using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FrameView_AdditionFrameView : BaseUserControl
{
    private FrameViewEntity LoadDataToEntity()
    {
        var frameviewEntity = new FrameViewEntity { Name = BicConvert.ToString(txtName.Text), URLControl = BicConvert.ToString(txtURLControl.Text), GroupName = BicConvert.ToString(txtGroupName.Text), TypeOfControl = BicConvert.ToString(ddlTypeOfControl.SelectedValue), ResourceKey = BicConvert.ToString(txtResourceKey.Text), IsActive = BicConvert.ToBoolean(chkIsActive.Checked), NewColumn1 = BicConvert.ToString(txtListingPath.Text), NewColumn2 = BicConvert.ToString(txtDetailPath.Text), NewColumn3=string.Empty, IsGroup = false};
        return frameviewEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (FrameViewBiz.InsertFrameView(LoadDataToEntity()))
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