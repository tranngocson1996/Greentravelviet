using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_ImageSize_AdditionImageSize : BaseUserControl
{
    private ImageSizeEntity LoadDataToEntity()
    {
        var imagesizeEntity = new ImageSizeEntity();
        imagesizeEntity.Name = BicConvert.ToString(txtName.Text);
        imagesizeEntity.ImageWidth = BicConvert.ToInt32(txtImageWidth.Text);
        imagesizeEntity.ImageHeight = BicConvert.ToInt32(txtImageHeight.Text);
        imagesizeEntity.IsActive = chkIsActive.Checked;
        return imagesizeEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (ImageSizeBiz.InsertImageSize(LoadDataToEntity()))
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