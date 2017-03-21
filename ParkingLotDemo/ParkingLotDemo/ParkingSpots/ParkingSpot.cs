using System;

namespace ParkingLotDemo
{
	public abstract class ParkingSpot
	{
		public int SpotNumber { get; set; }
		public abstract decimal HourlyRate { get; set; }  //strategy pattern, different types of spots different price
		public bool IsAvailable { get; set; } = true;


		public void Tow(Vehicle vehicle)
		{
			Console.WriteLine($"Vehicle {vehicle.License} towed away");
		}


		public abstract bool CanPark(Vehicle vehicle);


	}
}