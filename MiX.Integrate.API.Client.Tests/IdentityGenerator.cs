using System;

namespace MiX.Integrate.API.Client.Tests
{
	public static class IdentityGenerator
	{
		public static long Generate64Bit()
		{
			Guid guid = Guid.NewGuid();

			return HashGuid(guid);
		}

		public static long HashGuid(Guid guid)
		{
			byte[] buffer = guid.ToByteArray();

			ulong result = 14695981039346656037u;

			unchecked
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					result = ((result ^ buffer[i]) * 1099511628211u); //xor with new and multiply with prime
				}
			}

			long identity = BitConverter.ToInt64(BitConverter.GetBytes(result), 0);

			if (identity == 0)
				identity = Generate64Bit();

			return identity;
		}
	}
}