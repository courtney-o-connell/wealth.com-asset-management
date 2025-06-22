using AssetManagementApi.Responses;

namespace AssetManagementApi.Models;

public interface IAssetManagementCommandHandler
{
    Task<GetAssetsResponse> GetAssetsAsync();
    Task<GetAssetsByDateResponse> GetAssetsByDateAsync(GetAssetsByDateRequest request);
}