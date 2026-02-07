using WaterfowlBlinds.Domain.Entities;
using WaterfowlBlinds.Domain.Common;

namespace WaterfowlBlinds.Domain.Repositories;

public interface IBlindRepository
{
    Task<Result<WaterfowlBlind>> GetByIdAsync(string blindId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<WaterfowlBlind>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<WaterfowlBlind>>> GetBlindsInRadiusAsync(
        double latitude,
        double longitude,
        double radiusMeters,
        CancellationToken cancellationToken = default);
    Task<Result> CreateAsync(WaterfowlBlind blind, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(WaterfowlBlind blind, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(string blindId, CancellationToken cancellationToken = default);
}