using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    class ScheduleRecord: Record
    {
        private Schedule schedule;
        private Station station;
        private Train train;
        private Direction dir;
        private int time;

        public ScheduleRecord(Schedule schedule, Station station, Train train, Direction dir, int time)
            : base()
        {
            this.schedule = schedule;
            this.station = station;
            this.train = train;
            this.dir = dir;
        }

        /// <summary>
        /// Gets all the RecordedItem objects that are related to this ScheduleRecord and returns them.
        /// </summary>
        /// <returns></returns>
        public override List<RecordedItem> GetRelated()
        {
            List<RecordedItem> result = new List<RecordedItem>();
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

        public override int SortValue()
        {
            return time;
        }

        /// <summary>
        /// Returns a string that can be used in a sequential file.
        /// </summary>
        /// <returns></returns>
        public override string GetRecordToSave()
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
