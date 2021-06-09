using System;
using System.Configuration;
using System.Data;
using System.IO;
using BIC.Data;
using BIC.Utils;
using BIC.WebControls;
using Telerik.Web.UI;

public partial class Admin_Components_Database_Backup : BaseUserControl
{
    protected string UrlDocument = BicApplication.URLPath("App_Data");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetFile();
            radMenuContext.LoadContentFile("~/admin/XMLData/Grid/MenuContextDatabase.xml");
            radMenuContext.Items[1].Attributes.Add("onclick",
                                                   string.Format(
                                                       "var as;as=confirm('{0}?');document.getElementById('confirmdelete').value = as;",
                                                       BicMessage.Delete));
        }
    }

    protected void BackupDatabase()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ToString();
        string[] arr = connectionString.Split(new[] { ';' });
        string databaseName = string.Empty;
        foreach (string s in arr)
        {
            if (s.ToLower().Trim().Contains("database"))
                databaseName = s.Replace("Database=", "").Trim();
        }

        if (!IsRefresh)
        {
            try
            {
                string sBackupName = string.Format("{0}_{1}", "Backup", DateTime.Now.ToString("ddMMyy_HHmmss.bak"));
                var dh = new DataHelper();
                dh.ExecuteSQL(String.Format(@"BACKUP DATABASE {1} TO DISK = N'{0}'",
                                            Server.MapPath(BicApplication.URLPath("App_Data\\") + sBackupName),
                                            databaseName));
                BicAjax.Alert("Tạo bản sao lưu thành công! - Tên bản sao lưu là: " + sBackupName);
                rgManager.Rebind();
            }
            catch (Exception ex)
            {
                BicAjax.Alert(ex.Message);
            }
        }
    }

    private void GetFile()
    {
        var dtFile = new DataTable();
        dtFile.Columns.Add(new DataColumn("FileName"));
        dtFile.Columns.Add(new DataColumn("FileSize"));
        string[] sFiles = Directory.GetFiles(base.Server.MapPath(UrlDocument), "*.bak");
        foreach (string t in sFiles)
        {
            var file = new FileInfo(t);
            dtFile.Rows.Add(Path.GetFileName(t), Math.Round(file.Length / 1024.0 / 1024.0, 2));
        }
        rgManager.VirtualItemCount = dtFile.Rows.Count;
        rgManager.DataSource = dtFile;
    }

    protected void rgManager_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        GetFile();
    }

    protected void radMenuContext_ItemClick(object sender, RadMenuEventArgs e)
    {
        int index = Convert.ToInt32(Request.Form["radGridClickedRowIndex"]);
        string filename = rgManager.Items[index].GetDataKeyValue("FileName").ToString();
        switch (e.Item.Value)
        {
            case "Delete":
                bool confirm = Convert.ToBoolean(Request.Form["confirmdelete"]);
                if (confirm)
                {
                    DeleteFile(filename);
                    rgManager.Rebind();
                }
                break;
            case "Download":
                DownloadFile(filename);
                break;
        }
    }

    protected void rgManager_ItemCommand(object source, GridCommandEventArgs e)
    {
        //string filename = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FileName"].ToString();
        //switch (e.CommandName)
        //{
        //    case "Delete":
        //        DeleteFile(filename);
        //        rgManager.Rebind();
        //        break;
        //    case "Download":
        //        DownloadFile(filename);
        //        break;
        //}
    }

    protected void rgManager_DeleteCommand(object source, GridCommandEventArgs e)
    {
        string filename = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["FileName"].ToString();
        DeleteFile(filename);
        rgManager.DataBind();
    }

    protected void DeleteFile(string filename)
    {
        try
        {
            BicFile.Delete(BicApplication.URLPath("App_Data//") + filename);
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }

    protected void DownloadFile(string filename)
    {
        Response.Clear();
        Response.AddHeader("Content-Disposition",
                           "attachment; filename=" + BicEncoding.ConvertUnicodeToNoSign(filename));
        Response.ContentType = "application/octet-stream";
        try
        {
            Response.WriteFile(BicApplication.URLPath("App_Data") + filename);
        }
        catch
        {
            BicAjax.Alert("File không tồn tại");
        }
        Response.End();
    }

    protected void lbtnBackup_Click(object sender, EventArgs e)
    {
        BackupDatabase();
    }
}