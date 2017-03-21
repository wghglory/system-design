using System;
using System.Linq;
using System.Collections.Generic;

namespace ConferenceMeeting
{
	class CountAvailableIntervals
	{
		public static void Main(string[] args)
		{
			// Room 1 - 8AM - 9AM, 10:30AM - 11AM, 4PM - 5 PM
			ConfRoom rc1 = new ConfRoom(1);
			Interval rc1i1 = new Interval(480, 540);
			Interval rc1i2 = new Interval(630, 660);
			Interval rc1i3 = new Interval(960, 1020);
			rc1.AddInterval(rc1i1);
			rc1.AddInterval(rc1i2);
			rc1.AddInterval(rc1i3);

			// Room 2 - 10AM - 12PM, 2:30PM - 4PM
			ConfRoom rc2 = new ConfRoom(2);
			Interval rc2i1 = new Interval(600, 720);
			Interval rc2i2 = new Interval(870, 960);
			rc2.AddInterval(rc2i1);
			rc2.AddInterval(rc2i2);

			// Room 3 - 7AM - 8:30AM, 5PM - 6PM
			ConfRoom rc3 = new ConfRoom(3);
			Interval rc3i1 = new Interval(420, 510);
			Interval rc3i2 = new Interval(1020, 1080);
			rc3.AddInterval(rc3i1);
			rc3.AddInterval(rc3i2);

			List<ConfRoom> cfs = new List<ConfRoom>();
			cfs.Add(rc1);
			cfs.Add(rc2);
			cfs.Add(rc3);

			// check for any available room for 8 AM - 9AM
			Console.WriteLine(IsAnyRoomAvailable(cfs, new Interval(480, 540)));

			// check for any available room for 3:30 PM - 5PM
			Console.WriteLine(IsAnyRoomAvailable(cfs, new Interval(930, 1021)));

			// count available rooms from 10:30AM - 11AM
			List<int> ids = GetAvailableRooms(cfs, new Interval(630, 660));

			Console.WriteLine($"total available rooms' count is {ids.Count}, ids are {string.Join(",", ids)}");


			// output: 
			// true
			// false
			// 3
		}


		public static bool IsRoomAvailable(ConfRoom cf, Interval interval)
		{
			List<Interval> itvs = cf.Intervals;
			bool result = false;
			foreach (Interval src in itvs)
			{
				if (IsIntervalAvailable(src, interval))
				{
					result = true;
				}
				else
				{
					result = false;
					break;
				}
			}

			return result;
		}


		public static bool IsIntervalAvailable(Interval src, Interval target)
		{
			//src: 10-10:30 and 11-11:30; target: 10:40-10:50 or 9-9:40
			return src.End <= target.Start || src.Start >= target.End;
		}

		public static bool IsAnyRoomAvailable(List<ConfRoom> cf, Interval interval)
		{
			foreach (ConfRoom confRoom in cf)
			{
				if (IsRoomAvailable(confRoom, interval))
				{
					return true;
				}
			}
			return false;
		}

		public static List<int> GetAvailableRooms(List<ConfRoom> cf, Interval interval)
		{
			List<int> availableRoomIds = new List<int>();
			foreach (ConfRoom confRoom in cf)
			{
				if (IsRoomAvailable(confRoom, interval))
				{
					availableRoomIds.Add(confRoom.RoomId);
				}
			}
			return availableRoomIds;
		}
	}
}




