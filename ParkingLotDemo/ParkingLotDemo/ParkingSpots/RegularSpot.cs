using System;
namespace ParkingLotDemo
{
	public class RegularSpot : ParkingSpot
	{

		public override decimal HourlyRate { get; set; } = 8;

		public override bool CanPark(Vehicle vehicle)
		{
			if (IsAvailable)  //anycar can park
			{
				return true;
			}
			else return false;

		}
	}
}
