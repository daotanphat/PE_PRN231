using System;
using System.Collections.Generic;

namespace GivenAPIs.Models
{
	public class DataGeneration
	{
		public static List<Room> Rooms = new List<Room>
        {
            new Room { Id = 1, Title = "Room A", Capacity = 150 },
            new Room { Id = 2, Title = "Room B", Capacity = 200 },
            new Room { Id = 3, Title = "Room C", Capacity = 120 },
            new Room { Id = 4, Title = "Room D", Capacity = 180 },
            new Room { Id = 5, Title = "Room E", Capacity = 160 },
        };

        public static List<TimeSlot> TimeSlots = new List<TimeSlot>
        {
            new TimeSlot { Id = 1, StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("11:00:00") },
            new TimeSlot { Id = 2, StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
            new TimeSlot { Id = 3, StartTime = TimeSpan.Parse("15:00:00"), EndTime = TimeSpan.Parse("17:00:00") },
            new TimeSlot { Id = 4, StartTime = TimeSpan.Parse("18:00:00"), EndTime = TimeSpan.Parse("20:00:00") },
            new TimeSlot { Id = 5, StartTime = TimeSpan.Parse("21:00:00"), EndTime = TimeSpan.Parse("23:00:00") },
        };

        public static List<Schedule> Schedules = new List<Schedule>
        {
            new Schedule(281, 1, 1, 1, new DateTime(2023, 10, 01), new DateTime(2023, 10, 08), "Special screening"),
            new Schedule(282, 1, 2, 2, new DateTime(2023, 10, 09), new DateTime(2023, 10, 16), "Regular screening"),
            new Schedule(283, 1, 3, 3, new DateTime(2023, 10, 17), new DateTime(2023, 10, 24), "Matinee show"),
            new Schedule(284, 2, 1, 3, new DateTime(2023, 10, 18), new DateTime(2023, 10, 25), "Special event"),
            new Schedule(285, 2, 4, 1, new DateTime(2023, 10, 02), new DateTime(2023, 10, 09), "Opening night"),
            new Schedule(286, 2, 5, 2, new DateTime(2023, 10, 10), new DateTime(2023, 10, 17), "Matinee show"),
            new Schedule(287, 3, 1, 5, new DateTime(2023, 10, 11), new DateTime(2023, 10, 18), "Special event"),
            new Schedule(288, 3, 2, 1, new DateTime(2023, 10, 19), new DateTime(2023, 10, 26), "Regular screening"),
            new Schedule(289, 3, 5, 4, new DateTime(2023, 10, 03), new DateTime(2023, 10, 10), "Exclusive premiere"),
            new Schedule(290, 4, 1, 4, new DateTime(2023, 10, 20), new DateTime(2023, 10, 27), "Special screening"),
            new Schedule(291, 4, 2, 3, new DateTime(2023, 10, 12), new DateTime(2023, 10, 19), "Matinee show"),
            new Schedule(292, 4, 3, 2, new DateTime(2023, 10, 04), new DateTime(2023, 10, 11), "Regular screening"),
            new Schedule(293, 5, 1, 1, new DateTime(2023, 10, 18), new DateTime(2023, 10, 22), "Opening night"),
            new Schedule(294, 5, 3, 2, new DateTime(2023, 10, 26), new DateTime(2023, 10, 30), "Special screening"),
            new Schedule(295, 5, 4, 3, new DateTime(2023, 10, 21), new DateTime(2023, 10, 25), "Regular screening"),
            new Schedule(296, 6, 2, 4, new DateTime(2023, 10, 16), new DateTime(2023, 10, 20), "Special screening"),
            new Schedule(297, 6, 3, 5, new DateTime(2023, 10, 24), new DateTime(2023, 10, 30), "Regular screening"),
            new Schedule(298, 6, 4, 1, new DateTime(2023, 11, 22), new DateTime(2023, 11, 29), "Exclusive premiere"),
            new Schedule(299, 7, 1, 3, new DateTime(2023, 10, 26), new DateTime(2023, 10, 30), "Matinee show"),
            new Schedule(300, 7, 2, 4, new DateTime(2023, 11, 23), new DateTime(2023, 11, 30), "Special event"),
            new Schedule(301, 7, 5, 2, new DateTime(2023, 10, 18), new DateTime(2023, 10, 24), "Regular screening"),
            new Schedule(302, 8, 2, 1, new DateTime(2023, 10, 08), new DateTime(2023, 10, 15), "Opening night"),
            new Schedule(303, 8, 4, 2, new DateTime(2023, 10, 16), new DateTime(2023, 10, 23), "Regular screening"),
            new Schedule(304, 8, 5, 3, new DateTime(2023, 10, 24), new DateTime(2023, 10, 31), "Special screening"),
            new Schedule(305, 9, 2, 2, new DateTime(2023, 10, 25), new DateTime(2023, 11, 01), "Regular screening"),
            new Schedule(306, 9, 4, 4, new DateTime(2023, 10, 09), new DateTime(2023, 10, 16), "Special screening"),
            new Schedule(307, 9, 5, 5, new DateTime(2023, 10, 17), new DateTime(2023, 10, 24), "Exclusive premiere"),
            new Schedule(308, 10, 1, 1, new DateTime(2023, 10, 10), new DateTime(2023, 10, 17), "Matinee show"),
            new Schedule(309, 10, 3, 2, new DateTime(2023, 10, 18), new DateTime(2023, 10, 25), "Special event"),
            new Schedule(310, 10, 4, 3, new DateTime(2023, 10, 26), new DateTime(2023, 11, 02), "Opening night"),
        };
        public static List<Movie> Movies = new List<Movie>
        {
            new Movie{Id=1, Title="Inception"},
            new Movie{Id=2, Title="Pulp Fiction"},
            new Movie{Id=3, Title="Little Women"},
            new Movie{Id=4, Title="The Revenant"},
            new Movie{Id=5, Title="Avatar"},
            new Movie{Id=6, Title="The Avengers"},
            new Movie{Id=7, Title="The Dark Knight"},
            new Movie{Id=8, Title="Jurassic Park"},
            new Movie{Id=9, Title="The Godfather"},
            new Movie{Id=10, Title="E.T. the Extra-Terrestrial"}
        };
    }
}

