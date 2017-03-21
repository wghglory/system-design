using System;


namespace ParkingLotDemo
{
	public abstract class Vehicle
	{
		public Vehicle()
		{
			License = Helper.RandomString(7);
		}

		public string License { get; set; }
		public Certificate Certificate { get; set; }

		public virtual void Park(ParkingSpot ps)
		{
			if (ps.CanPark(this))
			{
				Console.WriteLine($"Vehicle {License} parked at spot {ps.SpotNumber}");
				ParkingLot.UsedSpots.Add(this.License, ps);
				ps.IsAvailable = false;
				// todo: remove available list

				Certificate.StartTime = DateTime.Now;
			}
			else
			{
				Console.WriteLine($"Vehicle {License} cannot park at spot {ps.SpotNumber}");
			}
		}
		public abstract void Unpark();

		public virtual void Run()
		{
			Console.WriteLine("Vehicle is running");
		}
		public virtual void Stop()
		{
			Console.WriteLine("Vehicle is stopping");
		}


		public virtual decimal Pay(Certificate cf)
		{
			ParkingSpot ps = ParkingLot.UsedSpots[this.License];
			return ps.HourlyRate * ((cf.LeaveTime - cf.StartTime).Hours);
		}
	}
}
