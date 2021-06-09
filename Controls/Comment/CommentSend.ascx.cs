using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

public partial class Controls_Comment_CommentSend : UserControl
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

    public int RefId
    {
        get
        {
            return BicConvert.ToInt32(lblarticleid.Text.Trim());
        }
        set { lblarticleid.Text = value.ToString(); }
    }

    public string TypeOfComment
    {
        get { return lbltype.Text; }
        set { lbltype.Text = value; }
    }
    //public string Usernamewaslogin
    //{
    //    get { return BicSession.ToString("UsernameWasLoggedIn"); }
    //}
    //public ProfileCommon CurrentUser
    //{
    //    get { return (new ProfileCommon()).GetProfile(BicMemberShip.CurrentUserName); }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        Include.ScriptToBottom("Article.js");
        racComment.Attributes.Add("onkeypress", "return clickButton(event,'" + btnPost.ClientID + "')");
        if (!IsPostBack)
        {
            //if (BicMemberShip.CurrentUserName != string.Empty)
            //{
            //    txtName.Text = CurrentUser.FullName;
            //    txtName.Enabled = false;
            //    rdbList.Enabled = false;
            //    rdbList.SelectedValue = CurrentUser.GioiTinh;
            //}
            if (!string.IsNullOrEmpty(BicMemberShip.CurrentUserName))
            {
                var profile = new ProfileCommon().GetProfile(BicMemberShip.CurrentUserName);
                if (profile != null)
                {
                    txtName.Text = profile.FullName;
                    //txtName.ReadOnly = true;
                    //txtName.Enabled = false;
                }
            }
        }
    }
    protected void btnPost_OnCommand(object sender, CommandEventArgs e)
    {
        if (racComment.IsValid)
        {
            //Khi thêm mới 1 comment, nếu TypeOfComment là 1 tức là chức năng tin tức, hệ thống sẽ tự động tăng giá trị InActiveComment trong bảng Article lên 1 đơn vị
            txtName.Enabled = true;
            rdbList.Enabled = true;
            var commententity = new CommentEntity { CreateDate = DateTime.Now, Description = txtDescription.Text, DongY = 0, KhongDongY = 0, Id = RefId, TypeOfComment = TypeOfComment, FullName = txtName.Text, GioiTinh = rdbList.SelectedIndex == 0 };
            if (ParentId > 0)
            {
                commententity.Parent = ParentId;
            }
            CommentBiz.InsertComment(commententity);

            BicAjax.Alert("Cảm ơn quý bạn đọc đã phản hồi, BQT sẽ xử lý và sớm đăng tải phản hồi này!");
            txtName.Text = txtDescription.Text = string.Empty;

            //else
            //    BicAjax.Alert("Bình luận của bạn gửi không thành công!");
        }
        else
            BicAjax.Alert("Bạn nhập sai mã xác nhận, vui lòng nhập lại!");
    }
}