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
        private int time;

        public ScheduleRecord(int time)
            : base(false)
        {
            this.removed = false;
        }

        public int GetTime()
        {
            return time;
        }

        public Boolean IsRemoved()
        {
            return removed;
        }

        public void remove()
        {
            removed = true;
        }
    }
}
