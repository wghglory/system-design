using System;
namespace ConferenceMeeting
{
	public class Interval
	{
		public int Start { get; set; }
		public int End { get; set; }

		public Interval(int start, int end)
		{
			this.Start = start;
			this.End = end;
		}
	}
}
