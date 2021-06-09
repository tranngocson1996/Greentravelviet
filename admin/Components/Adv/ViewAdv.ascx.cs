using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Adv_ViewAdv : BaseUserControl
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
        AdvEntity advEntity = AdvBiz.GetAdvByID(Id);
        if (advEntity != null)
        {
            lblDBName.Text = BicConvert.ToString(advEntity.Name);
            lblDBTypeOfAdvID.Text = BicConvert.ToString(advEntity.TypeOfAdvID);
            lblDBURL.Text = BicConvert.ToString(advEntity.Url);
            lblDBTarget.Text = BicConvert.ToString(advEntity.Target);
            lblDBViewCount.Text = BicConvert.ToString(advEntity.ViewCount);
            lblDBExpireDate.Text = BicConvert.ToString(advEntity.ExpireDate);
            lblDBDescription.Text = BicConvert.ToString(advEntity.Description);
            chkIsActive.Checked = BicConvert.ToBoolean(advEntity.IsActive);
        }
    }
}