using MediatR;
using WaterfowlBlinds.Contracts.Blinds;
using WaterfowlBlinds.Domain.Common;

namespace WaterfowlBlinds.Application.Blinds.Queries.GetBlindsInRadius;

public record GetBlindsInRadiusQuery(
    double Latitude,
    double Longitude,
    double RadiusMeters
) : IRequest<Result<IEnumerable<BlindResponse>>>;