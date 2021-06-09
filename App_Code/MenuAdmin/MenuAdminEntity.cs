using System;

namespace BIC.Entity
{
    /// <summary>
    /// Business entity for Category
    /// </summary>
    public class MenuAdminEntity
    {
        #region Attributes

        public const string FIELD_MENUADMINID = "MenuAdminID";
        public const string FIELD_NAME = "Name";
        public const string FIELD_MENUURL = "MenuUrl";
        public const string FIELD_PRIORITY = "Priority";
        public const string FIELD_PARENTID = "ParentID";
        public const string FIELD_CONTROLID = "ControlID";
        public const string FIELD_TARGET = "Target";
        public const string FIELD_ICON = "Icon";
        public const string FIELD_TYPEOFMENU = "TypeOfMenu";
        public const string FIELD_DESCRIPTION = "Description";
        public const string FIELD_NAVIGATEPATH = "NavigatePath";
        public const string FIELD_ISACTIVE = "IsActive";
        public const string FIELD_KEYBOARD = "KeyBoard";

        #endregion

        #region Contructors

        public MenuAdminEntity()
        {
        }

        public MenuAdminEntity(int menuAdminId, string name, string menuUrl, int priority, int parentId,
                               int controlId, string target, string icon, int typeOfMenu, string description,
                               string navigatePath, bool isActive, string keyBoard)
        {
            MenuAdminID = menuAdminId;
            Name = name;
            MenuUrl = menuUrl;
            Priority = priority;
            ParentID = parentId;
            ControlID = controlId;
            Target = target;
            Icon = icon;
            TypeOfMenu = typeOfMenu;
            Description = description;
            NavigatePath = navigatePath;
            IsActive = isActive;
            KeyBoard = keyBoard;
        }

        #endregion

        public int MenuAdminID { get; set; }
 
        
        private string _Name = String.Empty;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _MenuUrl = String.Empty;
        public string MenuUrl
        {
            get { return _MenuUrl; }
            set { _MenuUrl = value; }
        }

        public int Priority { get; set; }

  
        public int ParentID { get; set; }



 
        public int ControlID { get; set; }




        private string _Target = String.Empty;


        public string Target
        {
            get { return _Target; }
            set { _Target = value; }
        }

        private string _Icon = String.Empty;

        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }

    

        public int TypeOfMenu { get; set; }
        
        private string _Description = String.Empty;

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }




        public string NavigatePath { get; set; }
        public bool IsActive { get; set; }
        public string KeyBoard { get; set; }
  
    }
}