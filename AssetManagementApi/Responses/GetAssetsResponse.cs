using AssetManagementApi.Models;

namespace AssetManagementApi.Responses;

public class GetAssetsResponse
{
    public List<Asset> Assets { get; set; } = new List<Asset>();
    public string Status { get; set; }
    public List<string> Errors { get; set; } = new List<string>();

    public GetAssetsResponse()
    {
        Assets = new List<Asset>();
        Status = "Failure";
        Errors = new List<string>();
    }
}