using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;
using BIC.WebControls;
using BIC.Data;
using BIC.Entity;
using System.Data;
using System.Text;

public partial class Controls_Video_VideoHome : BaseUIControl
{
    public string videoUrl = string.Empty;
    public string videoImage = string.Empty;
    public string videoTitle = string.Empty;
    public string TypeOfAdv { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        GetVideoList();
    }

    protected void GetVideoList()
    {
        DataHelper db=new DataHelper();
        var data = db.ExecuteSQL(string.Format("select URL from Adv where TypeOfAdvID='{0}' and LanguageKey='{1}' and IsActive='1'",TypeOfAdv,BicLanguage.CurrentLanguage));
        if (data.Rows.Count > 0)
        {
            videoUrl = data.Rows[0]["URL"].ToString();
        }
    }
}
