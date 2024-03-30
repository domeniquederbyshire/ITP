using System;

namespace ITP.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public double EventValue { get; set; }
        public string EventDateFormatted { get; set; }
    }
}