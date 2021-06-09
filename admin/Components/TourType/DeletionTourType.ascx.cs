using System;
using BIC.Biz;
using BIC.Utils;
using BIC.WebControls;
public partial class Admin_Components_TourType_DeletionTourType : BaseUserControl
{
 	protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        if(!TourTypeBiz.DeleteTourType(id))
          BicAjax.Confirm(BicMessage.DeleteFail, BicAdmin.UrlList());
        BicAdmin.NavigateToList();
	
    }
}

