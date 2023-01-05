using System;
namespace HotelProj.Models;

public enum RoomTypology { Single, Double, Suite };
public class Room
{
	public long Id { get; set; }
    public string? RoomName { get; set; }
    public RoomTypology RoomType { get; set; }
    public double RoomPrice { get; set; }
    public string? Thumbnails { get; set; }
}

