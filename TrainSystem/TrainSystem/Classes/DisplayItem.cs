using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    abstract class DisplayItem
    {
        private Boolean canSelect;
        private int id;
        private static int currentId;

        /// <summary>
        /// Initializes the id number that will be used by all DisplayItems to identify themselves.
        /// </summary>
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

        /// <summary>
        /// Returns whether or not this class can be selected and used to narrow the possiblities of records
        /// that apply.  Whether or not this is a RecordedItem.
        /// </summary>
        /// <returns></returns>
        public Boolean CanSelect()
        {
            return canSelect;
        }

        public abstract void remove();

        public abstract override string ToString();

        /// <summary>
        /// Used for comparing all DisplayItems to each other.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public override Boolean Equals(Object s)
        {
            if (s.GetType() == typeof(DisplayItem) && this.id == ((DisplayItem)s).GetId())
            {
                return true;
            }
            return false;
        }
    }
}
