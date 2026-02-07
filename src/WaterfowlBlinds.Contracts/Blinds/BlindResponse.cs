namespace WaterfowlBlinds.Contracts.Blinds;

public record BlindResponse(
    string BlindId,
    double Latitude,
    double Longitude,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);