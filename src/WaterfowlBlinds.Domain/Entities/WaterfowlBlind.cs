namespace WaterfowlBlinds.Domain.Entities;

public class WaterfowlBlind
{
    public required string BlindId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    // For Azure Table Storage
    public string PartitionKey => "VA";
    public string RowKey => BlindId;
}