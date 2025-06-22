using MongoDB.Bson.Serialization.Attributes;

namespace AssetManagementApi.Models;

[BsonIgnoreExtraElements]
public class Asset
{
    [BsonElement("assetId")]
    public string AssetId { get; set; }

    [BsonElement("assetName")]
    public string AssetName { get; set; }

    [BsonElement("primaryAssetCategory")]
    public string PrimaryAssetCategory { get; set; }

    [BsonElement("wealthAssetType")]
    public string WealthAssetType { get; set; }

    [BsonElement("balanceAsOf")]
    public string BalanceAsOf { get; set; }

    [BsonElement("balanceCurrent")]
    public decimal BalanceCurrent { get; set; }

    [BsonElement("assetInfoType")]
    public string AssetInfoType { get; set; }

    [BsonElement("nickname")]
    public string Nickname { get; set; }
}