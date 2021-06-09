using System.Collections.Generic;
using BIC.Entity;

namespace BIC.DAO
{
    public abstract class ControlProvider : DataAccess
    {
        public abstract bool InsertControl(ControlEntity entity);
        public abstract bool UpdateControl(ControlEntity entity);
        public abstract bool DeleteControl(int _ControlID);
        public abstract ControlEntity GetControlByID(int _ControlID);
        public abstract List<ControlEntity> GetAllControls();
    }
}