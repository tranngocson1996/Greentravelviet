using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Video_VideoListingHome : BaseUIControl
{
    private int _menuUserId;
    private string _name;
    public string VideoList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _menuUserId = mnCap.MenuUserId = BicLanguage.CurrentLanguage == "vi" ? 21 : 76;
            var menuEtt = MenuUserBiz.GetMenuUserByID(_menuUserId);
            if (menuEtt != null)
            {
                lblCap.Text = menuEtt.Description;
                BindingArticleListView();
            }
        }
    }

    protected void BindingArticleListView()
    {
        articleVideoList.MenuUserId = _menuUserId.ToString();
        articleVideoList.PageSize = 3;
        articleVideoList.LoadData();
    }
    protected string GetVideoList(string menuUserId)
    {
        var sb = new StringBuilder();

        var bicData = new BicGetData
        {
            TableName = "Article",
            PageSize = 12
        };

        string imgPath = string.Empty;
        bicData.TableName = "Article";
        bicData.Sorting.Add(new SortingItem("Priority", false));
        bicData.Selecting.Add(ArticleEntity.FIELD_LINK);
        bicData.Selecting.Add(ArticleEntity.FIELD_IMAGEID);
        bicData.Selecting.Add(ArticleEntity.FIELD_TITLE);
        bicData.Selecting.Add(ArticleEntity.FIELD_BRIEFDESCRIPTION);
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_MENUUSERID, "N'%" + menuUserId + "%'", Operator.LIKE, CompareType.NUMERIC));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_LANGUAGEKEY, BicLanguage.CurrentLanguage, Operator.EQUAL, CompareType.STRING));
        bicData.Conditioning.Add(new ConditioningItem(ArticleEntity.FIELD_TYPEOFCONTROL, "3", Operator.EQUAL, CompareType.STRING));
        DataTable data = bicData.GetAllData();

        if (data.Rows.Count > 0)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                imgPath = BicImage.GetPathImage(BicConvert.ToInt32(data.Rows[i]["ImageID"].ToString()));
                sb.Append("{");
                sb.Append(string.Format("file: \"{0}\",", data.Rows[i]["Link"].ToString()));
                sb.Append(string.Format("image: \"{0}\",", imgPath));
                sb.Append(string.Format("title: \"{0}\"", data.Rows[i]["Title"].ToString()));
                if (i == data.Rows.Count - 1)
                    sb.Append("}");
                else
                    sb.Append("},");
            }
        }
        return sb.ToString();
    }
    public string getYouTubeThumbnail(string YoutubeUrl, string imgID)
    {
        if (imgID != "0")
        {
            return BicImage.GetPathImage(BicConvert.ToInt32(imgID));
        }
        else
        {
            string youTubeThumb = string.Empty;
            if (YoutubeUrl == "")
                return "";

            if (YoutubeUrl.IndexOf("=") > 0)
            {
                youTubeThumb = YoutubeUrl.Split('=')[1];
            }
            else if (YoutubeUrl.IndexOf("/v/") > 0)
            {
                string strVideoCode = YoutubeUrl.Substring(YoutubeUrl.IndexOf("/v/") + 3);
                int ind = strVideoCode.IndexOf("?");
                youTubeThumb = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
            }
            else if (YoutubeUrl.IndexOf('/') < 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[3];
            }
            else if (YoutubeUrl.IndexOf('/') > 6)
            {
                youTubeThumb = YoutubeUrl.Split('/')[1];
            }

            return "http://img.youtube.com/vi/" + youTubeThumb + "/mqdefault.jpg";
        }
    }
}