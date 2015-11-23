using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    class RecordedItem: DisplayItem
    {
        private String name;

        public RecordedItem(String name)
            : base(true)
        {
            this.name = name;
        }
    }
}
