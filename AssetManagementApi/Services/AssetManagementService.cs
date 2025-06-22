
using AssetManagementApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AssetManagementApi.Services;

public class AssetManagementService : IAssetManagementService
{
    private readonly IMongoCollection<Asset> _assetsCollection;

    public AssetManagementService(IOptions<AssetManagementDatabaseSettings> testDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            testDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            testDatabaseSettings.Value.DatabaseName);

        _assetsCollection = mongoDatabase.GetCollection<Asset>(
            testDatabaseSettings.Value.CollectionName);
    }

    public async Task<List<Asset>> GetAssetsAsync()
    {
        var cursor = await _assetsCollection.FindAsync(_ => true);
        return await cursor.ToListAsync();
    }

    public async Task<List<Asset>> GetAssetsByDateAsync(DateTimeOffset date)
    {
        var dateString = date.ToString("yyyy-MM-ddTHH:mm:sszzz");
        var filter = Builders<Asset>.Filter.Lte(x => x.BalanceAsOf, dateString);
        var cursor = await _assetsCollection.FindAsync(filter);
        return await cursor.ToListAsync();
    }
}