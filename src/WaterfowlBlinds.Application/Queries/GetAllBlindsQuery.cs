using MediatR;
using WaterfowlBlinds.Contracts.Blinds;
using WaterfowlBlinds.Domain.Common;

namespace WaterfowlBlinds.Application.Blinds.Queries.GetAllBlinds;

public record GetAllBlindsQuery : IRequest<Result<IEnumerable<BlindResponse>>>;