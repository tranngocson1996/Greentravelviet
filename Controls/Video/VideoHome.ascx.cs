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
    public string videoList;
    public string MenuUserId { get; set; }

    public string FirstTitle { get; set; }
    public string FirstDesc{ get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuUserId = BicLanguage.CurrentLanguage == "vi" ? "40" : "48";
        if (!IsPostBack)
           GetVideoList();
    }

    protected void GetVideoList()
    {
        var listAttackVideos=new List<AttackVideo>();
        var sb = new StringBuilder();
       
        var bicData = new BicGetData
        {
            TableName = "Article",
            PageSize = 4
        };

        string imgPath = string.Empty;
        bicData.TableName = "Article";
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(ArticleEntity.FIELD_LINK);
        bicData.Selecting.Add(ArticleEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(ArticleEntity.FIELD_TITLE);
        bicData.Selecting.Add(ArticleEntity.FIELD_BRIEFDESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_MENUUSERID, "N'%" + MenuUserId + "%'", Operator.LIKE, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_LANGUAGEKEY, BicLanguage.CurrentLanguage, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_TYPEOFCONTROL, "3", Operator.EQUAL, CompareType.STRING));
        DataTable data = bicData.GetAllData();

        if(data.Rows.Count > 0)
        {
            //videoUrl = data.Rows[0]["Url"].ToString();
            //videoTitle = data.Rows[0]["Name"].ToString();
            //videoImage = BicImage.GetPathImage(BicConvert.ToInt32(data.Rows[0]["ImageID"].ToString()));
            //nhay = nhaykep.ToString();
            for(int i = 0; i < data.Rows.Count; i++)
            {
                imgPath = BicImage.GetPathImage(BicConvert.ToInt32(data.Rows[i]["ImageID"].ToString()));
                sb.Append("{");
                sb.Append(string.Format("file: '{0}',",data.Rows[i]["Link"].ToString()));
                sb.Append(string.Format("image: '{0}',", imgPath));
                sb.Append(string.Format("title: '{0}'", data.Rows[i]["Title"].ToString()));
                if(i == data.Rows.Count - 1)
                    sb.Append("}");
                else
                    sb.Append("},");
                //Them vao list AttackVideo
                listAttackVideos.Add(new AttackVideo()
                {
                    File = data.Rows[i]["Link"].ToString(),
                    Image = imgPath,
                    Title = data.Rows[i]["Title"].ToString(),
                    BriefDescription = data.Rows[i]["BriefDescription"].ToString()
                });
            }
            FirstTitle = data.Rows[0]["Title"].ToString();
            FirstDesc = data.Rows[0]["BriefDescription"].ToString();
        }
        videoList= sb.ToString();
        lvVideoHome.DataSource = listAttackVideos;
        lvVideoHome.DataBind();
    }
}

public class AttackVideo
{
    public string File { get; set; }
    public string Image { get; set; }
    public string Title { get; set; }
    public string BriefDescription { get; set; }
}