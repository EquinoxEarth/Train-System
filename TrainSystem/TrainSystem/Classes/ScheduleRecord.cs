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
        private int time, id;
        private static int currentId;

        static ScheduleRecord()
        {
            currentId = 0;
        }

        public ScheduleRecord(int time)
            : base(false)
        {
            this.removed = false;
            this.id = ScheduleRecord.currentId;
            ScheduleRecord.currentId++;
        }

        public int GetTime()
        {
            return time;
        }

        public Boolean IsRemoved()
        {
            return removed;
        }

        public int GetId()
        {
            return this.id;
        }

        public void remove()
        {
            removed = true;
        }

        public override Boolean Equals(ScheduleRecord s)
        {
            if (this.id == s.GetId())
            {
                return true;
            }
            return false;
        }
    }
}
