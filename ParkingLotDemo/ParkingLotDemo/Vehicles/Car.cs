using System;
namespace ParkingLotDemo
{
	public class Car : Vehicle
	{

		public override void Park(ParkingSpot ps)
		{
			if (ps.CanPark(this))
			{
				Console.WriteLine($"Car {License} parked at spot {ps.SpotNumber}");
				ParkingLot.UsedSpots.Add(this.License, ps);
				ps.IsAvailable = false;
				// todo: remove available list

				Certificate = new Certificate();
				Certificate.StartTime = DateTime.Now;

			}
			else
			{
				Console.WriteLine($"Car {License} cannot park at spot {ps.SpotNumber}");
			}
		}

		public override void Run()
		{
			Console.WriteLine("Car running");
		}

		public override void Stop()
		{
			Console.WriteLine("Car stopped");
		}

		public override void Unpark()
		{
			ParkingSpot ps = ParkingLot.UsedSpots[this.License];
			ps.IsAvailable = true;

			Certificate.LeaveTime = DateTime.Now.AddHours(2);

			Console.WriteLine($"Car {License} unparked from spot {ps.SpotNumber}");
			Console.WriteLine($"Car {License} should pay ${this.Pay(Certificate)}");

			ParkingLot.UsedSpots.Remove(this.License);
		}
	}
}
