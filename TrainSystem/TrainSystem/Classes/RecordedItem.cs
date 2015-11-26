using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    /// <summary>
    /// Super class for Schedule, Station, Train, and Direction. Contains the methods for dealing with
    /// the list of ScheduleRecord objects that is contained in this class.  
    /// </summary>
    class RecordedItem: DisplayItem
    {
        private String name;
        private List<Record> records;

        public RecordedItem(String name)
            : base(true)
        {
            this.name = name;
        }

        public String GetName()
        {
            return name;
        }

        /// <summary>
        /// Adds the records with the earlier records being earlier in the list.
        /// </summary>
        /// <param name="s"></param>
        public void AddRecord(Record s)
        {
            Boolean inserted = false;
            foreach (Record s2 in records)
            {
                if (!inserted && s2.SortValue() > s.SortValue())
                {
                    records.Insert(records.IndexOf(s2), s);
                    inserted = true;
                }
            }
            if (!inserted)
            {
                records.Add(s);
            }            
        }

        public void RemoveRecord(Record s)
        {
            records.Remove(s);
            s.remove();
        }

        /// <summary>
        /// When ever this method is called it checks to see if any of the records in its list have been removed
        /// and if any are they are removed from this objects List of ScheduleRecord objects.
        /// </summary>
        /// <returns></returns>
        public List<Record> GetRecords()
        {
            foreach (Record s in records)
            {
                if (s.IsRemoved())
                {
                    records.Remove(s);
                }
            }
            return records;
        }

        /// <summary>
        /// Makes sure that all records associated with this RecordedItem are set to removed.
        /// </summary>
        public override void remove()
        {
            foreach (Record s in records)
            {
                s.remove();
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
