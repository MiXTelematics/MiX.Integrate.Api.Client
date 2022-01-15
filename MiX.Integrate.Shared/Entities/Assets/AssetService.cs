using System;

namespace MiX.Integrate.Shared.Entities.Assets
{
	/// <summary>Records the details of an asset service transaction</summary>
	public class AssetService
	{
		/// <summary>Unique identifier of the asset service record</summary>
		public int AssetServiceId { get; set; }

		/// <summary>Identifies the serviced asset</summary>
		public long AssetId { get; set; }

		/// <summary>Date the service was performed</summary>
		public DateTime ServiceDate { get; set; }

		/// <summary>Odometer reading at the time of the service</summary>
		public double Odometer { get; set; }

		/// <summary>(Optional) Engine hours recorded with the service transaction</summary>
		public int? EngineSeconds { get; set; }

		/// <summary>Invoice or job number associated with the service. A value must be specified</summary>
		public string Reference { get; set; }

		/// <summary>(Optional) Cost of the service in the currency (see <see cref="TransactionCurrency"/>) of the country where it took place</summary>
		public decimal? TransactionCost { get; set; }

		/// <summary>(Optional) Monetary unit of the <see cref="TransactionCost"/></summary>
		public string TransactionCurrency { get; set; }

		/// <summary>(Optional) Cost of the service in the organisation base currency (see <see cref="BaseCurrency"/>)</summary>
		public decimal? BaseCost { get; set; }

		/// <summary>(Optional) Monetary unit of the organisation base currency</summary>
		public string BaseCurrency { get; set; }

		/// <summary>Notes / comments pertaining to the service</summary>
		public string Notes { get; set; }
	}
}
