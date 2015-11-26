using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.Classes
{
    abstract class ASystem
    {
        private List<RecordedItem> selected;
        private List<Record> records;

        public ASystem()
        {
            selected = new List<RecordedItem>();
            records = new List<Record>();
        }

        public abstract Boolean AddRecord(String str);

        public void AddToRecords(Record r)
        {
            records.Add(r);
        }

        /// <summary>
        /// Gets all the records while removing the ones that have been removed previously.
        /// </summary>
        /// <returns></returns>
        public List<Record> GetAllRecords()
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
                    foreach (Record res in ((RecordedItem)d).GetRecords())
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
        /// Record objects and are of the type provided.  Is used by Select to get DisplayItem objects
        /// that are relevant to what has been selected.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private List<DisplayItem> GetRelatedItems(Type t)
        {
            List<DisplayItem> result = new List<DisplayItem>();
            foreach (Record s in records)
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
