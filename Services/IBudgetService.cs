using System.Collections.Generic;
using System.Threading.Tasks;
using BillioAPI.Models;

namespace BillioAPI.Services;

public interface IBudgetService
{
    Task<IEnumerable<Budget>> GetAllBudgetsAsync();
    Task<Budget> GetBudgetByIdAsync(string id);
    Task AddBudgetAsync(Budget budget);
    Task UpdateBudgetAsync(string id, Budget budget);
    Task DeleteBudgetAsync(string id);
}
