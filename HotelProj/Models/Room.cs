using System;
namespace HotelProj.Models;

public class Room
{
	public long Id { get; set; }
    public string? RoomName { get; set; }
    public string? RoomType { get; set; }
    public double RoomPrice { get; set; }
    public string? Thumbnails { get; set; }
}

