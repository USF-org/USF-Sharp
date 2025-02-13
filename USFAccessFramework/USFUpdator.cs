namespace USFAccessFramework
{
    public class USFUpdater
    {
        public static void AddSubject(ref USF usf, string name, string simplifiedName, string teacher, string room)
        {
            var newSubject = new USF.Subject
            {
                SimplifiedName = simplifiedName,
                Teacher = teacher,
                Room = room
            };
            usf.Subjects[name] = newSubject;
        }

        public static void AddTimetableEntry(ref USF usf, int day, string weekType, string subjectName, int period)
        {
            var newEntry = new List<object> { day, weekType, subjectName, period };
            usf.Timetable.Add(newEntry);
        }
    }
}
