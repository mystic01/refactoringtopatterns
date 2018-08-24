using System.Collections;
using System.Collections.Generic;

namespace RefactoringToPatterns_Command.MyWork
{
    public class WorkshopRepository : IEnumerable<Workshop>
    {
        public List<Workshop> _workshops = new List<Workshop>();

        public IEnumerator<Workshop> GetEnumerator()
        {
            return _workshops.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddWrokshop(Workshop workshop)
        {
            _workshops.Add(workshop);
        }
    }
}