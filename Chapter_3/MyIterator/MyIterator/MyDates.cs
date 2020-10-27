using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    public class MyDates
    {
        private DateTime StartDate = Convert.ToDateTime("2020-1-1");
        private DateTime EndDate = Convert.ToDateTime("2020-2-1");
        public IEnumerable<DateTime> DateRange
        {
            get
            {
                for (DateTime day = StartDate;
                     day <= EndDate;
                     day = day.AddDays(1))
                {
                    yield return day;
                }
            }
        }
    }
}
