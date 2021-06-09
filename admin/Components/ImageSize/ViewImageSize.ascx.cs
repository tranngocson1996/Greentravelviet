using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_ImageSize_ViewImageSize : BaseUserControl
{
    public int Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
            LoadDataFromEntity();
    }
    private void LoadDataFromEntity()
    {
        ImageSizeEntity imagesizeEntity = ImageSizeBiz.GetImageSizeByID(Id);
        if (imagesizeEntity != null)
        {
            lblDBName.Text = BicConvert.ToString(imagesizeEntity.Name);
            lblDBImageWidth.Text = BicConvert.ToString(imagesizeEntity.ImageWidth);
            lblDBImageHeight.Text = BicConvert.ToString(imagesizeEntity.ImageHeight);
            chkIsActive.Checked = BicConvert.ToBoolean(imagesizeEntity.IsActive);
        }
    }
}