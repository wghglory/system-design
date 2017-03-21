using System;

namespace ParkingLotDemo
{
	public class HandicapSpot : ParkingSpot
	{
		public override decimal HourlyRate { get; set; } = 5;

		public override bool CanPark(Vehicle vehicle)
		{
			if (IsAvailable && vehicle is HandicapCar)
			{
				return true;
			}
			else return false;
		}
	}
}