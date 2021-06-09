using System;
using System.Data;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Utils;
using BIC.WebControls;

public partial class Admin_Components_Comment_ViewComment : BaseUserControl
{
    public int Id;
    private CommentEntity commentEntity { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = BicHtml.GetRequestString("id", 0);
        if (!IsPostBack)
        {
            LoadDataFromEntity();
        }
    }
    private void LoadDataFromEntity()
    {
        commentEntity = CommentBiz.GetCommentByID(Id);
        if (commentEntity != null)
        {
            lblDBFullName.Text = BicConvert.ToString(commentEntity.FullName);
            lblObjTitle.Text = GetObjTitleForComment(commentEntity.Id);
            lblDBDescription.Text = BicConvert.ToString(commentEntity.Description);
            lblCreateDate.Text = String.Format("{0: dd/MM/yyyy}", commentEntity.CreateDate);
            lblModifiedDate.Text = String.Format("{0: dd/MM/yyyy}", commentEntity.ModifiedDate);
            chkIsActive.Checked = BicConvert.ToBoolean(commentEntity.IsActive);
            lblSex.Text = (commentEntity.GioiTinh ? "Nam" : "Nữ") + (!string.IsNullOrEmpty(commentEntity.Address) ? " - Thành viên" : "");
            lbldongy.Text = commentEntity.DongY + " / " + commentEntity.KhongDongY;
        }
    }
    protected string GetObjTitleForComment(int objID) //Obj may be article or product
    {
        string retVal = "";
        var bicData = new BicGetData();
        bicData.TableName = "Article";
        bicData.Conditioning.Add(new ConditioningItem("ArticleID", BicConvert.ToString(objID), Operator.EQUAL, CompareType.NUMERIC));
        bicData.Selecting.Add("Title");
        DataTable data = bicData.GetAllData();
        if (data.Rows.Count > 0)
        {
            retVal = BicConvert.ToString(data.Rows[0]["Title"]);
        }
        return retVal;
    }
    protected void IsActive_Click(object sender, EventArgs e)
    {
        commentEntity.IsActive = commentEntity.IsActive ? false : true;
        CommentBiz.UpdateComment(commentEntity);
    }
    protected void lbReply_Click(object sender, EventArgs e)
    {
    }
}