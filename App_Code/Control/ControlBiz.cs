using System.Collections.Generic;
using BIC.DAO;
using BIC.Entity;

namespace BIC.Biz
{
    public class ControlBiz : BaseControl
    {
        /// <summary>
        /// Create a new Control
        /// </summary>
        public static bool InsertControl(ControlEntity controlEntity)
        {
            var controlDA0 = new ControlDAO();
            bool ret = controlDA0.InsertControl(controlEntity);
            PurgeCacheItems("Control_Control");
            return ret;
        }

        /// <summary>
        /// Update a ControlEntity
        /// </summary>
        public static bool UpdateControl(ControlEntity controlEntity)
        {
            var controlDA0 = new ControlDAO();
            bool ret = controlDA0.UpdateControl(controlEntity);
            PurgeCacheItems("Control_Control_" + controlEntity.ControlID);
            PurgeCacheItems("Control_Control");
            return ret;
        }

        /// <summary>
        /// Delete a ControlEntity
        /// </summary>
        public static bool DeleteControl(int _ControlID)
        {
            var controlDA0 = new ControlDAO();
            bool ret = controlDA0.DeleteControl(_ControlID);
            PurgeCacheItems("Control_Control");
            return ret;
        }

        /// <summary>
        /// Returns an existing Control with the specified ID
        /// </summary>
        public static ControlEntity GetControlByID(int _ControlID)
        {
            ControlEntity controlEntity = null;
            string key = "Control_Control_" + _ControlID;
            if (Cache[key] != null)
            {
                controlEntity = (ControlEntity) Cache[key];
            }
            else
            {
                var controlDA0 = new ControlDAO();
                controlEntity = controlDA0.GetControlByID(_ControlID);
                CacheData(key, controlEntity);
            }
            return controlEntity;
        }

        /// <summary>
        /// Returns a collection with all the Controls
        /// </summary>
        public static List<ControlEntity> GetAllControls()
        {
            List<ControlEntity> ControlsEntity = null;
            string key = "Control_Control";

            if (Cache[key] != null)
            {
                ControlsEntity = (List<ControlEntity>) Cache[key];
            }
            else
            {
                var controlDA0 = new ControlDAO();
                ControlsEntity = controlDA0.GetAllControls();
                CacheData(key, ControlsEntity);
            }
            return ControlsEntity;
        }
    }
}