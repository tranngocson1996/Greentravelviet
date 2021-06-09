using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using BIC.Biz;
using BIC.Utils;
using System.Globalization;
/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    public static string TrimText(object input, int leng)
    {
        try
        {

            return BicString.TrimText(input.ToString(), leng);
        }
        catch (Exception)
        {
            return input.ToString();
        }
    }
    public static string GetWebContent(string strLink)
    {
        var strContent = string.Empty;
        try
        {
            var objWebRequest = (HttpWebRequest)WebRequest.Create(strLink);
            objWebRequest.UserAgent = HttpContext.Current.Request.UserAgent;
            objWebRequest.Credentials = CredentialCache.DefaultCredentials;

            var objWebResponse = objWebRequest.GetResponse();
            var receiveStream = objWebResponse.GetResponseStream();
            if (receiveStream != null)
            {
                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                strContent = readStream.ReadToEnd();
                objWebResponse.Close();
                readStream.Close();
            }
        }
        catch (Exception)
        {
        }
        return strContent;
    }
    public static void SetArticleSeoTitle()
    {
        var page = (Page)HttpContext.Current.Handler;
        var menuuserid = BicRouting.GetRequestString("lv", 0);
        var id = BicRouting.GetRequestString("id", 0);
        var olddes = page.MetaDescription;
        var oldkey = page.MetaKeywords;
        var article = ArticleBiz.GetArticleByID(id);
        var title = string.Empty;
        var menu = MenuUserBiz.GetMenuUserByID(menuuserid);
        if (menu != null)
        {
            olddes = string.IsNullOrEmpty(menu.Description) ? olddes : menu.Description;
            oldkey = string.IsNullOrEmpty(menu.SEOTitle) ? oldkey : menu.SEOTitle;
            title = menu.SEOTitle;
        }
        if (article != null)
        {
            olddes = string.IsNullOrEmpty(article.MetaDescription) ? olddes : article.MetaDescription;
            oldkey = string.IsNullOrEmpty(article.MetaKeyWord) ? oldkey : article.MetaKeyWord;
            title += (title == string.Empty ? "" : " - ") + article.SeoTitle;
        }
        page.Title = (title != string.Empty) ? title : page.Title;
        page.MetaDescription = olddes;
        page.MetaKeywords = oldkey;
    }
    public static void SetCategorySeoTitle()
    {
        var page = (Page)HttpContext.Current.Handler;
        var menuuserid = BicRouting.GetRequestString("lv", 0);

        if (menuuserid != 0)
        {
            var menuEntity = MenuUserBiz.GetMenuUserByID(menuuserid);

            if (menuEntity != null)
            {
                var parentName = MenuUserBiz.GetNameById(menuEntity.ParentID);
                var menuName = menuEntity.SEOTitle != string.Empty ? menuEntity.SEOTitle : menuEntity.Name;
                string title = string.Format("{1}{0}", menuName, parentName != string.Empty ? parentName + " - " : string.Empty);
                page.Title = title;
                if (menuEntity.Description != string.Empty)
                    page.MetaDescription = menuName + menuEntity.Description;
                page.MetaKeywords = title + menuEntity.Description;
            }
        }
    }
    public static bool IsNews(object createdDate, int hour)
    {
        try
        {
            var timespan = DateTime.Now - Convert.ToDateTime(createdDate);
            return timespan.TotalHours <= hour;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public static string ToBase64(this string input, Encoding encoding)
    {
        try
        {
            return Convert.ToBase64String(encoding.GetBytes(input));
        }
        catch (Exception)
        {
            return input;
        }
    }
    public static string ToBase64(this string input)
    {
        return input.ToBase64(Encoding.UTF8);
    }
    public static string GetString(this string input, Encoding encoding)
    {
        try
        {
            return encoding.GetString(Convert.FromBase64String(input));
        }
        catch (Exception)
        {
            return input;
        }
    }
    public static string GetString(this string input)
    {
        return input.GetString(Encoding.UTF8);
    }
    public static string PhoneFormat(this object input, string format)
    {
        try
        {
            return Convert.ToDouble(input).ToString(format);
        }
        catch (Exception)
        {
            return input.ToString();
        }
    }
    public static string ChangeFormatDateFromYYYYMMDD(this string input, string format)
    {
        var vals = input.Split(new[] { ',', '.', '-', ' ', '/' });
        return new DateTime(vals[0].ToNaturalNumberic(), vals[1].ToNaturalNumberic(), vals[2].ToNaturalNumberic()).ToString(format);

    }
     public static string ChangeFormatDateFromYYYYMMDD(this object input, string format)
     {
         return BicConvert.ToString(input).ChangeFormatDateFromYYYYMMDD(format);
     }

    public static int ToNaturalNumberic(this string input)
    {
        var res = BicConvert.ToInt32(input);
        return res > 0 ? res : 0;
    }
}