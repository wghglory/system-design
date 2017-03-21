using System;
using System.Collections.Generic;

namespace ParkingLotDemo
{
	//singleton
	public class ParkingLot
	{
		private ParkingLot() { }

		private static class SingletonInstance
		{
			public static ParkingLot Instance = new ParkingLot();
		}

		public static ParkingLot GetInstance()
		{
			return SingletonInstance.Instance;
		}


		public static List<RegularSpot> AvailableRegularSpots = new List<RegularSpot>();  //car, handicap, motocycle
		public static List<HandicapSpot> AvailableHandicapSpots = new List<HandicapSpot>();  // handicap
		public static List<MotocycleSpot> AvailableMotocycleSpots = new List<MotocycleSpot>();  // motocyle
		public static Dictionary<string, ParkingSpot> UsedSpots = new Dictionary<string, ParkingSpot>();  //use license as key, before i used Vehicle object
		public static List<Level> Levels = new List<Level>();  //5 levels

		static ParkingLot()
		{
			// initilize 5 levels, every level 10 motocyles, 10 handicap, 80 regular spots
			// first level: 100-109 handicap, 110-119 motocycles, 120-199 regular
			// second level: 200-209 handicap, 210-219 motocycles, 220-299 regular ...

			for (int i = 1; i <= 5; i++)
			{
				Level l = new Level();

				HandicapSpot[] handicapSpots = new HandicapSpot[10];
				for (int j = 0; j < handicapSpots.Length; j++)
				{
					handicapSpots[j] = new HandicapSpot()
					{
						SpotNumber = int.Parse(i + "0" + j)
					};

					AvailableHandicapSpots.Add(handicapSpots[j]);
				}

				MotocycleSpot[] motocycleSpots = new MotocycleSpot[10];
				for (int j = 0; j < motocycleSpots.Length; j++)
				{
					motocycleSpots[j] = new MotocycleSpot()
					{
						SpotNumber = int.Parse(i + "1" + j)
					};
					AvailableMotocycleSpots.Add(motocycleSpots[j]);
				}

				RegularSpot[] regularSpots = new RegularSpot[80];
				for (int j = 20; j < regularSpots.Length + 20; j++)
				{
					regularSpots[j - 20] = new RegularSpot()
					{
						SpotNumber = int.Parse(i.ToString() + j)
					};
					AvailableRegularSpots.Add(regularSpots[j - 20]);
				}

				l.LevelNumber = i;
				l.HandicapSpots.AddRange(handicapSpots);
				l.MotocycleSpots.AddRange(motocycleSpots);
				l.RegularSpots.AddRange(regularSpots);
				Levels.Add(l);
			}

		}

		public List<ParkingSpot> FindAvailableSpots()
		{
			List<ParkingSpot> allAvail = new List<ParkingSpot>();

			allAvail.AddRange(AvailableRegularSpots);
			allAvail.AddRange(AvailableHandicapSpots);
			allAvail.AddRange(AvailableMotocycleSpots);

			return allAvail;
		}
	}
}
