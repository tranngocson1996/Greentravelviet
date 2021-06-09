using BIC.Biz;
using BIC.Entity;
using BIC.Utils;

namespace BIC.Components
{
    public class ActionType
    {
        public string QueryName { get; set; }
        public string ActionName { get; set; }

        public static string GetActionName()
        {
            string result = string.Empty;
            string _query = BicHtml.GetRequestString("action");
            switch (_query)
            {
                case "add":
                    result = "Addition";
                    break;
                case "edit":
                    result = "Edition";
                    break;
                case "list":
                    result = "Listing";
                    break;
                case "view":
                    result = "View";
                    break;
                case "del":
                    result = "Deletion";
                    break;
                default:
                    result = "Listing";
                    break;
            }
            return result;
        }

        public static string GetActionName(string _query)
        {
            string result = string.Empty;
            switch (_query)
            {
                case "add":
                    result = "Addition";
                    break;
                case "edit":
                    result = "Edition";
                    break;
                case "list":
                    result = "Listing";
                    break;
                case "view":
                    result = "View";
                    break;
                default:
                    result = "Listing";
                    break;
            }
            return result;
        }

        public static string GetControl()
        {
            string result = string.Empty;
            int controlid = BicHtml.GetRequestString("cid", 0);
            if (controlid != 0)
            {
                ControlEntity controlentity = ControlBiz.GetControlByID(controlid);
                string[] arrPath = controlentity.FolderName.Split(new[] {'/'});
                if (string.IsNullOrEmpty(controlentity.ControlUrl))
                {
                    result = BicApplication.URLRoot + "admin/Components/" + controlentity.FolderName + "/"
                             + GetActionName() + arrPath[arrPath.Length - 1] + ".ascx";
                }
                else
                    result = controlentity.ControlUrl;
            }
            return result;
        }

        public static string GetControl(string _query, int controlid)
        {
            string result = string.Empty;
            if (controlid != 0)
            {
                ControlEntity controlentity = ControlBiz.GetControlByID(controlid);
                result = BicApplication.URLRoot + "admin/Components/" + controlentity.FolderName + "/"
                         + GetActionName(_query) + controlentity.FolderName + ".ascx";
            }
            return result;
        }
    }
}