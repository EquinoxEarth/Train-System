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
    class TSystem: ASystem
    {
        private List<Train> trains;
        private List<Schedule> schedules;
        private List<Station> stations;
        private List<Direction> directions;

        /// <summary>
        /// Creates an instance of the Train Data Manager
        /// </summary>
        public TSystem()
        {
            trains = new List<Train>();
            schedules = new List<Schedule>();
            stations = new List<Station>();
            directions = new List<Direction>();
        }

        /// <summary>
        /// Finds a Train with the supplied name, if it can't find one it creates one with the supplied name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Train that was found/created</returns>
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

        /// <summary>
        /// Finds a Station with the supplied name, if it can't find one it creates one with the supplied name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Station that was found/created</returns>
        public Station GetOrCreateStation(String name)
        {
            Station result = null;
            foreach (Station t in stations)
            {
                if (t.GetName().Equals(name))
                {
                    result = t;
                }
            }
            if (result == null)
            {
                result = new Station(name);
            }
            return result;
        }

        /// <summary>
        /// Finds a Schedule with the supplied name, if it can't find one it creates one with the supplied name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Schedule that was found/created</returns>
        public Schedule GetOrCreateSchedule(String name)
        {
            Schedule result = null;
            foreach (Schedule t in schedules)
            {
                if (t.GetName().Equals(name))
                {
                    result = t;
                }
            }
            if (result == null)
            {
                result = new Schedule(name);
            }
            return result;
        }

        /// <summary>
        /// Finds a Direction with the supplied name, if it can't find one it creates one with the supplied name
        /// </summary>
        /// <param name="name">Name to search for</param>
        /// <returns>Direction that was found/created</returns>
        public Direction GetOrCreateDirection(String name)
        {
            Direction result = null;
            foreach (Direction t in directions)
            {
                if (t.GetName().Equals(name))
                {
                    result = t;
                }
            }
            if (result == null)
            {
                result = new Direction(name);
            }
            return result;
        }

        /// <summary>
        /// Given a record as a comma delimited string it will add the record
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public override bool AddRecord(string str)
        {
            string[] fields = str.Split(',');
            if (fields.Length == 5)
            {
                base.AddToRecords(this.AddRecord(fields[0], fields[1], fields[2], fields[3], Convert.ToInt32(fields[4])));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Creates or gets the necessary schedule, station, train, direction, and scheduleRecord and
        /// adds them all to their necessary lists.
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="station"></param>
        /// <param name="train"></param>
        /// <param name="direction"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Record AddRecord(String schedule, String station, String train, String direction, int time)
        {
            
            Schedule s = GetOrCreateSchedule(schedule);
            Station s2 = GetOrCreateStation(station);
            Train t = GetOrCreateTrain(train);
            Direction d = GetOrCreateDirection(direction);
            ScheduleRecord rec = new ScheduleRecord(s, s2, t, d, time);
            s.AddRecord(rec);
            s2.AddRecord(rec);
            t.AddRecord(rec);
            d.AddRecord(rec);
            return rec;
        }
    }
}
