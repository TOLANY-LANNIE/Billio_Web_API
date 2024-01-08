using BillioAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BillioAPI.Services;


public class BudgetService{

    private readonly IMongoCollection<Budget>_budgetCollection;

    public BudgetService(IOptions<MongoDbSettings> mongodbSettings){
        MongoClient client = new MongoClient(mongodbSettings.Value.ConnectionURL);
        IMongoDatabase database = client.GetDatabase(mongodbSettings.Value.DatabaseName);
        _budgetCollection = database.GetCollection<Budget>(mongodbSettings.Value.BudgetCollection);
    }

    public async Task <Budget> GetByIdAsync(string id){
        return await _budgetCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Budget>> GetAsync(){
        return await _budgetCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task CreateAsync(Budget budget){
        await _budgetCollection.InsertOneAsync(budget);
        return;
    }

     public async Task PutAsync(string id, Budget budget){
        await _budgetCollection.ReplaceOneAsync(x=> x.Id ==id, budget);
        return;
     }
    public async Task DeleteAsync(string id){
        FilterDefinition <Budget>filter = Builders<Budget>.Filter.Eq("Id", id);
        await _budgetCollection.DeleteOneAsync(filter);
        return;
    } 
   


}
