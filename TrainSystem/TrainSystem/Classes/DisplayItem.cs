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

        public DisplayItem(Boolean canSelect)
        {
            this.canSelect = canSelect;
        }

        public abstract void remove();
    }
}
