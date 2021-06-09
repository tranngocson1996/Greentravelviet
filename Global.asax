<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    public void ClearCache()
    {
        var keyList = new List<string>();
        var cacheEnum = HttpContext.Current.Cache.GetEnumerator();
        while (cacheEnum.MoveNext())
        {
            keyList.Add(cacheEnum.Key.ToString());
        }
        foreach (var key in keyList)
        {
            HttpContext.Current.Cache.Remove(key);
        }
    }

    private void RegisterRoutes(RouteCollection routes)
    {   
        routes.Ignore("{resource}.axd/{*pathInfo}");
        routes.MapPageRoute("shoppingcartviewtoprint", "{l}/ShoppingCartToPrint.i{id}.html", "~/ShoppingCartViewToPrint.aspx");
        routes.MapPageRoute("shoppingcartviewtoprint1", "{l}/ShoppingCartToPrint1.i{id}.html", "~/ShoppingCartViewToPrint1.aspx");
        routes.MapPageRoute("shopping-cart", "{l}/{shopping-cart}.sc{id}.html", "~/ShoppingCart.aspx");
        routes.MapPageRoute("shopping-cart-2", "{l}/shopping-cart.html", "~/ShoppingCart.aspx");
        
        routes.MapPageRoute("intro", "", "~/Default.aspx");
        //Route them
        routes.MapPageRoute("search", "{k}/search.html", "~/Searching.aspx");
        //System
        routes.MapPageRoute("tour-detail", "{l}/{menu_name}.td{lv}/{name}.i{id}.html", "~/TourDetail.aspx");
        routes.MapPageRoute("tour-detail-2", "{l}/{menu_name}.td/{name}.html", "~/TourDetail.aspx");
        routes.MapPageRoute("tour-search", "{l}/tour-search.html", "~/TourSeachResult.aspx");
        routes.MapPageRoute("tour-search-2", "{l}/searchTour.html", "~/TourSeachResult.aspx");
        routes.MapPageRoute("book-tour", "{l}/{id}/book-tour.html", "~/BookTour.aspx");
        routes.MapPageRoute("category", "{l}/{menu_name}.html", "~/Default.aspx");
        routes.MapPageRoute("detail", "{l}/{menu_name}/{name}.html", "~/Default.aspx");
        routes.MapPageRoute("detail2", "{l}/{menu_name}.td/{name}.html", "~/Default.aspx");
        routes.MapPageRoute("sub-category", "{l}/{parent_menu}/{menu_name}.html", "~/Default.aspx");
        

    }

    private void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    private void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }
    private void Application_PreRequestHandlerExecute(object sender, EventArgs e)
    {
       
        var i = Request.Url.ToString().IndexOf("www.", StringComparison.Ordinal);
        if (i >= 8 || i == -1) return;
        Response.Clear();
        Response.Status = "301 Moved Permanently";
        Response.AddHeader("Location", Request.Url.ToString().Remove(i, 4));
        Response.End();
    }
    private void Application_Error(object sender, EventArgs e)
    {
        
    }

    private void Session_Start(object sender, EventArgs e)
    {
        var popup = new HttpCookie("popupadv");
        popup.Value = "1";
        popup.Expires = DateTime.Now.AddDays(1);
        //Session["popupadv"] = 1;
    }

    private void Session_End(object sender, EventArgs e)
    {
        
    }

</script>
