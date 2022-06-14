using System;

namespace MiX.Integrate.Shared.Entities.Journeys
{
	public class Customer 
	{
		public long CustomerId { get; set; }

		public string Name { get; set; }

		public long OrganisationGroupId { get; set; }

		public string AccountNumber { get; set; }

		public string TaxNumber { get; set; }

		public long LocationId { get; set; }

		public string PhysicalAddress { get; set; }

		public Coordinate Coordinate { get; set; }

		public string PostalAddress { get; set; }

		public string EmailAddress { get; set; }

		public string TelephoneNumber { get; set; }

		public PaymentTerms PaymentTerms { get; set; }

		public DateTime? ContractStartDate { get; set; }

		public string ExternalReference { get; set; }

		public bool Disabled { get; set; }
	}

	public enum PaymentTerms : byte
	{
		NotSelected = 0,
		CashOnDelivery = 1,
		ThirtyDays = 2,
		SixtyDays = 3,
		SixtyPlusDays = 4,
		Other = 5
	}

	public class Coordinate
	{
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
}
