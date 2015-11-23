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
        private Schedule schedule;
        private Station station;
        private Train train;
        private Direction dir;
        private int time;

        public ScheduleRecord(Schedule schedule, Station station, Train train, Direction dir, int time)
            : base(false)
        {
            this.schedule = schedule;
            this.station = station;
            this.train = train;
            this.dir = dir;
            this.removed = false;
        }

        public List<DisplayItem> GetRelated()
        {
            List<DisplayItem> result = new List<DisplayItem>();
            result.Add(schedule);
            result.Add(station);
            result.Add(train);
            result.Add(dir);
            return result;
        }

        public int GetTime()
        {
            return time;
        }

        public Boolean IsRemoved()
        {
            return removed;
        }

        public override void remove()
        {
            removed = true;
        }

        public string GetRecordToSave()
        {
            return schedule + "," + station + "," + train + "," + dir + "," + time.ToString();
        }

        public override string ToString()
        {
            return this.time.ToString();
        }
    }
}
