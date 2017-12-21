using MiX.Integrate.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MiX.Integrate.Shared.Helpers
{
	public static class DateTimeHelper
	{

		/// <summary>
		/// Parse String To DateTime
		/// Throw ArgumentException
		/// </summary>
		/// <param name="s">Use format yyyyMMddHHmmss or yyyyMMddHHmmssfff</param>
		/// <returns>Throw ArgumentException if not valid</returns>
		public static DateTime ParseExactToUtc(this string s)
		{
			DateTime dt;
			try
			{
				if (s.Length == DataFormats.DateTime_Format_WithMilliseconds.Length)
				{
					dt = DateTime.ParseExact(s, DataFormats.DateTime_Format_WithMilliseconds, CultureInfo.CurrentUICulture);
					dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
				}
				else
				{
					dt = DateTime.ParseExact(s, DataFormats.DateTime_Format, CultureInfo.CurrentUICulture);
					dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
				}
			}
			catch (Exception)
			{
				throw new ArgumentException($"Could not parse parameter value [{s}] to DateTime");
			}
			return dt;
		}

		/// <summary>
		/// Parse String To DateTime
		/// Return defaultValue if not valid
		/// </summary>
		/// <param name="s"></param>
		/// <param name="">Use format yyyyMMddHHmmss or yyyyMMddHHmmssfff</param>
		/// <returns>Return defaultValue if not valid</returns>
		public static DateTime ParseExactToUtc(this string s, DateTime defaultValue)
		{
			try
			{
				if (s.Length == DataFormats.DateTime_Format_WithMilliseconds.Length)
				{
					DateTime dt;
					bool parsed = DateTime.TryParseExact(s, DataFormats.DateTime_Format_WithMilliseconds, CultureInfo.CurrentUICulture, DateTimeStyles.None, out dt);
					if (!parsed) return defaultValue;
					dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
					return dt;
				}
				else if (s.Length == DataFormats.DateTime_Format.Length)
				{
					DateTime dt;
					bool parsed = DateTime.TryParseExact(s, DataFormats.DateTime_Format, CultureInfo.CurrentUICulture, DateTimeStyles.None, out dt);
					if (!parsed) return defaultValue;
					dt = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
					return dt;
				}
				else
				{
					return defaultValue;
				}
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}

		/// <summary>
		/// Parse DateTime To String
		/// </summary>
		/// <param name="dt"></param>
		/// <returns>yyyyMMddHHmmssfff</returns>
		public static string To24HourUtc_WithMilliseconds(this DateTime dt)
		{
			//if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTimeToUtc(dt);
			if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Utc);
			string s = dt.ToString(DataFormats.DateTime_Format_WithMilliseconds);
			return s;
		}

		/// <summary>
		/// Parse DateTime To String
		/// </summary>
		/// <param name="dt"></param>
		/// <returns>yyyyMMddHHmmss</returns>
		public static string To24HourUtc(this DateTime dt)
		{
			//if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTimeToUtc(dt);
			if (dt.Kind != DateTimeKind.Utc) dt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Utc);
			string s = dt.ToString(DataFormats.DateTime_Format);
			return s;
		}

	}
}
