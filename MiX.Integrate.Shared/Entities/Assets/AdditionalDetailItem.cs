namespace MiX.Integrate.Shared.Entities.Assets
{
  /// <summary>Instance of a custom asset detail data point/summary>
  public class AdditionalDetailItem
  {
    public AdditionalDetailItem(int id, string label, string value)
    {
      Id = id;
      Label = label;
      Value = value;
    }

    /// <summary>Identifiedr of the custom detail</summary>
    public int Id { get; set; }

    /// <summary>Name of the custom detail</summary>
    public string Label { get; set; }

    /// <summary>Value of the custom detail</summary>
    public string Value { get; set; }
  }
}
