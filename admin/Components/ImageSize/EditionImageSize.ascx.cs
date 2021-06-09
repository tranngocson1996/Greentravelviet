using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_ImageSize_EditionImageSize : BaseUserControl
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
        ImageSizeEntity imagesizeEntity = ImageSizeBiz.GetImageSizeByID(Id);
        if (imagesizeEntity != null)
        {
            txtName.Text = BicConvert.ToString(imagesizeEntity.Name);
            txtImageWidth.Text = BicConvert.ToString(imagesizeEntity.ImageWidth);
            txtImageHeight.Text = BicConvert.ToString(imagesizeEntity.ImageHeight);
            chkIsActive.Checked = BicConvert.ToBoolean(imagesizeEntity.IsActive);
        }
    }
    private ImageSizeEntity LoadDataToEntity()
    {
        var imagesizeEntity = new ImageSizeEntity();
        imagesizeEntity.ImageSizeID = Id;
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
            if (e.CommandName == "Update")
            {
                if (ImageSizeBiz.UpdateImageSize(LoadDataToEntity()))
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