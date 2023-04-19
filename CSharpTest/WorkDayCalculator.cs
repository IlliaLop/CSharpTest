using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (startDate == null)
            {
                throw new ArgumentNullException(nameof(startDate));
            }

            if (dayCount == 0)
            {
                throw new ArgumentException(nameof(dayCount));
            }

            DateTime result = startDate;
            for (int i = dayCount; 0 < i;)
            {
                int AmmountOfWeekEnds = 0, lichilnik = 0;
                for (int j = 0; j < weekEnds.Length; j++)
                {
                    for (DateTime f = weekEnds[j].StartDate; f != weekEnds[j].EndDate.AddDays(1); f = f.AddDays(1))
                    {
                        AmmountOfWeekEnds++;
                        if (result != f)
                        {
                            lichilnik++;
                        }
                    }
                    if (lichilnik == AmmountOfWeekEnds)
                    {
                        lichilnik = 0;
                        AmmountOfWeekEnds = 0;
                    }
                    else break;
                }
                if (AmmountOfWeekEnds == 0)
                {
                    i--;
                }
                if (i != 0)
                {
                    result = result.AddDays(1);
                }
            }
            return result;
        }
    }
}
