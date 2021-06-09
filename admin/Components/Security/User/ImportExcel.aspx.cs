using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using BIC.Utils;
using BIC.Utils.BicExcel;

public partial class admin_Components_Security_User_ImportExcel : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ImportExcel()
    {
        string inValidByUser = string.Empty;
        string inValidByEmail = string.Empty;
        ;
        //IIS7 64bit: ApplicationPool>ASP.Net 4.0>Advance Setting > Enable 32-bit Application
        if (!fuExcel.HasFile)
        {
            return;
        }
        try
        {
            string filename = BicEncoding.ConvertUnicodeToNoSign(fuExcel.PostedFile.FileName).Replace(" ", "_");
            ;
            string filepath = Server.MapPath("~/FileUpload/Temp/" + filename);
            fuExcel.PostedFile.SaveAs(filepath);
            DataTable dt = Import.Query(filepath);
            foreach (DataRow dr in dt.Rows)
            {
                string username = dr["UserName"].ToString();
                string email = dr["Email"].ToString();
                string password = dr["Password"].ToString();
                if (Membership.GetUser(username) != null)
                {
                    inValidByUser += username + ",";
                    continue;
                }
                if (Membership.GetUserNameByEmail(email) != null)
                {
                    inValidByEmail += username + ",";
                    continue;
                }
                Membership.CreateUser(username, password, email);
                //Cap nhat profile
                ProfileCommon profile = Profile.GetProfile(username);
                profile.FullName = dr["FullName"].ToString();
                profile.Address = dr["Address"].ToString();
                profile.Phone = dr["Phone"].ToString();
                profile.Save();
            }
        }
        catch (Exception)
        {
            BicAjax.Alert("File không hợp lệ");
        }
        if (inValidByUser != string.Empty || inValidByEmail != string.Empty)
            //ko hien dc alert
            BicAjax.Alert("Dữ liệu đã được import.\nTài khoản đã có người sử dụng: " + inValidByUser + "\nEmail của tài khoản đã có người sử dụng: " + inValidByEmail);
        else
        {
            BicAjax.Alert("Dữ liệu đã được import");
        }
        BicAjax.Alert("OK");
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        ImportExcel();
    }
}