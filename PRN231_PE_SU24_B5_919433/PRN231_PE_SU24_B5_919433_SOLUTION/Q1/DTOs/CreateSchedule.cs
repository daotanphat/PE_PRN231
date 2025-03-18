using Q1.Models;

namespace Q1.DTOs
{
	public class CreateSchedule
	{
		public int MovieId { get; set; }
		public int RoomId { get; set; }
		public int? TimeSlotId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string? Note { get; set; }
	}
}
