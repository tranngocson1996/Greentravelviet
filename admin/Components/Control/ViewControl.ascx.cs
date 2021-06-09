using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Control_ViewControl : BaseUserControl
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
        ControlEntity controlEntity = ControlBiz.GetControlByID(Id);
        if (controlEntity != null)
        {
            lblDBControlName.Text = BicConvert.ToString(controlEntity.ControlName);
            lblDBFolderName.Text = BicConvert.ToString(controlEntity.FolderName);
            lblDBControlUrl.Text = BicConvert.ToString(controlEntity.ControlUrl);
            chkLoadUrl.Checked = BicConvert.ToBoolean(controlEntity.LoadUrl);
            chkIsActive.Checked = BicConvert.ToBoolean(controlEntity.IsActive);
        }
    }
}