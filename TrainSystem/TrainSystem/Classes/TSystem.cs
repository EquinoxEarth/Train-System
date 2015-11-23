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

        /// <summary>
        /// Creates an instance of the Train Data Manager
        /// </summary>
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

        public Boolean AddRecord(String schedule, String station, String train, String direction, int time)
        {
            ScheduleRecord rec = new ScheduleRecord(time);
            GetOrCreateSchedule(schedule).AddRecord(rec);
            GetOrCreateStation(station).AddRecord(rec);
            GetOrCreateTrain(train).AddRecord(rec);
            GetOrCreateDirection(direction).AddRecord(rec);
            records.Add(rec);
            return true;
        }

        public List<ScheduleRecord> GetAllRecords()
        {
            foreach (ScheduleRecord s in records)
            {
                if (s.IsRemoved())
                {
                    records.Remove(s);
                }
            }
            return records;
        }

        /// <summary>
        /// Given a DisplayItem, a type, and a boolean representing whether or not 
        /// the times should be shown it will return a List of DisplayItem objects of the type
        /// that are related to what DisplayItem was selected and what has been selected before hand.
        /// If the boolean is true it will display the records that are shared by all the selected DisplayItems.
        /// </summary>
        /// <param name="selected"></param>
        /// <param name="typeToShow"></param>
        /// <param name="showTimes"></param>
        /// <returns></returns>

        public List<DisplayItem> Select(DisplayItem selected, Type typeToShow, Boolean showTimes)
        {
            List<DisplayItem> result = new List<DisplayItem>();
            if (d.CanSelect())
            {
                if (showTimes)
                {
                    foreach (ScheduleRecord res in ((RecordedItem)d).GetRecords())
                    {
                        Boolean enter = true;
                        foreach (RecordedItem r in selected)
                        {
                            if (!r.GetRecords().Contains(res))
                            {
                                enter = false;
                            }
                        }
                        if (enter && !result.Contains(res))
                        {
                            result.Add(res);
                        }
                    }
                }
                else
                {
                    result = GetRelatedItems(selected, (RecordedItem)d, t);
                }
                selected.Add((RecordedItem)d);
            }
            return result;
        }

        private List<DisplayItem> GetRelatedItems(List<RecordedItem> recs, RecordedItem rec, Type t)
        {
            List<DisplayItem> result = new List<DisplayItem>();
            foreach (RecordedItem r in recs)
            {
                foreach (ScheduleRecord s1 in rec.GetRecords())
                {
                    foreach (ScheduleRecord s2 in r.GetRecords())
                    {
                        if (!result.Contains(r) && s1.Equals(s2) && t == r.GetType())
                        {
                            result.Add(r);
                        }
                    }
                }
            }
            return result;
        }
    }
}
