using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    /// <summary>
    /// Contains all runtime variables and commands used in the Train Management System
    /// </summary>
    class TSystem
    {
        private List<RecordedItem> selected;
        private List<ScheduleRecord> records;
        private List<Train> trains;
        private List<Schedule> schedules;
        private List<Station> stations;
        private List<Direction> directions;
        private String mode;
        private int step;

        public TSystem()
        {
            selected = new List<RecordedItem>();
            records = new List<ScheduleRecord>();
            trains = new List<Train>();
            schedules = new List<Schedule>();
            stations = new List<Station>();
            directions = new List<Direction>();
            mode = "Schedules";
            step = 0;
        }

        public Train GetOrCreateTrain(String name)
        {
            Train result = null;
            foreach (Train t in trains)
            {
                if (t.GetName().Equals(name))
                {
                    result = t;
                }
            }
            if (result == null)
            {
                result = new Train(name);
            }
            return result;
        }
    }
}
