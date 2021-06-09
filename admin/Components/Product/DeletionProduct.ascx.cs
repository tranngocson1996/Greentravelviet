using System;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class admin_Components_Product_DeletionProduct : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = BicHtml.GetRequestString("id", 0);
        //if (!PermissionHelper.ByMenuUsers(_oldMenu))
        //{
        //    BicAjax.Alert(BicMessage.UpdatePermission);
        //    return;
        //}
        ProductEntity product = ProductBiz.GetProductByID(id);
        if (product != null)
            ProductUtils.ClearAritcleCacheByMenuUserIds(product.MenuUserID); //Clear Product Cache
        ProductBiz.DeleteProduct(id);
        BicAdmin.NavigateToList();
    }
}