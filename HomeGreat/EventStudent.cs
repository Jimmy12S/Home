using System;
using System.Collections.Generic;
using System.Text;

namespace HomeGreat.Model
{
    public class EventStudent
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
