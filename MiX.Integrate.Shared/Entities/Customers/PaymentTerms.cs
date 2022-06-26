namespace MiX.Integrate.Shared.Entities.Customers
{
	public enum PaymentTerms : byte
	{
		NotSelected = 0,
		CashOnDelivery = 1,
		ThirtyDays = 2,
		SixtyDays = 3,
		SixtyPlusDays = 4,
		Other = 5
	}
}