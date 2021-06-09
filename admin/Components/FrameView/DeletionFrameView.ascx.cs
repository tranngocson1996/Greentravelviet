using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_FrameView_DeletionFrameView : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        if (!FrameViewBiz.DeleteFrameView(id))
            BicAjax.Confirm(BicMessage.DeleteFail, BicAdmin.UrlList());
        BicAdmin.NavigateToList();
    }
}