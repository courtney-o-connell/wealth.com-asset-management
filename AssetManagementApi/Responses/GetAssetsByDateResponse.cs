using AssetManagementApi.Models;

namespace AssetManagementApi.Responses;

public class GetAssetsByDateResponse
{
    public List<Asset> Assets { get; set; } = new List<Asset>();
    public string Status { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public GetAssetsByDateResponse()
    {
        Assets = new List<Asset>();
        Status = "Failure";
        Errors = new List<string>();
    }
}