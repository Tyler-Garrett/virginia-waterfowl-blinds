using MediatR;
using WaterfowlBlinds.Contracts.Blinds;
using WaterfowlBlinds.Domain.Common;
using WaterfowlBlinds.Domain.Repositories;

namespace WaterfowlBlinds.Application.Blinds.Queries.GetBlindsInRadius;

public class GetBlindsInRadiusQueryHandler
    : IRequestHandler<GetBlindsInRadiusQuery, Result<IEnumerable<BlindResponse>>>
{
    private readonly IBlindRepository _repository;

    public GetBlindsInRadiusQueryHandler(IBlindRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<BlindResponse>>> Handle(
        GetBlindsInRadiusQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetBlindsInRadiusAsync(
            request.Latitude,
            request.Longitude,
            request.RadiusMeters,
            cancellationToken);

        if (!result.IsSuccess)
            return Result<IEnumerable<BlindResponse>>.Failure(result.Error!);

        var responses = result.Value!.Select(b => new BlindResponse(
            b.BlindId,
            b.Latitude,
            b.Longitude,
            b.CreatedAt,
            b.UpdatedAt
        ));

        return Result<IEnumerable<BlindResponse>>.Success(responses);
    }
}