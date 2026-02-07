using MediatR;
using WaterfowlBlinds.Contracts.Blinds;
using WaterfowlBlinds.Domain.Common;

namespace WaterfowlBlinds.Application.Blinds.Queries.GetBlindById;

public record GetBlindByIdQuery(string BlindId) : IRequest<Result<BlindResponse>>;