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
    }
}
