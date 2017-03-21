using System.Collections.Generic;

namespace ParkingLotDemo
{
	public class Level
	{
		public int LevelNumber { get; set; }

		public Level()
		{
			RegularSpots = new List<RegularSpot>();
			MotocycleSpots = new List<MotocycleSpot>();
			HandicapSpots = new List<HandicapSpot>();
		}

		public List<RegularSpot> RegularSpots { get; set; }
		public List<MotocycleSpot> MotocycleSpots { get; set; }
		public List<HandicapSpot> HandicapSpots { get; set; }
	}
}