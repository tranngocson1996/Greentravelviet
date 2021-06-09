using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_VideoType_ViewVideoType : BaseUserControl
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
        VideoTypeEntity videotypeEntity = VideoTypeBiz.GetVideoTypeByID(Id);
        if (videotypeEntity != null)
        {
            lblDBName.Text = BicConvert.ToString(videotypeEntity.Name);
            lblDBEmbedCode.Text = BicConvert.ToString(videotypeEntity.EmbedCode);
            chkIsActive.Checked = BicConvert.ToBoolean(videotypeEntity.IsActive);
        }
    }
}