using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using BIC.Biz;
using BIC.Data;
using BIC.Entity;
using BIC.Handler;
using Telerik.Web.UI;

namespace BIC.Utils
{
    public class MenuUserUtils : MenuUserBiz
    {
        /// <summary>
        /// Đọc ra danh sách vị trí danh mục
        /// </summary>
        /// <param name="ddlModeMenu">Dropdownlist sẽ hiển thị danh sách vị trí danh mục</param>
        /// <param name="language">Ngôn ngữ </param>
        public static void BindingModelMenu(DropDownList ddlModeMenu, string language)
        {
            BicXML.BindDropDownListFromXML(ddlModeMenu, string.Format("{0}ModelMenu_{1}.xml", BicApplication.URLPath("Admin/XMLData"), language));
        }

        /// <summary>
        /// Đọc ra danh sách vị trí đặc biểt
        /// </summary>
        /// <param name="ddlChannelId">Dropdownlist sẽ hiển thị danh sách vị trí đặc biệt</param>
        /// <param name="typeId">Giá trị đọc từ File ModelMenu</param>
        /// <param name="language">Ngôn ngữ</param>
        public static void BindingChannelId(DropDownList ddlChannelId, string typeId, string language)
        {
            var data = new BicGetData { TableName = "MenuUser" };
            data.Sorting.Add(new SortingItem("Priority", false));
            data.Selecting.Add(MenuUserEntity.FIELD_NAME);
            data.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
            if (typeId != string.Empty)
                data.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_TYPEID, typeId, Operator.EQUAL, CompareType.NUMERIC));
            if (language != string.Empty)
                data.Conditioning.Add(new ConditioningItem(MenuUserEntity.FIELD_LANGUAGEKEY, language, Operator.EQUAL, CompareType.STRING));
            ddlChannelId.DataSource = data.GetAllData();
            ddlChannelId.DataTextField = MenuUserEntity.FIELD_NAME;
            ddlChannelId.DataValueField = MenuUserEntity.FIELD_MENUUSERID;
            ddlChannelId.DataBind();
            ddlChannelId.Items.Insert(0, new ListItem("[Lựa chọn]", "0"));
        }

        /// <summary>
        /// Đọc ra danh sách vị trí đặc biểt
        /// </summary>
        /// <param name="rtvMenuUser">RadTreeView sẽ hiển thị danh sách vị trí đặc biệt</param>
        /// <param name="language">Ngôn ngữ</param>
        /// <param name="typeOfControl">Nhận giá trị news, products, docs,video, gallery,faq</param>
        public static void BindingRadTreeView(RadTreeView rtvMenuUser, string language, string typeOfControl)
        {
            try
            {
                rtvMenuUser.Nodes.Clear();
                var bicXml = new BicXML { XmlPath = BicApplication.URLPath("Admin/XMLData") + "ModelMenu_" + language + ".XML" };
                DataTable dt = bicXml.GetXMLContent().Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["type"].ToString().Equals("global") || dr["type"].ToString().Equals(typeOfControl))
                            rtvMenuUser.Nodes.Add(new RadTreeNode { Text = dr["name"].ToString(), Value = dr["key"].ToString(), Checkable = false });
                    }
                    foreach (RadTreeNode rad in rtvMenuUser.Nodes)
                    {
                        dt = GetMenuUserByTypeOfControl(typeOfControl, language, rad.Value);

                        foreach (DataRow entity in dt.Rows)
                        {
                            rad.Checkable = false;
                            var radTreeNode = new RadTreeNode { Value = entity["MenuUserId"].ToString(), Text = entity["Name"].ToString(), Enabled = BicConvert.ToBoolean(entity["EnableCheck"]) };

                            if (BicConvert.ToInt32(entity["Level"]) == 1)
                            {
                                if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
                                {
                                    radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                                    //if (radTreeNode.Enabled == true)
                                    //{
                                    rad.Nodes.Add(radTreeNode);
                                    //  }
                                    GetNodes(radTreeNode, BicConvert.ToInt32(entity["MenuUserId"]), typeOfControl);
                                }
                                else
                                {
                                    if (radTreeNode.Enabled == true)
                                        rad.Nodes.Add(radTreeNode);
                                }
                                radTreeNode.ExpandParentNodes();
                            }

                            if (radTreeNode.GetAllNodes().Count == 0 && radTreeNode.Enabled == false)
                                radTreeNode.Remove();

                        }
                        if (dt.Rows.Count == 0)
                            rad.Visible = false;
                        else
                        {
                            rad.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                            rad.ExpandParentNodes();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
        }
        public static void BindingRadTreeView(RadTreeView rtvMenuUser, string language, string typeOfControl, string column)
        {
            try
            {
                rtvMenuUser.Nodes.Clear();
                var bicXml = new BicXML { XmlPath = BicApplication.URLPath("Admin/XMLData") + string.Format("ModelMenu_{0}.XML", language) };
                DataTable dt = bicXml.GetXMLContent().Tables[0];
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if ((dr["type"].ToString().Equals("global") || dr["type"].ToString().Equals(typeOfControl)) && dr["cot"].ToString().Equals(column))
                            rtvMenuUser.Nodes.Add(new RadTreeNode { Text = dr["name"].ToString(), Value = dr["key"].ToString(), Checkable = false });
                    }
                    foreach (RadTreeNode rad in rtvMenuUser.Nodes)
                    {
                        dt = GetMenuUserByTypeOfControl(typeOfControl, language, rad.Value);
                        foreach (DataRow entity in dt.Rows)
                        {
                            rad.Checkable = false;
                            var radTreeNode = new RadTreeNode { Value = entity["MenuUserId"].ToString(), Text = entity["Name"].ToString(), Enabled = BicConvert.ToBoolean(entity["EnableCheck"]) };

                            if (BicConvert.ToInt32(entity["Level"]) == 1)
                            {
                                if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
                                {
                                    radTreeNode.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                                    //if (radTreeNode.Enabled == true)
                                    //{
                                    rad.Nodes.Add(radTreeNode);
                                    //  }
                                    GetNodes(radTreeNode, BicConvert.ToInt32(entity["MenuUserId"]), typeOfControl);
                                }
                                else
                                {
                                    if (radTreeNode.Enabled == true)
                                        rad.Nodes.Add(radTreeNode);
                                }

                                radTreeNode.ExpandParentNodes();
                            }
                            if (radTreeNode.GetAllNodes().Count == 0 && radTreeNode.Enabled == false)
                                radTreeNode.Remove();
                        }
                        if (dt.Rows.Count == 0)
                            rad.Visible = false;
                        else
                        {
                            rad.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                            rad.ExpandParentNodes();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
        }
        public static void BindingRadTreeViewRecursion(RadTreeView rtvMenuUser, string language, string typeOfControl)
        {
            BindingRadTreeViewRecursion(rtvMenuUser, language, typeOfControl, false);
        }

        public static void BindingRadTreeViewRecursion(RadTreeView rtvMenuUser, string language, string typeOfControl, bool Sort)
        {
            try
            {
                rtvMenuUser.Nodes.Clear();
                var bicXml = new BicXML { XmlPath = BicApplication.URLPath("Admin/XMLData") + string.Format("ModelMenu_{0}.XML", language) };
                var dt = bicXml.GetXMLContent().Tables[0];
                if (dt != null)
                {
                    var dv = dt.DefaultView;
                    if (Sort)
                    {
                        dv.Sort = "Name ASC";
                    }
                    foreach (DataRow dr in dv.ToTable().Rows.Cast<DataRow>().Where(dr => dr["type"].ToString().Equals("global") || dr["type"].ToString().Equals(typeOfControl)))
                    {
                        rtvMenuUser.Nodes.Add(new RadTreeNode(dr["name"].ToString(), dr["key"].ToString()));
                    }
                    //rtvMenuUser.ExpandAllNodes();
                    foreach (RadTreeNode rad in rtvMenuUser.Nodes)
                    {
                        dt = GetMenuUserByTypeOfControl(typeOfControl, language, rad.Value);
                        foreach (DataRow entity in dt.Rows)
                        {
                            rad.Checkable = false;
                            var radTreeNode = new RadTreeNode { Value = entity["MenuUserId"].ToString(), Text = entity["Name"].ToString(), Enabled = BicConvert.ToBoolean(entity["EnableCheck"]) };
                            rad.Nodes.Add(radTreeNode);
                            GetNodes(radTreeNode, BicConvert.ToInt32(entity["MenuUserId"]), typeOfControl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogEvent.LogToFile(ex.ToString());
            }
        }
        private static void GetNodes(RadTreeNode node, int menuUserId, string typeOfControl)
        {
            DataTable dt = GetAllMenuUserByTypeOfControl(menuUserId, typeOfControl);
            foreach (DataRow entity in dt.Rows)
            {
                var radTreeNode = new RadTreeNode { Value = entity["MenuUserId"].ToString(), Text = entity["Name"].ToString(), Enabled = BicConvert.ToBoolean(entity["EnableCheck"]) };
                if (BicConvert.ToInt32(entity["ChildrenCount"]) > 0)
                {
                    node.Nodes.Add(radTreeNode);
                    GetNodes(radTreeNode, BicConvert.ToInt32(entity["MenuUserId"]), typeOfControl);
                }
                if (radTreeNode.Enabled == true)
                {
                    node.Nodes.Add(radTreeNode);
                }
                if (radTreeNode.GetAllNodes().Count == 0 && radTreeNode.Enabled == false)
                    radTreeNode.Remove();
            }
        }
        /// <summary>
        /// Tạo danh sách DropDowList dạng Cây đệ quy
        /// </summary>
        /// <param name="ddlMenuUser">Tên DropDownList sẽ nạp dữ liệu</param>
        /// <param name="sLanguageKey">Ngôn ngữ</param>
        /// <param name="typeId">Vị trí danh mục: Dữ liệu lấy từ file ModelMenu.xml</param>
        /// <param name="sTypeOfControl">Nhóm chức năng: Lấy giá trị TypeOfControl của bảng FrameView</param>
        public static void BuildMenuUserTree(DropDownList ddlMenuUser, string sLanguageKey, string typeId, string sTypeOfControl)
        {
            BuildMenuUserDropDownList(GetRecursiveByType(sLanguageKey, typeId, sTypeOfControl), ddlMenuUser);
        }

        //Phuong thuc merge ca MenuUserID con cua phan tu hien tai
        //Dua vao parentID doc ra tat ca cac MenuUserID con cua no
        private static string MergeMenuUserID(DataTable dt, int iParentId)
        {
            //Khoi tao mang datarow chua cac row theo parentID dua vao
            DataRow[] arrMenuUserRow = dt.Select("ParentID ='" + iParentId + "'");
            string sMerged = iParentId.ToString();
            return arrMenuUserRow.Aggregate(sMerged, (current, dr) => current + ("," + MergeMenuUserID(dt, BicConvert.ToInt32(dr[MenuUserEntity.FIELD_MENUUSERID]))));
        }

        /// <summary>
        /// Phương thức trả tất cả ID con của một ID theo dạng đệ quy
        /// </summary>
        /// <param name="parentId">ID menu cần đọc giá trị</param>
        /// <returns></returns>
        public static string GetArrayMenuIdByParent(int parentId)
        {
            var data = new BicGetData("MenuUser", new SortingItem("Priority", false));
            data.Selecting.Add(MenuUserEntity.FIELD_MENUUSERID);
            data.Selecting.Add(MenuUserEntity.FIELD_PARENTID);
            DataTable dt = data.GetAllData();
            return MergeMenuUserID(dt, parentId);
        }
        public static void CheckNode(RadTreeView atv, string text)
        {
            var array = BicString.SplitComma(text);
            foreach (RadTreeNode rtn in atv.GetAllNodes())
            {
                if (Array.IndexOf(array, rtn.Value) >= 0)
                {
                    rtn.Checked = true;
                }
            }
        }
        public static void SetCheckedNodes(RadTreeView atv, string text)
        {
            string[] array = BicString.SplitComma(text);
            foreach (RadTreeNode rtn in atv.Nodes)
            {
                foreach (string s in array)
                    if (rtn.Value == s)
                        rtn.Checked = true;
                CheckedTreeViewNode(rtn, text);
            }
        }
        private static void CheckedTreeViewNode(RadTreeNode rtnParent, string text)
        {
            string[] array = BicString.SplitComma(text);
            foreach (RadTreeNode rtn in rtnParent.Nodes)
            {
                foreach (string s in array)
                {
                    if (rtn.Value == s)
                    {
                        rtn.Checked = true;
                        rtn.ExpandMode = TreeNodeExpandMode.ServerSideCallBack;
                        rtn.ExpandChildNodes();
                        rtn.ExpandParentNodes();
                    }
                }
                CheckedTreeViewNode(rtn, text);
            }
        }

        public static DataTable GetAllMenuUserByTypeOfControl(int parentId, string typeOfControl)
        {
            var query =
               string.Format(@"SELECT
                [MenuUserID]
                ,[Name]
                ,(case when (FrameViewID in (Select FrameViewId from FrameView where TypeOfControl ='{0}'))  then 1 else 0 end) as EnableCheck
                ,ISNULL(pc2.ChildrenCount, 0) as ChildrenCount

        FROM MenuUser as pc1
	    LEFT JOIN
		    (
			    SELECT   ParentId, COUNT(*) AS ChildrenCount
			    FROM     MenuUser
			    Group By (ParentId)
		    ) as pc2
	    ON
		    pc1.MenuUserId = pc2.ParentId
	    WHERE isnull(pc1.parentId,0) = {1} and IsActive = 1 order by Priority ", typeOfControl, parentId);
            var data = new DataHelper();
            return data.ExecuteSQL(query);
        }
    }
}