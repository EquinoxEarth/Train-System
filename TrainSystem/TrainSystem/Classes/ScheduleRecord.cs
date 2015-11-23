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

        /// <summary>
        /// Gets all the RecordedItem objects that are related to this ScheduleRecord and returns them.
        /// </summary>
        /// <returns></returns>
        public List<RecordedItem> GetRelated()
        {
            List<RecordedItem> result = new List<RecordedItem>();
            result.Add(schedule);
            result.Add(station);
            result.Add(train);
            result.Add(dir);
            return result;
        }

        /// <summary>
        /// Used to help sort the records.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a string that can be used in a sequential file.
        /// </summary>
        /// <returns></returns>
        public string GetRecordToSave()
        {
            return schedule + "," + station + "," + train + "," + dir + "," + time.ToString();
        }

        /// <summary>
        /// Returns the time in the 24 hour clock format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (time / 60) + ": " + ((time % 60) / 10) + (time % 10) ;
        }
    }
}
