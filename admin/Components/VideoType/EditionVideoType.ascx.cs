using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_VideoType_EditionVideoType : BaseUserControl
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
        VideoTypeEntity videotypeEntity = VideoTypeBiz.GetVideoTypeByID(Id);
        if (videotypeEntity != null)
        {
            txtName.Text = BicConvert.ToString(videotypeEntity.Name);
            reEmbedCode.Html = BicConvert.ToString(videotypeEntity.EmbedCode);
            chkIsActive.Checked = BicConvert.ToBoolean(videotypeEntity.IsActive);
        }
    }
    private VideoTypeEntity LoadDataToEntity()
    {
        var videotypeEntity = new VideoTypeEntity();
        videotypeEntity.VideoTypeID = Id;
        videotypeEntity.Name = BicConvert.ToString(txtName.Text);
        videotypeEntity.EmbedCode = BicConvert.ToString(reEmbedCode.Html);
        videotypeEntity.IsActive = chkIsActive.Checked;
        return videotypeEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Update")
            {
                if (VideoTypeBiz.UpdateVideoType(LoadDataToEntity()))
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