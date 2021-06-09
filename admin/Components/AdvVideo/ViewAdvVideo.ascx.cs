using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_AdvVideo_ViewAdvVideo : BaseUserControl
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
        AdvVideoEntity advvideoEntity = AdvVideoBiz.GetAdvVideoByID(Id);
        if (advvideoEntity != null)
        {
            lblDBName.Text = BicConvert.ToString(advvideoEntity.Name);
            lblDBLanguageKey.Text = BicConvert.ToString(advvideoEntity.LanguageKey);
            lblDBURL.Text = BicConvert.ToString(advvideoEntity.Url);
            lblDBTarget.Text = BicConvert.ToString(advvideoEntity.Target);
            lblDBThoiGianBatDau.Text = BicConvert.ToString(advvideoEntity.ThoiGianBatDau);
            lblDBKhoangThoiGian.Text = BicConvert.ToString(advvideoEntity.KhoangThoiGian);
            lblDBTypeOfAdvID.Text = BicConvert.ToString(advvideoEntity.TypeOfAdvID);
            lblDBMenuUserID.Text = BicConvert.ToString(advvideoEntity.MenuUserID);
            lblDBTextDisplay.Text = BicConvert.ToString(advvideoEntity.TextDisplay);
            lblDBDescription.Text = BicConvert.ToString(advvideoEntity.Description);
            lblDBViewCount.Text = BicConvert.ToString(advvideoEntity.ViewCount);
            chkIsActive.Checked = BicConvert.ToBoolean(advvideoEntity.IsActive);
        }
    }
}