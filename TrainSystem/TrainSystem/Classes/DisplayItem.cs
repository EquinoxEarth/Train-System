using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    abstract class DisplayItem
    {
        private int id;
        private static int currentId;

        /// <summary>
        /// Initializes the id number that will be used by all DisplayItems to identify themselves.
        /// </summary>
        static DisplayItem()
        {
            currentId = 0;
        }

        public DisplayItem()
        {
            this.id = DisplayItem.currentId;
            DisplayItem.currentId++;
        }

        public int GetId()
        {
            return this.id;
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
            if (s is DisplayItem && this.id == ((DisplayItem)s).GetId())
            {
                return true;
            }
            return false;
        }
    }
}
