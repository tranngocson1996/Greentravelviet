using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FrameView_EditionFrameView : BaseUserControl
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
        FrameViewEntity frameviewEntity = FrameViewBiz.GetFrameViewByID(Id);
        if (frameviewEntity != null)
        {
            txtName.Text = BicConvert.ToString(frameviewEntity.Name);
            txtURLControl.Text = BicConvert.ToString(frameviewEntity.URLControl);
            txtGroupName.Text = BicConvert.ToString(frameviewEntity.GroupName);
            ddlTypeOfControl.SelectedValue = BicConvert.ToString(frameviewEntity.TypeOfControl);
            txtResourceKey.Text = BicConvert.ToString(frameviewEntity.ResourceKey);
            chkIsActive.Checked = BicConvert.ToBoolean(frameviewEntity.IsActive);
            txtListingPath.Text = BicConvert.ToString(frameviewEntity.NewColumn1);
            txtDetailPath.Text = BicConvert.ToString(frameviewEntity.NewColumn2);
        }
    }
    private FrameViewEntity LoadDataToEntity()
    {
        var frameviewEntity = new FrameViewEntity();
        frameviewEntity.FrameViewID = Id;
        frameviewEntity.Name = BicConvert.ToString(txtName.Text);
        frameviewEntity.URLControl = BicConvert.ToString(txtURLControl.Text);
        frameviewEntity.GroupName = BicConvert.ToString(txtGroupName.Text);
        frameviewEntity.TypeOfControl = BicConvert.ToString(ddlTypeOfControl.SelectedValue);
        frameviewEntity.ResourceKey = BicConvert.ToString(txtResourceKey.Text);
        frameviewEntity.IsActive = BicConvert.ToBoolean(chkIsActive.Checked);
        frameviewEntity.IsGroup = false;
        frameviewEntity.NewColumn1 = BicConvert.ToString(txtListingPath.Text);
        frameviewEntity.NewColumn2 = BicConvert.ToString(txtDetailPath.Text);
        frameviewEntity.NewColumn3 = string.Empty;
        return frameviewEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (FrameViewBiz.UpdateFrameView(LoadDataToEntity()))
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