using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FrameView_ViewFrameView : BaseUserControl
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
        FrameViewEntity frameviewEntity = FrameViewBiz.GetFrameViewByID(Id);
        if (frameviewEntity != null)
        {
            lblDBName.Text = BicConvert.ToString(frameviewEntity.Name);
            lblDBURLControl.Text = BicConvert.ToString(frameviewEntity.URLControl);
            lblDBGroupName.Text = BicConvert.ToString(frameviewEntity.GroupName);
            lblDBTypeOfControl.Text = BicConvert.ToString(frameviewEntity.TypeOfControl);
            txtResourceKey.Text = BicConvert.ToString(frameviewEntity.ResourceKey);
            chkIsActive.Checked = BicConvert.ToBoolean(frameviewEntity.IsActive);
        }
    }
}