using System;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Comment_EditionComment : BaseUserControl
{
    protected string ContainerName;
    protected int Id;
    protected int ObjID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        tbBottom.PAdd = tbTop.PAdd = false;
        if (!IsPostBack)
        {
            TypeOfComment();
            LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
        var commentEntity = CommentBiz.GetCommentByID(Id);
        if (commentEntity == null) return;
        ddlLanguage.Items.FindByValue("vi").Selected = true;
        txtFullName.Text = BicConvert.ToString(commentEntity.FullName);
        ObjID = commentEntity.Id;
        if (BicControl.DropExistValue(commentEntity.TypeOfComment, ddlTypeOfComment))
            ddlTypeOfComment.Items.FindByValue(commentEntity.TypeOfComment).Selected = true;
        txtDescription.Content = BicConvert.ToString(commentEntity.Description);
        chkIsActive.Checked = BicConvert.ToBoolean(commentEntity.IsActive);
        txtEmail.Text = commentEntity.Email;
        txtPhone.Text = commentEntity.Address;
        chkIsHot.Checked = commentEntity.IsHot;
        //Binding object title list, maybe product title or article title list
    }
    protected void ddlLanguage_SelectedIndexChanged(object o, EventArgs e)
    {
        BicSession.SetValue("CommentLang", ddlLanguage.SelectedValue);
    }
    protected void TypeOfComment()
    {
        BicXML.BindDropDownListFromXML(ddlTypeOfComment, string.Format("{0}admin/XMLData/TypeOfComment.xml", BicApplication.URLRoot));
        ddlTypeOfComment.Items.Insert(0, new ListItem("[Lựa chọn]", "0"));
    }
    private CommentEntity LoadDataToEntity()
    {
        var commentEntity = CommentBiz.GetCommentByID(Id);
        commentEntity.Address = txtPhone.Text.Trim();
        commentEntity.FullName = BicConvert.ToString(txtFullName.Text);
        commentEntity.Description = BicConvert.ToString(txtDescription.Content);
        commentEntity.IsActive = chkIsActive.Checked;
        commentEntity.IsHot = chkIsHot.Checked;
        commentEntity.Email = txtEmail.Text.Trim();
        commentEntity.TypeOfComment = ddlTypeOfComment.SelectedValue;
        commentEntity.ModifiedDate = DateTime.Now;
        return commentEntity;
    }
    protected void Save(object sender, CommandEventArgs e)
    {
        try
        {
            //if (ddlTypeOfComment.SelectedValue != "0")
            //{
            if (e.CommandName == "Update")
            {
                if (CommentBiz.UpdateComment(LoadDataToEntity()))
                {
                    BicAdmin.NavigateToList();
                }
                else
                    BicAjax.Alert(BicMessage.UpdateFail);
            }
            //}
            //else
            //    BicHtml.Alert("Bạn chưa chọn loại bình luận");
        }
        catch (Exception ex)
        {
            BicAjax.Alert(ex.Message);
        }
    }
}