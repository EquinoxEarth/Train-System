using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    class ScheduleRecord: DisplayItem
    {
        private Boolean removed;
        public ScheduleRecord()
            : base(false)
        {
            this.removed = false;
        }
    }
}
