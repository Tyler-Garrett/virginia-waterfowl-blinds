using MediatR;
using WaterfowlBlinds.Contracts.Blinds;
using WaterfowlBlinds.Domain.Common;
using WaterfowlBlinds.Domain.Repositories;

namespace WaterfowlBlinds.Application.Blinds.Queries.GetBlindById;

public class GetBlindByIdQueryHandler : IRequestHandler<GetBlindByIdQuery, Result<BlindResponse>>
{
    private readonly IBlindRepository _repository;

    public GetBlindByIdQueryHandler(IBlindRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<BlindResponse>> Handle(
        GetBlindByIdQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _repository.GetByIdAsync(request.BlindId, cancellationToken);

        if (!result.IsSuccess)
            return Result<BlindResponse>.Failure(result.Error!);

        var blind = result.Value!;
        var response = new BlindResponse(
            blind.BlindId,
            blind.Latitude,
            blind.Longitude,
            blind.CreatedAt,
            blind.UpdatedAt
        );

        return Result<BlindResponse>.Success(response);
    }
}