using AssetManagementApi.Models;
using AssetManagementApi.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementApi.Controllers;

[ApiController]
[Route("/v1/asset-management")]
public class AssetManagementController : ControllerBase
{
    private readonly ILogger<AssetManagementController> _logger;
    private readonly IAssetManagementCommandHandler _assetManagementCommandHandler;

    public AssetManagementController(ILogger<AssetManagementController> logger, IAssetManagementCommandHandler assetManagementCommandHandler)
    {
        _logger = logger;
        _assetManagementCommandHandler = assetManagementCommandHandler;
    }

    [HttpGet("get-all-assets")]
    public async Task<IActionResult> GetAssets()
    {
        _logger.LogInformation("GetAssets endpoint called");

        GetAssetsResponse response = new GetAssetsResponse();
        try
        {
            response = await _assetManagementCommandHandler.GetAssetsAsync();
            response.Status = "Success";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting assets");
            response.Errors.Add(ex.Message);
        }

        return Ok(response);
    }
    
    [HttpPost("get-by-date")]
    public async Task<IActionResult> GetAssetsByDate(GetAssetsByDateRequest request)
    {
        _logger.LogInformation("GetAssetsByDate endpoint called");
        
        GetAssetsByDateResponse response = new GetAssetsByDateResponse();

        // Validate the request
        List<string> validationErrors = request.Validate();
        if (validationErrors.Any())
        {
            response.Errors.AddRange(validationErrors);
            return BadRequest(response);
        }

        try
        {
            response = await _assetManagementCommandHandler.GetAssetsByDateAsync(request);
            response.Status = "Success"; //status is defaulted to "Failure"
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting assets");
            response.Errors.Add(ex.Message);
            return BadRequest(response);
        }
       
        return Ok(response);
    }
}
