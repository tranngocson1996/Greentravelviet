<%@ WebHandler Language="C#" Class="QuickSearch" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public class QuickSearch : IHttpHandler
{
    private List<SearchEntity> _lstSearch;
    private ImageEntity imge;

    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        string keyword = context.Request.QueryString["q"];
        string lang = context.Request.QueryString["lang"];
        _lstSearch = SearchBiz.SearchByKeyword(keyword, 6, lang);
        string img;
        if (_lstSearch.Count > 0)
        {
            string anchor = "<a href='{0}'>{1}</a>";
            string image = "<img src='{1}' width='48' alt='' />";
            string span = "<span class='title'>{2}</span><span class='desc'>{3}</span>{4}";
            string div = "<div class='thumb'>{0}</div><div class='content'>{1}</div><div class='clearboth'></div>";
            string build = string.Format(div, string.Format(anchor, "{0}", image), string.Format(anchor, "{0}", span));


            foreach (SearchEntity item in _lstSearch)
            {

                var imageentity = ImageBiz.GetImageByID(item.ImageID);
                if (imageentity != null)

                    img = BicApplication.URLRoot + imageentity.Path + imageentity.Name;

                else
                    img = BicApplication.URLRoot + "Styles/img/img_unavaiable.jpg";
                context.Response.Write(string.Format(build, item.Link, img, item.Keyword, item.Description, string.IsNullOrEmpty(item.DienThoai) ? string.Empty : string.Format("<span class='phone'>{0}</span>",item.DienThoai)) +
                                       Environment.NewLine);
            }
        }
        else
        {
            context.Response.Write(Environment.NewLine);
        }
       
    }

    public bool IsReusable
    {
        get { return false; }
    }

    #endregion
}