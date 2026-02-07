namespace WaterfowlBlinds.Contracts.Blinds;

public record BlindsInRadiusRequest(
    double Latitude,
    double Longitude,
    double RadiusMeters = 457.2 // 500 yards default
);