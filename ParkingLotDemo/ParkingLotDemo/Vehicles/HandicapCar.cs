using System;
namespace ParkingLotDemo
{
	public class HandicapCar : Vehicle
	{

		public override void Park(ParkingSpot ps)
		{
			if (ps.CanPark(this))
			{
				Console.WriteLine($"HandicapCar {License} parked at spot {ps.SpotNumber}");
				ParkingLot.UsedSpots.Add(this.License, ps);
				ps.IsAvailable = false;
				// todo: remove available list

				Certificate = new Certificate();
				Certificate.StartTime = DateTime.Now;

			}
			else
			{
				Console.WriteLine($"HandicapCar {License} cannot park at spot {ps.SpotNumber}");
			}
		}

		public override void Run()
		{
			Console.WriteLine("HandicapCar running");
		}

		public override void Stop()
		{
			Console.WriteLine("HandicapCar stopped");
		}

		public override void Unpark()
		{
			ParkingSpot ps = ParkingLot.UsedSpots[this.License];
			ps.IsAvailable = true;

			Certificate.LeaveTime = DateTime.Now.AddHours(2);

			Console.WriteLine($"HandicapCar {License} unparked from spot {ps.SpotNumber}");
			Console.WriteLine($"HandicapCar {License} should pay ${this.Pay(Certificate)}");

			ParkingLot.UsedSpots.Remove(this.License);
		}
	}
}
