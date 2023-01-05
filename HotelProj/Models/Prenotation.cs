using System;
namespace HotelProj.Models
{
	public class Prenotation
	{
        public long Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? guestId { get; set; }
        public int? roomId { get; set; }

    }
}

