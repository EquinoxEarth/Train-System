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

        /// <summary>
        /// Creates an instance of the Train Data Manager
        /// </summary>
        public TSystem()
        {
            selected = new List<RecordedItem>();
            trains = new List<Train>();
            schedules = new List<Schedule>();
            stations = new List<Station>();
            directions = new List<Direction>();
            records = new List<ScheduleRecord>();
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
        /// Creates or gets the necessary schedule, station, train, direction, and scheduleRecord and
        /// adds them all to their necessary lists.
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="station"></param>
        /// <param name="train"></param>
        /// <param name="direction"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public Boolean AddRecord(String schedule, String station, String train, String direction, int time)
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
            records.Add(rec);
            return true;
        }
        /// <summary>
        /// Gets all the records while removing the ones that have been removed previously.
        /// </summary>
        /// <returns></returns>
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
        /// <param name="d"></param>
        /// <param name="typeToShow"></param>
        /// <param name="showTimes"></param>
        /// <returns></returns>
        public List<DisplayItem> Select(DisplayItem d, Type typeToShow, Boolean showTimes)
        {
            List<DisplayItem> result = new List<DisplayItem>();
            if (d != null && d.CanSelect())
            {
                if (showTimes)
                {
                    selected.Add((RecordedItem)d);
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
                    result = GetRelatedItems(typeToShow);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns to the previous options for selections if possible.
        /// </summary>
        /// <returns></returns>

        public List<DisplayItem> PreviousSelection()
        {
            if (selected.Count > 0)
            {
                RecordedItem r = selected[selected.Count - 1];
                selected.Remove(r);
                return GetRelatedItems(r.GetType());
            }
            return null;
        }

        /// <summary>
        /// Returns a list of DisplayItem objects that are actually all RecordedItem objects that share similar
        /// ScheduleRecord objects and are of the type provided.  Is used by Select to get DisplayItem objects
        /// that are relevant to what has been selected.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private List<DisplayItem> GetRelatedItems(Type t)
        {
            List<DisplayItem> result = new List<DisplayItem>();
            foreach (ScheduleRecord s in records)
            {
                foreach (RecordedItem r in selected)
                {
                    foreach (RecordedItem d in s.GetRelated())
                    {
                        if (d.Equals(r) && !result.Contains(d) && d.GetType() == t)
                        {
                            result.Add(d);
                        }
                    }
                    
                }
            }
            return result;
        }
    }
}
