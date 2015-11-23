using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    class RecordedItem: DisplayItem
    {
        private String name;
        private List<ScheduleRecord> records;

        public RecordedItem(String name)
            : base(true)
        {
            this.name = name;
        }

        public String GetName()
        {
            return name;
        }

        public void AddRecord(ScheduleRecord s)
        {
            Boolean inserted = false;
            foreach (ScheduleRecord s2 in records)
            {
                if (!inserted && s2.GetTime() > s.GetTime())
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

        public void RemoveRecord(ScheduleRecord s)
        {
            records.Remove(s);
            s.remove();
        }

        public List<ScheduleRecord> GetRecords()
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
        /// Makes sure that all records associated with this RecordedItem are set to removed.
        /// </summary>
        public override void remove()
        {
            foreach (ScheduleRecord s in records)
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
