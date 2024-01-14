using System.Collections.Generic;
using System.Threading.Tasks;
using BillioAPI.Models;

namespace  BillioAPI.Repository;
public interface IBudgetRepository
{
    Task<IEnumerable<Budget>> GetAllBudgetsAsync();
    Task<Budget> GetBudgetByIdAsync(string id);
    Task AddBudgetAsync(Budget budget);
    Task UpdateBudgetAsync(string id, Budget budget);
    Task DeleteBudgetAsync(string id);
}
