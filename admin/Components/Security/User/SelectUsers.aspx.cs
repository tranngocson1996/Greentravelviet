using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIC.Utils;

namespace StoreInfo
{
    public partial class SelectUsers : Page
    {
        private MembershipUserCollection _allUsers = Membership.GetAllUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRole();
                BindUser();
            }
        }
        public void BindRole()
        {
            ddlRole.DataSource = Roles.GetAllRoles();
            ddlRole.DataBind();
        }
        private void BindUser()
        {
            MembershipUserCollection users = Membership.GetAllUsers();
            BindingList(users);
        }
        private void SearchUser()
        {
            _allUsers = Membership.GetAllUsers();
            string searchText = txtSearch.Text.Trim();
            if (searchText != string.Empty)
            {
                _allUsers = rdSearchType.SelectedValue.Equals("1") ? Membership.FindUsersByEmail("%" + searchText + "%") : Membership.FindUsersByName("%" + searchText + "%");
            }
            BindingList(_allUsers);
        }
        protected void BindingList(MembershipUserCollection source)
        {
            pager.PageSize = 20;
            pager.DataSource = source;
            pager.BindToControl = dlUser;
            dlUser.DataSource = pager.DataSourcePaged;
            dlUser.DataBind();
            pager.DataBind();
        }
        protected ProfileCommon GetProfile(string userName)
        {
            ProfileCommon profile = Profile.GetProfile(userName);
            return profile;
        }
        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindUser();
        }
        protected void dlUser_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string commandname = e.CommandName.ToLower();
            if (commandname == "selectuser")
            {
                int recordIndex = Convert.ToInt32(e.Item.DataItemIndex);
                string useritem = dlUser.DataKeys[recordIndex].Value.ToString();
                if (!CheckSelectUser(useritem))
                    txtTo.Text = useritem + "," + txtTo.Text;
            }
        }
        protected bool CheckSelectUser(string user)
        {
            bool kq = false;
            string[] arrUser = BicString.SplitComma(txtTo.Text);
            IEnumerable<string> resuser = from s in arrUser where s.Equals(user) select s;
            if (resuser.Count() > 0) kq = true;
            return kq;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUser();
        }
        protected void btnAll_Click(object sender, EventArgs e)
        {
            txtTo.Text = string.Empty;
            for (int i = 0; i < dlUser.Items.Count; i++)
            {
                string useritem = dlUser.DataKeys[i].Value.ToString();
                txtTo.Text = useritem + "," + txtTo.Text;
            }
            btnOK.Attributes.Add("onclick", string.Format("returnValue('{0}');", txtTo.Text));
        }
        protected void btnRole_Click(object sender, EventArgs e)
        {
            txtTo.Text = "G:" + ddlRole.SelectedItem.Text + "," + txtTo.Text;
        }
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "0")
            {
                BindUser();
                return;
            }
            var users = new MembershipUserCollection();
            _allUsers = Membership.GetAllUsers();
            foreach (MembershipUser user in _allUsers)
            {
                if (GetProfile(user.UserName).Company == ddlRole.SelectedItem.Value)
                {
                    users.Add(user);
                }
            }
            BindingList(users);
        }
        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            txtTo.Text = string.Empty;
        }
        private void Binuser()
        {
            var users = new MembershipUserCollection();
            _allUsers = Membership.GetAllUsers();
            foreach (MembershipUser user in _allUsers)
            {
                if (GetProfile(user.UserName).Company == ddlRole.SelectedItem.Value)
                {
                    users.Add(user);
                }
            }
            BindingList(users);
        }
    }
}