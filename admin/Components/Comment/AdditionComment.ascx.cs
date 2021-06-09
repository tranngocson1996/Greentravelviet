using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Handler;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Comment_AdditionComment : BaseUserControl
{
    private int ArticleId
    {
        get { return BicHtml.GetRequestString("articleid", 0); }
    }
    private int CommentId
    {
        get { return BicHtml.GetRequestString("commentid", 0); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ArticleId == 0 && CommentId == 0)
        {
            BicAdmin.NavigateToList();
        }
        if (IsPostBack) return;
        try
        {
            var comment = CommentBiz.GetCommentByID(CommentId);
            if (comment != null)
            {
                lblbv.Text = CommentId > 0 ? comment.Description : ArticleBiz.GetArticleByID(ArticleId).Title;
                TypeOfComment();
                if (BicControl.DropExistValue(comment.TypeOfComment, ddlTypeOfComment))
                    ddlTypeOfComment.SelectedValue = comment.TypeOfComment;
            }
        }
        catch (Exception ex)
        {
            LogEvent.LogToFile(ex.ToString());
        }

        txtFullName.Text = Profile.GetProfile(BicMemberShip.CurrentUserName).FullName;
    }

    protected void TypeOfComment()
    {
        BicXML.BindDropDownListFromXML(ddlTypeOfComment, string.Format("{0}admin/XMLData/TypeOfComment.xml", BicApplication.URLRoot));
        ddlTypeOfComment.Items.Insert(0, new ListItem("[Lựa chọn]", "0"));
    }
    private CommentEntity LoadDataToEntity()
    {
        var commentEntity = new CommentEntity();
        commentEntity.Id = (commentEntity.Parent = CommentId) > 0 ? CommentBiz.GetCommentByID(CommentId).Id : ArticleId;
        commentEntity.FullName = Profile.GetProfile(BicMemberShip.CurrentUserName).FullName;
        commentEntity.TypeOfComment = ddlTypeOfComment.SelectedValue;
        commentEntity.GioiTinh = Profile.GetProfile(BicMemberShip.CurrentUserName).GioiTinh == "Nam";
        commentEntity.Address = txtPhone.Text.Trim();
        commentEntity.Description = txtDescription.Content;
        commentEntity.IsActive = chkIsActive.Checked;
        commentEntity.IsHot = chkIsHot.Checked;
        commentEntity.Email = txtEmail.Text.Trim();
        return commentEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            switch (e.CommandName)
            {
                case "AddNew":
                    CommentBiz.InsertComment(LoadDataToEntity());
                    BicAdmin.NavigateToList();


                    break;
            }
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}