<%@ WebHandler Language="C#" Class="MenuUser" %>

using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using BIC.Biz;
using BIC.DAO;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using System.Text;
using System.Web.Script.Serialization;

public class MenuUser : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        DataTable dt = MenuUserBiz.GetMenuUserByTypeOfControl(BicConvert.ToInt32(context.Request.QueryString["nodeId"]) , context.Request.QueryString["typeOfControl"]);
        StringBuilder sb = new StringBuilder();
        JavaScriptSerializer js = new JavaScriptSerializer();
        var results = new List<object>();
        foreach(DataRow row in dt.Rows)
        {
            var item = new Dictionary<string , string>();
            foreach(DataColumn column in dt.Columns)
            {
                item.Add(column.ColumnName , row[column].ToString());
            }
            results.Add(item);
        }
        js.Serialize(results , sb);
        context.Response.Write(sb.ToString());
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}