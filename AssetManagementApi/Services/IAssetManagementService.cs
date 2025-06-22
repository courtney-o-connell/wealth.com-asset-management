using AssetManagementApi.Models;

namespace AssetManagementApi.Services;

public interface IAssetManagementService
{
    public Task<List<Asset>> GetAssetsAsync();
    public Task<List<Asset>> GetAssetsByDateAsync(DateTimeOffset date);
}