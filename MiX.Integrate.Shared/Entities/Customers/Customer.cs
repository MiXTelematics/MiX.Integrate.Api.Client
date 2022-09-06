using System;

namespace MiX.Integrate.Shared.Entities.Customers
{
	public class Customer
	{
		//Required, non-zero
		public long CustomerId { get; set; }

		//Required, MaxLength=100
		public string Name { get; set; }

		//Required, non-zero
		public long OrganisationGroupId { get; set; }

		//MaxLength=200
		public string AccountNumber { get; set; }

		//MaxLength=200
		public string TaxNumber { get; set; }

		public long? LocationId { get; set; }
		
		//MaxLength=500
		public string PhysicalAddress { get; set; }

		public Coordinate Coordinate { get; set; }

		//MaxLength=500
		public string PostalAddress { get; set; }

		//MaxLength=50
		public string EmailAddress { get; set; }

		//MaxLength=16, "+" (optional) followed by 7-15 digits
		public string TelephoneNumber { get; set; }

		public PaymentTerms PaymentTerms { get; set; }

		public DateTime? ContractStartDate { get; set; }

		public string ExternalReference { get; set; }

		public bool Disabled { get; set; }
	}

	public class Coordinate
	{
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
}
