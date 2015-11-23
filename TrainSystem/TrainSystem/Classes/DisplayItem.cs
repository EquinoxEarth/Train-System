using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    class DisplayItem
    {
        private Boolean canSelect;
        private int id;
        private static int currentId;

        static DisplayItem()
        {
            currentId = 0;
        }

        public DisplayItem(Boolean canSelect)
        {
            this.canSelect = canSelect;
            this.id = DisplayItem.currentId;
            DisplayItem.currentId++;
        }

        public int GetId()
        {
            return this.id;
        }

        public Boolean CanSelect()
        {
            return canSelect;
        }

        public abstract void remove();

        public override Boolean Equals(DisplayItem s)
        {
            if (this.id == s.GetId())
            {
                return true;
            }
            return false;
        }
    }
}
