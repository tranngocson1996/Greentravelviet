using System;
using System.Data;
using BIC.Data;
using BIC.Utils;

public partial class admin_Components_Database_ExecuteSQL : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnExecute_Click(object sender, EventArgs e)
    {
        var dh = new DataHelper();
        try
        {
            DataTable dt = dh.ExecuteSQL(txtSQL.Text);
            gvData.DataSource = dt;
            gvData.DataBind();
            BicAjax.Alert("Thực hiện câu lệnh thành công!");
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}