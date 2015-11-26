using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    abstract class Record: DisplayItem
    {
        private Boolean removed;

        public Record()
            : base(false)
        {

        }

        public abstract List<RecordedItem> GetRelated();

        public Boolean IsRemoved()
        {
            return removed;
        }

        public override void remove()
        {
            removed = true;
        }

        public abstract String GetRecordToSave();

        public abstract String ToString();

        public abstract int SortValue();
    }
}
