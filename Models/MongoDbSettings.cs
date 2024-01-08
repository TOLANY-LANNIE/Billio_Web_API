namespace BillioAPI.Models;

/// <summary>
///     Represents the settings for a database connection.
/// </summary>
public class MongoDbSettings{

    /// <summary>
    /// 
    /// </summary> <summary>
    public string ConnectionURL{get; set;} = null!;
    public string DatabaseName{get; set;} = null!;
    public string BillsCollection{get; set;} = null!;
    public string BudgetCollection{get; set;} = null!;
    public string TransactionsCollection{get; set;} = null!;
    public string UsersCollection{get; set;} = null!;
}
