namespace MiX.Integrate.Shared.Entities.Assets
{
  /// <summary>Instance of a custom asset detail data point/summary>
  public class AdditionalDetailItem
  {
    public AdditionalDetailItem(long id, string label, string value)
    {
      Id = id;
      Label = label;
      Value = value;
    }

    /// <summary>Identifier of the custom detail</summary>
    public long Id { get; set; }

    /// <summary>Name of the custom detail</summary>
    public string Label { get; set; }

    /// <summary>Value of the custom detail</summary>
    public string Value { get; set; }
  }
}
