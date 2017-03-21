using System;
using System.Text;

namespace ParkingLotDemo
{
	public static class Helper
	{
		private static Random random = new Random((int)DateTime.Now.Ticks);

		public static string RandomString(int size)
		{
			string input = "abcdefghijklmnopqrstuvwxyz0123456789";
			StringBuilder builder = new StringBuilder();
			char ch;
			for (int i = 0; i < size; i++)
			{
				ch = input[random.Next(0, input.Length)];
				builder.Append(ch);
			}
			return builder.ToString();
		}
	}
}
