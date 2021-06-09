using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_District_DeletionDistrict : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        if (!DistrictBiz.DeleteDistrict(id))
            BicAjax.Confirm(BicMessage.DeleteFail, BicAdmin.UrlList());
        BicAdmin.NavigateToList();
    }
}