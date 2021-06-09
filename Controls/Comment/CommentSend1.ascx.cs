using System;
using System.Web.UI;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Comment_CommentSend1 : UserControl
{
    public string ButtonLabel
    {
        set { btnPost.Text = value; }
    }
    public int ParentId
    {
        get { return int.Parse(string.IsNullOrEmpty(lblid.Text) ? "-1" : lblid.Text); }
        set { lblid.Text = value.ToString(); }
    }
    public string TypeOfComment
    {
        get { return lbltype.Text; }
        set { lbltype.Text = value; }
    }
    public int RefId
    {
        get { return BicRouting.GetRequestString("id", 0); }
    }

    //protected bool Visible;

    protected void Page_Load(object sender, EventArgs e)
    {
        Include.ScriptToBottom("Article.js");
        //if (!IsPostBack)
        //{
        //    BindingData();
        //}
    }
  /*  private void BindingData()
    {
        try
        {
            var bicData = new BicGetData("Comment");
            bicData.Selecting.Add(CommentEntity.FIELD_FULLNAME);
            bicData.Selecting.Add(CommentEntity.FIELD_DESCRIPTION);
            bicData.Selecting.Add(CommentEntity.FIELD_TYPEOFCOMMENT);
            bicData.Selecting.Add(CommentEntity.FIELD_ID);
            bicData.Selecting.Add(CommentEntity.FIELD_CREATEDATE);
            bicData.Sorting.Add(new SortingItem(CommentEntity.FIELD_CREATEDATE, true));
            //bicData.PageIndex = pager.PageIndex;
            bicData.PageSize = 15;
            bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_ISACTIVE, "1", Operator.EQUAL, CompareType.NUMERIC));
            bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_ID, RefId.ToString(), Operator.EQUAL, CompareType.STRING));
            bicData.Conditioning.Add(new ConditioningItem(CommentEntity.FIELD_TYPEOFCOMMENT, "2", Operator.EQUAL, CompareType.NUMERIC));

            var data = bicData.GetAllData();
            //pager.TotalItems = bicData.TotalItems;
            if (data.Rows.Count == 0)
                lblNote.Text = "Không có bình luận nào.";
            lvComment.DataSource = data;
            lvComment.DataBind();
            //if (data.Rows.Count == 0)
            //    pager.Visible = false;
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }
    } */

    protected void pager_PageIndexChanged(object sender, PagerUIEventArgs e)
    {
        //pager.PageIndex = e.NewPageIndex;
        //BindingData();
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            var commententity = new CommentEntity { CreateDate = DateTime.Now, Description = txtDescription1.Text, DongY = 0, KhongDongY = 0, Id = RefId, TypeOfComment = "2", FullName = txtName1.Text };
            // su dung Address thay cho LanguageKey
            //commententity.Address = BicRouting.GetRequestString("l");
            CommentBiz.InsertComment(commententity);
            BicAjax.Alert(BicResource.GetValue("MessCommentSuccess"));
            txtName1.Text = BicResource.GetValue("FullName");
            txtDescription1.Text = BicResource.GetValue("ContentComent");
        }
        else
        {
            BicAjax.Alert(BicResource.GetValue("MessCommentError"));
        }
    }
}