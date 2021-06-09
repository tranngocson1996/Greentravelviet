using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_VideoType_AdditionVideoType : BaseUserControl
{
    private VideoTypeEntity LoadDataToEntity()
    {
        var videotypeEntity = new VideoTypeEntity {Name = BicConvert.ToString(txtName.Text), EmbedCode = BicConvert.ToString(reEmbedCode.Html), IsActive = chkIsActive.Checked};
        return videotypeEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    if (VideoTypeBiz.InsertVideoType(LoadDataToEntity()))
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