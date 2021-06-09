<%@ WebHandler Language="C#" Class="CheckTT" %>

using System;
using System.Collections;
using System.Web;
using BIC.Biz;

public class CheckTT : IHttpHandler {

    public Hashtable Hashtable
    {
        set { HttpContext.Current.Session.Add("cart", value); }
        get
        {
            var hashtable = (Hashtable)HttpContext.Current.Session["cart"] ?? new Hashtable();
            return hashtable;
        }
    }
    public void ProcessRequest (HttpContext context) {
       
        var id = context.Request.QueryString["pId"];
        context.Response.ContentType = "text/plain";
        if (Hashtable[id] != null)
        { context.Response.Write("Bạn đã thêm sản phẩm này vào giỏ hàng!"); }
        else
        { context.Response.Write("Bạn đã mua sản phẩm này, mời bạn xem giỏ hàng!"); }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}