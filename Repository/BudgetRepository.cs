using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillioAPI.Models;

namespace  BillioAPI.Repository;
public class BudgetRepository : IBudgetRepository
{
    private readonly IMongoCollection<Budget> _budgetsCollection;

    public BudgetRepository(IMongoDatabase database)
    {
        _budgetsCollection = database.GetCollection<Budget>("Budgets");
    }

    public async Task<IEnumerable<Budget>> GetAllBudgetsAsync()
    {
        return await _budgetsCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Budget> GetBudgetByIdAsync(string id)
    {
        return await _budgetsCollection.Find(b => b.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddBudgetAsync(Budget budget)
    {
        await _budgetsCollection.InsertOneAsync(budget);
    }

    public async Task UpdateBudgetAsync(string id, Budget budget)
    {
        await _budgetsCollection.ReplaceOneAsync(b => b.Id == id, budget);
    }

    public async Task DeleteBudgetAsync(string id)
    {
        await _budgetsCollection.DeleteOneAsync(b => b.Id == id);
    }
}
