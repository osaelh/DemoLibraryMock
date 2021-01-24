using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary.Models
{
    class EventModel
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAT { get; set; }
        public string Comment { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
