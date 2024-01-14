using BillioAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using BillioAPI.Repository;

namespace BillioAPI.Services;


public class BudgetService :  IBudgetService{

 private readonly IBudgetRepository _budgetRepository;

    public BudgetService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<IEnumerable<Budget>> GetAllBudgetsAsync()
    {
        return await _budgetRepository.GetAllBudgetsAsync();
    }

    public async Task<Budget> GetBudgetByIdAsync(string id)
    {
        return await _budgetRepository.GetBudgetByIdAsync(id);
    }

    public async Task AddBudgetAsync(Budget budget)
    {
        await _budgetRepository.AddBudgetAsync(budget);
    }

    public async Task UpdateBudgetAsync(string id, Budget budget)
    {
        await _budgetRepository.UpdateBudgetAsync(id, budget);
    }

    public async Task DeleteBudgetAsync(string id)
    {
        await _budgetRepository.DeleteBudgetAsync(id);
    }

}
