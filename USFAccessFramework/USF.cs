using System;
using System.Collections.Generic;

namespace USFAccessFramework
{
    public class USF
    {
        public int Version { get; set; }
        public Dictionary<string, Subject> Subjects { get; set; } = new Dictionary<string, Subject>();
        public List<List<string>> Periods { get; set; } = new List<List<string>>();
        public List<List<object>> Timetable { get; set; } = new List<List<object>>();

        public class Subject
        {
            public required string SimplifiedName { get; set; }
            public required string Teacher { get; set; }
            public required string Room { get; set; }
        }
    }
}
