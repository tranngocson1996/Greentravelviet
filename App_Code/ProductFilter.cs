using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using System;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for ProductFillter
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ProductFilter : WebService
{
    private int TotalRecord;
    public ProductFilter()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetProductSearch(string lang, string menuID, string attID, string PageIndex, string PageSize)
    {
        string kq = string.Empty;
        string html = string.Empty;
        int pageIndex = BicConvert.ToInt32(PageIndex);
        int pageSize = BicConvert.ToInt32(PageSize);
        html = GetProductFilter(lang, menuID, attID, pageIndex, pageSize);
        Filter fr = new Filter();
        fr.count = TotalRecord;
        fr.result = html;
        kq = new JavaScriptSerializer().Serialize(fr);
        return kq;
    }
    protected string GetProductFilter(string language, string MenuUserId, string AttributeId, int PageIndex, int PageSize)
    {
        try
        {
            var bicData = new BicGetData { TableName = "Product" };
            var con = new ConditioningItem
            {
                TypeOfCondition = TypeOfCondition.QUERY,
            };
            con.Query = string.Format("MenuUserID like '%,{0},%'", MenuUserId);
            if (AttributeId != "0")
                con.Query += string.Format(" AND MenuUserID like '%,{0},%'", AttributeId);
            bicData.PageIndex = PageIndex;
            bicData.PageSize = PageSize;
            bicData.Sorting.Add(new SortingItem("Priority", false));
            bicData.Selecting.Add(ProductEntity.FIELD_PRODUCTID);
            bicData.Selecting.Add(ProductEntity.FIELD_TITLE);
            bicData.Selecting.Add(ProductEntity.FIELD_OLDPRICE);
            bicData.Selecting.Add(ProductEntity.FIELD_PRICE);
            bicData.Selecting.Add(ProductEntity.FIELD_SALEOFF);
            bicData.Selecting.Add(ProductEntity.FIELD_IMAGEID);
            bicData.Selecting.Add(ProductEntity.FIELD_TARGET);
            bicData.Selecting.Add(ProductEntity.FIELD_BRIEFDESCRIPTION);
            bicData.Selecting.Add(ProductEntity.FIELD_MENUUSERNAME);
            bicData.Selecting.Add("UrlName");
            bicData.Conditioning.Add(new ConditioningItem("LanguageKey", language, Operator.EQUAL, CompareType.STRING));
            bicData.Conditioning.Add(new ConditioningItem(ProductEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
            bicData.Conditioning.Add(con);

            var data = bicData.GetPagingData();

            string result = string.Empty;
            TotalRecord = data.Rows.Count;
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var imageId = data.Rows[i]["ImageID"];
                    var imageLink = BicImage.GetPathImageThumb(BicConvert.ToInt32(imageId));

                    result += string.Format("<div class=\"p-item\"><figure><a href=\"{0}\" title=\"{1}\">",
                        string.Format("/{0}/{1}/{2}.html", language,data.Rows[i]["MenuUserName"].ToString(), data.Rows[i]["UrlName"].ToString()),
                        data.Rows[i]["Title"].ToString());
                    result += string.Format("<span class=\"hidden \">{0}%</span>", data.Rows[i]["SaleOff"].ToString());
                    result += string.Format("<img src=\"{0}\" alt=\"{1}\"></a></figure>", imageLink, data.Rows[i]["Title"].ToString());
                    result += string.Format("<a class=\"title\" href=\"{0}\" title=\"{1}\">{2}</a>", string.Format("/{0}/{1}/{2}.html", language, data.Rows[i]["MenuUserName"].ToString(),
                        data.Rows[i]["UrlName"].ToString()), data.Rows[i]["Title"].ToString(), data.Rows[i]["Title"].ToString());
                    result += string.Format("<div class=\"price\"><div class=\"price-box\"><i class=\"fa fa-angle-double-right\" aria-hidden=\"true\"></i>{0}</div></div>",
                        GetPrice(data.Rows[i]["OldPrice"].ToString(), data.Rows[i]["Price"].ToString(), language));
                    result += "</div>";
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    private static string GetPrice(string OldPrice, string Price, string language)
    {

        string s = string.Empty;
        int tigia = 1;
        decimal giacu = 0;
        decimal giamoi = 0;
        if (string.IsNullOrEmpty(OldPrice) || OldPrice == "0")
        {
            string link = "/" + language + (language == "en" ? "/contact.html" : "/lien-he.html");
            string text = language == "en" ? "Contact" : "Liên hệ mua hàng";
            s = string.Format("<a href='{0}' target='_self' >{1}</a>", link, text);
        }
        else
        {
            giacu = (Convert.ToDecimal(OldPrice.Replace(".", ".")) * tigia) / 1000;
            if (string.IsNullOrEmpty(Price) || Price == "0")
            {
                s = string.Format("<ins>{0} VNĐ</ins>", BicString.ToStringNO((Convert.ToInt64(giacu) * 1000).ToString()));
            }
            else
            {
                giamoi = (Convert.ToDecimal(Price.Replace(".", ".")) * tigia) / 1000;
                s = string.Format("<del>{0} VNĐ</del>&nbsp<ins>{1} VNĐ</ins>", BicString.ToStringNO((Convert.ToInt64(giacu) * 1000).ToString()), BicString.ToStringNO((Convert.ToInt64(giamoi) * 1000).ToString()));
            }
        }
        return s;
    }
}
public class Filter
{
    public int count { get; set; }
    public string result { get; set; }
}