using System;
using System.Globalization;
using MiX.Integrate.Shared.Constants;

namespace MiX.Integrate.Shared.Helpers
{
	public static class DateTimeHelper
	{

		/// <summary>Converts the specified string representation of a UTC timestamp
		/// to its <see cref="DateTime"/> equivalent</summary>
		/// <param name="s">A string in the format yyyyMMddHHmmss or yyyyMMddHHmmssfff that contains a date and time to convert</param>
		/// <returns>A <see cref="DateTime"/> that is equivalent to the UTC date and time represented in <paramref name="s"/></returns>
		/// <exception cref="ArgumentException">If the value could not be parsed</exception>
		public static DateTime ParseExactToUtc(this string s)
		{
			DateTime dt;
			try
			{
				if (s.Length == DataFormats.DateTime_Format_WithMilliseconds.Length)
				{
					return DateTime.SpecifyKind(DateTime.ParseExact(s, DataFormats.DateTime_Format_WithMilliseconds, CultureInfo.InvariantCulture),
						DateTimeKind.Utc);
				}
				else
				{
					return DateTime.SpecifyKind(DateTime.ParseExact(s, DataFormats.DateTime_Format, CultureInfo.InvariantCulture), DateTimeKind.Utc);
				}
			}
			catch (Exception)
			{
				throw new ArgumentException($"Could not parse parameter value [{s}] to DateTime");
			}
		}

		/// <summary>Converts the specified string representation of a UTC timestamp
		/// to its <see cref="DateTime"/> equivalent or a specified default value</summary>
		/// <param name="s">A string in the format yyyyMMddHHmmss or yyyyMMddHHmmssfff that contains a date and time to convert</param>
		/// <returns>A <see cref="DateTime"/> that is equivalent to the UTC date and time represented in <paramref name="s"/>, or
		/// <paramref name="defaultValue"/> if the string could not be converted</returns>
		public static DateTime ParseExactToUtc(this string s, DateTime defaultValue)
		{
			try
			{
				if (s.Length == DataFormats.DateTime_Format_WithMilliseconds.Length)
				{
					if (!DateTime.TryParseExact(s, DataFormats.DateTime_Format_WithMilliseconds, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
					 return defaultValue;
					return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
				}
				if (s.Length == DataFormats.DateTime_Format.Length)
				{
					if (!DateTime.TryParseExact(s, DataFormats.DateTime_Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
						return defaultValue;
					return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
				}
				return defaultValue;
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		/// <summary>Formats a DateTime</summary>
		public static string To24HourUtc_WithMilliseconds(this DateTime dt)
		{
			//if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTimeToUtc(dt);
			if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Utc);
			string s = dt.ToString(DataFormats.DateTime_Format_WithMilliseconds);
			return s;
		}

		/// <summary>Formats a DateTime</summary>
		public static string To24HourUtc(this DateTime dt)
		{
			if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Utc);
			return dt.ToString(DataFormats.DateTime_Format);
		}

	}
}
