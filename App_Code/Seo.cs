using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Seo
/// </summary>
public class Seo : DataAccess
{
    public SeoEntity GetSeoInfo(string defaultImageLink)
    {
        //Lay ve ten menu va ten bai chi tiet
        string menuName = BicRouting.GetRequestString("menu_name");
        string name = BicRouting.GetRequestString("name");
        var currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        string ogType = "product";
        var typeOfItem = string.Empty;
        if (!currentUrl.Contains("html"))
            currentUrl = BicXML.ToString("FacebookSiteName", "SearchEngine");//currentUrl.Replace("/default.aspx", "");
        //Neu la dang menu 
        if (string.IsNullOrEmpty(name))
        {
            if (!string.IsNullOrEmpty(menuName))
                typeOfItem = "menu";
        }
        else //La bai viet hoac san pham
        {
            //Kiem tra xem la san pham hay tin tuc
            var db = new DataHelper();
            string query =
                    string.Format(
                        "select TypeOfControl from Frameview where FrameViewID = (select Top 1 FrameViewID from MenuUser where UrlName='{0}')",
                        menuName);
            //Ghi vao bo nho cache
            var key = string.Format("FrameView_FrameView_{0}", query);
            var data = new DataTable();
            if (HttpContext.Current.Cache[key] != null)
            {
                data = (DataTable)HttpContext.Current.Cache[key];
                if (data.Rows.Count == 0)
                {
                    data = db.ExecuteSQL(query);
                    HttpContext.Current.Cache[key] = data;
                }
            }
            else
            {
                data = db.ExecuteSQL(query);
                HttpContext.Current.Cache[key] = data;
            }
            if (data.Rows.Count > 0)
            {
                string typeOfControl = data.Rows[0]["TypeOfControl"].ToString().Trim();
                if (typeOfControl.Equals("news") || typeOfControl.Equals("video") || typeOfControl.Equals("gallery"))
                {
                    typeOfItem = "article";
                    ogType = "article";
                }
                else
                {
                    if (typeOfControl.Equals("products"))
                    {
                        typeOfItem = "product";
                        ogType = "product";
                    }
                    else if (typeOfControl.Equals("room"))
                    {
                        typeOfItem = "room";
                        ogType = "article";                        
                    }
                }
            }
        }

        var seoEntity = new SeoEntity();
        using (var cn = new SqlConnection(BicWebConfig.ConnectionString))
        {
            var cmd = new SqlCommand("GetSeoInfo", cn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@TypeOfItem", SqlDbType.NVarChar).Value = typeOfItem;
            cmd.Parameters.Add("@MenuUserName", SqlDbType.NVarChar).Value = menuName;
            cmd.Parameters.Add("@ItemName", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@DefaultImageLink", SqlDbType.NVarChar).Value = defaultImageLink;
            cn.Open();
            IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
            if (reader.Read())
            {
                seoEntity = GetSeoFromReader(reader);
                if(typeOfItem == "room")
                {
                    seoEntity.ImageLink = BicImage.GetPathImage(BicConvert.ToInt32(seoEntity.ImageLink)).Remove(0,1);
                }
            }
            cn.Close();
        }

        if (seoEntity.MetaTitle == string.Empty)
        {
            seoEntity.MetaTitle = BicXML.ToString("Title", "SearchEngine");
        }

        if (seoEntity.MetaDescription == string.Empty)
        {
            seoEntity.MetaDescription = BicPage.Page.Server.HtmlDecode(BicXML.ToString("Description", "SearchEngine"));
        }

        if (seoEntity.MetaKeyword == string.Empty)
        {
            seoEntity.MetaKeyword = BicPage.Page.Server.HtmlDecode(BicXML.ToString("Keywords", "SearchEngine"));
        }
        seoEntity.Url = currentUrl;
        seoEntity.Type = ogType;

        return seoEntity;
    }


    private SeoEntity GetSeoFromReader(IDataReader reader)
    {
        return new SeoEntity(reader["MetaDescription"].ToString().Trim(), reader["MetaKeyword"].ToString().Trim(), reader["MetaTitle"].ToString().Trim(), reader["ImageLink"].ToString().Trim());
    }

}

public class SeoEntity
{
    #region Contructors

    public SeoEntity()
    {
    }

    public SeoEntity(string metaDescription, string metaKeyword, string metaTitle, string imageLink)
    {
        MetaDescription = Regex.Replace(metaDescription, @"<[^>]*>", String.Empty); //xóa tất cả các định dạng html khi đọc mô tả bài tin
        MetaKeyword = metaKeyword;
        MetaTitle = metaTitle;
        ImageLink = imageLink;
    }

    #endregion


    #region MetaDescription

    private string _metaDescription = String.Empty;

    /// <summary>
    /// Gets or sets MetaDescription
    /// </summary>
    public string MetaDescription
    {
        get { return _metaDescription; }
        set { _metaDescription = value; }
    }

    #endregion

    #region MetaKeyword

    private string _metaKeyword = String.Empty;

    /// <summary>
    /// Gets or sets MetaKeyword
    /// </summary>
    public string MetaKeyword
    {
        get { return _metaKeyword; }
        set { _metaKeyword = value; }
    }

    #endregion

    #region MetaTitle

    private string _metaTitle = String.Empty;

    /// <summary>
    /// Gets or sets MetaTitle
    /// </summary>
    public string MetaTitle
    {
        get { return _metaTitle; }
        set { _metaTitle = value; }
    }

    #endregion

    #region ImageLink

    private string _imageLink = String.Empty;

    /// <summary>
    /// Gets or sets ImageLink
    /// </summary>
    public string ImageLink
    {
        get { return _imageLink; }
        set { _imageLink = value; }
    }

    #endregion

    #region Url

    private string _url = String.Empty;

    /// <summary>
    /// Gets or sets ImageLink
    /// </summary>
    public string Url
    {
        get { return _url; }
        set { _url = value; }
    }

    #endregion

    #region Type

    private string _type = String.Empty;

    /// <summary>
    /// Gets or sets ImageLink
    /// </summary>
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }

    #endregion
}