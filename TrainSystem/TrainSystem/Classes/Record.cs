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
            : base()
        {

        }

        public abstract List<RecordedItem> GetRelated();

        public Boolean IsRemoved()
        {
            return removed;
        }

        public override void Remove()
        {
            removed = true;
        }

        /// <summary>
        /// Returns the record as it will be written to the file
        /// </summary>
        /// <returns></returns>
        public abstract String GetRecordToSave();
        
        /// <summary>
        /// Used to help sort the records.
        /// </summary>
        /// <returns></returns>
        public abstract int SortValue();
    }
}
