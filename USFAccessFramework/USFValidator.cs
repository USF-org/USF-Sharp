namespace USFAccessFramework
{
    public class USFValidator
    {
        public static bool IsValidUSF(USF usf)
        {
            return usf != null &&
                   usf.Version > 0 &&
                   usf.Subjects != null && usf.Subjects.Count > 0 &&
                   usf.Periods != null && usf.Periods.Count > 0 &&
                   usf.Timetable != null && usf.Timetable.Count > 0;
        }
    }
}
