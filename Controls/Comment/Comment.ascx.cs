using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Comment_Comment : UserControl
{
    public int ArticleID
    {
        get { return BicConvert.ToInt32(lblArticleId.Text); }
        set
        {
            lblArticleId.Text = value.ToString();
            CommentSend1.RefId = value;
        }
    }
    //public ProfileCommon CurrentUser
    //{
    //    get { return (new ProfileCommon()).GetProfile(BicMemberShip.CurrentUserName); }
    //}
    public string TypeOfComment
    {
        get { return lblTypeOfComment.Text; }
        set
        {
            lblTypeOfComment.Text = value;
            CommentSend1.TypeOfComment = value;
        }
    }

    public int ParentId
    {
        get { return BicConvert.ToInt32(hfParentID.Value); }
        set
        {
            hfParentID.Value = value.ToString();
            CommentSend1.ParentId = value;
        }
    }

    public string CheckDateTime(DateTime dt)
    {
        if (DateTime.Now.ToShortDateString() == dt.ToShortDateString())
        {
            if (dt.Day.Equals(DateTime.Now.Day) && !dt.Hour.Equals(DateTime.Now.Hour))
                return string.Format("cách đây {0} giờ", DateTime.Now.Subtract(dt).Hours);
            if (dt.Hour.Equals(DateTime.Now.Hour))
                return string.Format("cách đây {0} phút", DateTime.Now.Subtract(dt).Minutes);
            //if (dt.Minute.Equals(DateTime.Now.Minute))
            //    return string.Format("cách đây {0} giây", DateTime.Now.Subtract(dt).Seconds);
        }
        return dt.ToString("dd/MM/yyyy");
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Include.CssToTop("Comment.css");
        Include.ScriptToBottom("search.js");
        Include.ScriptToBottom("ScrollBar.js");
        Include.ScriptToBottom("Comment.js");
        if (!IsPostBack)
        {
            GetCommentList();
        }
    }

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        pComment.PageIndex = e.NewPageIndex;
        GetCommentList();
    }

    protected void ViewAll(object sender, CommandEventArgs e)
    {
        pComment.PageSize = 1000;
        GetCommentList();

    }

    private void GetCommentList()
    {
        try
        {
            var bicData = new BicGetData("Comment");
            bicData.Selecting.Add("*");
            bicData.Sorting.Add(new SortingItem("CreateDate", true));
            bicData.PageIndex = pComment.PageIndex;
            bicData.PageSize = 15;
            bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_ID, ArticleID.ToString(), Operator.EQUAL,
                                                      CompareType.NUMERIC));
            bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_TYPEOFCOMMENT, TypeOfComment, Operator.EQUAL));
            bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
            var data = bicData.GetPagingData();
            pComment.TotalItems = bicData.TotalItems;
            pComment.PageSize = 15;
            lvComment.DataSource = data;
            lvComment.DataBind();
            if (data.Rows.Count == 0)
                pComment.Visible = false;
            CommentBiz.PurgeCacheItems("Comment_Comment");
            //int total;
            //var data = CommentBiz.GetByParent(ParentId, pComment.PageSize, pComment.PageIndex, out total);
            //if (data.Any())
            //{
            //    lvComment.DataSource = data;
            //    lvComment.DataBind();
            //    pComment.TotalItems = total;
            //}
            //if (total <= 5)
            //    pComment.Visible = false;
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    }
}