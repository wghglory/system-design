using System;
using System.Collections.Generic;

namespace ConferenceMeeting
{
	public class ConfRoom
	{
		public List<Interval> Intervals { get; set; }
		public int RoomId { get; set; }

		public ConfRoom(int roomId)
		{
			Intervals = new List<Interval>();
			RoomId = roomId;
		}

		public void AddInterval(Interval it)
		{
			Intervals.Add(it);
		}
	}
}
