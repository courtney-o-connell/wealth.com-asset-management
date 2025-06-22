namespace AssetManagementApi.Models;

public class GetAssetsByDateRequest
{
    public string BalanceOfDate { get; set; }

    public List<string> Validate()
    {
        List<string> errors = new List<string>();

        // is balanceOfDate populated?
        if (string.IsNullOrEmpty(BalanceOfDate))
        {
            errors.Add("BalanceOfDate is required.");
        }
        //is balanceOfDate a valid date?
        else if (!DateTimeOffset.TryParse(BalanceOfDate, out _))
        {
            errors.Add("BalanceOfDate must be a valid date.");
        }
        return errors;
    }
}