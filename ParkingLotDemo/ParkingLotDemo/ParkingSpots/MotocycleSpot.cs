using System;

namespace ParkingLotDemo
{
	public class MotocycleSpot : ParkingSpot
	{
		public override decimal HourlyRate { get; set; } = 8;


		public override bool CanPark(Vehicle vehicle)
		{
			if (IsAvailable && vehicle is Motocycle)
			{
				return true;
			}
			else return false;
		}
	}
}