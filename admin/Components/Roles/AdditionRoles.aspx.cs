using System;
using System.Web.Security;
using System.Web.UI;
using BIC.Utils;

public partial class admin_Components_Roles_AdditionRoles : Page
{
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtRole.Text))
        {
            if (Roles.RoleExists(txtRole.Text))
                BicAjax.Alert("Nhóm tài khoản này đã tồn tại, bạn vui lòng nhập tên khác");
            else
            {
                Roles.CreateRole(txtRole.Text.Trim());
                BicAjax.Alert("Thêm mới nhóm tài khoản thành công!");
                txtRole.Text = string.Empty;
                txtRole.Focus();
            }
        }
    }
}