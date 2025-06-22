using AssetManagementApi.Responses;
using AssetManagementApi.Services;

namespace AssetManagementApi.Models;

public class AssetManagementCommandHandler : IAssetManagementCommandHandler
{
    private readonly ILogger<AssetManagementCommandHandler> _logger;
    private readonly IAssetManagementService _assetManagementService;

    public AssetManagementCommandHandler(ILogger<AssetManagementCommandHandler> logger, IAssetManagementService assetManagementService)
    {
        _assetManagementService = assetManagementService;
        _logger = logger;
    }

    public async Task<GetAssetsResponse> GetAssetsAsync()
    {
        _logger.LogInformation("GetAssetsAsync method called");
        List<Asset> results = await _assetManagementService.GetAssetsAsync();

        if (results is null || !results.Any())
        {
            throw new Exception($"No asset records found.");
        }
        
        return new GetAssetsResponse { Assets = results };
    }

    public async Task<GetAssetsByDateResponse> GetAssetsByDateAsync(GetAssetsByDateRequest request)
    {
        _logger.LogInformation("GetAssetsAsync method called");

        DateTimeOffset date = DateTimeOffset.Parse(request.BalanceOfDate);
        var result = await _assetManagementService.GetAssetsByDateAsync(date);

        if (result is null || !result.Any())
        {       
            throw new Exception($"No records found for the date {request.BalanceOfDate}");
        }

        //filter results so only the latest of each asset is returned
        var records = result
            .OrderByDescending(x => x.BalanceAsOf)
            .GroupBy(x => new { x.PrimaryAssetCategory, x.WealthAssetType, x.AssetInfoType })
            .Select(g => g.FirstOrDefault())
            .OrderBy(x => x.PrimaryAssetCategory)
            .ToList();

        return new GetAssetsByDateResponse() { Assets = records };
    }
}