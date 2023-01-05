using System;
using Microsoft.EntityFrameworkCore;
namespace HotelProj.Models;
	public class RoomContext : DbContext
	{
		public RoomContext(DbContextOptions<RoomContext> options) : base(options)
		{
		}

	public DbSet<Room> Rooms { get; set; } = null!;
	public DbSet<PersonalInfo> PersonalInfos { get; set; } = null!;
    public DbSet<Prenotation> prenotations { get; set; } = null!;

}


