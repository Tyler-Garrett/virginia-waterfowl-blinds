using MediatR;
using WaterfowlBlinds.Contracts.Blinds;
using WaterfowlBlinds.Domain.Common;
using WaterfowlBlinds.Domain.Repositories;

namespace WaterfowlBlinds.Application.Blinds.Queries.GetAllBlinds;

public class GetAllBlindsQueryHandler : IRequestHandler<GetAllBlindsQuery, Result<IEnumerable<BlindResponse>>>
{
    private readonly IBlindRepository _repository;

    public GetAllBlindsQueryHandler(IBlindRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IEnumerable<BlindResponse>>> Handle(
        GetAllBlindsQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(cancellationToken);

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