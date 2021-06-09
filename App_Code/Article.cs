using BIC.Biz;
using BIC.Utils;
using Pecora.Utility;
/// <summary>
/// Summary description for Article
/// </summary>
public class ArticleUtils
{
    public static void ClearAritcleCacheByMenuUserIds(string menuUserIds)
    {
        var menuUserArray = BicString.SplitComma(menuUserIds);

        foreach (var s in menuUserArray)
        {
            if (s == string.Empty) continue;
            BizObject.PurgeCacheItems(s + "_" + s);
            var parentId = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(s)).ParentID.ToString();
            BizObject.PurgeCacheItems(parentId + "_" + parentId);
        }
    }

    public static void RenderArticlesToXml(string menuUserIds)
    {
        var menuUserArray = BicString.SplitComma(menuUserIds);

        foreach (var s in menuUserArray)
        {
            if ("88,89,90,91,92,93,94,95,96,97,98,99,100,101".Contains(s))
                DeleteFile(string.Format("~/Articles/Article_Cate_{0}.xml", s));
            var parentId = MenuUserBiz.GetMenuUserByID(BicConvert.ToInt32(s)).ParentID.ToString();
            if ("88,89,90,91,92,93,94,95,96,97,98,99,100,101".Contains(parentId))
                DeleteFile(string.Format("~/Articles/Article_Cate_{0}.xml", parentId));
        }
                
    }

    private static bool DeleteFile(string path)
    {
        try
        {
            System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(path));
            return true;
        }
        catch (System.Exception ex)
        {
            ex.LogMessage();
            return false;
        }
    }
}