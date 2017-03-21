using System;
using System.Collections.Generic;

namespace ParkingLotDemo
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			ParkingLot pl = ParkingLot.GetInstance();
			List<ParkingSpot> allAvailableSpots = pl.FindAvailableSpots();

			Car car1 = new Car();
			Car car2 = new Car();
			Car car3 = new Car();

			Motocycle m1 = new Motocycle();

			HandicapCar h1 = new HandicapCar();

			if (allAvailableSpots.Count != 0)
			{
				car1.Park(allAvailableSpots[499]);  //cannot park at wrong place althougth it's empty
				car2.Park(allAvailableSpots[99]);   //park
				car3.Park(allAvailableSpots[99]);   //cannot park because car2 is there

				car2.Unpark();
				car3.Park(allAvailableSpots[99]);


				m1.Park(allAvailableSpots[422]);

				h1.Park(allAvailableSpots[433]);
				h1.Unpark();
			}
			Console.ReadKey();
		}
	}
}
