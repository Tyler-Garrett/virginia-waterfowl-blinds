namespace WaterfowlBlinds.Contracts.Blinds;

public record CreateBlindRequest(
    string BlindId,
    double Latitude,
    double Longitude
);