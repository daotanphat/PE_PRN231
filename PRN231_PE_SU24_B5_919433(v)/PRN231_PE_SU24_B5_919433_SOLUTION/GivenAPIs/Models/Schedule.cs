using System;
using System.Collections.Generic;

namespace GivenAPIs.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public int? TimeSlotId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Note { get; set; }

        public Schedule(int id, int movieId, int roomId, int? timeSlotId, DateTime startDate, DateTime endDate, string? note)
        {
            Id = id;
            MovieId = movieId;
            RoomId = roomId;
            TimeSlotId = timeSlotId;
            StartDate = startDate;
            EndDate = endDate;
            Note = note;
        }
    }
}
