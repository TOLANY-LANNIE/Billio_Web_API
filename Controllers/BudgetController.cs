using System;
using Microsoft.AspNetCore.Mvc;
using BillioAPI.Models;
using BillioAPI.Services;

namespace BillioAPI.Controllers;

/// <summary>
/// Controller class for the budget collection
/// </summary>
[Controller]
[Route("api/[controller]")]
public class BudgetController: Controller{
    
    private readonly IBudgetService _budgetService;

    public BudgetController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    // GET: api/Budget
    [HttpGet]
    public async Task<IEnumerable<Budget>> Get()
    {
        return await _budgetService.GetAllBudgetsAsync();
    }

    // GET: api/Budget/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<ActionResult<Budget>> Get(string id)
    {
        var budget = await _budgetService.GetBudgetByIdAsync(id);

        if (budget == null)
        {
            return NotFound();
        }

        return budget;
    }

    // POST: api/Budget
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Budget budget)
    {
        await _budgetService.AddBudgetAsync(budget);

        return CreatedAtAction(nameof(Get), new { id = budget.Id }, budget);
    }

    // PUT: api/Budget/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, [FromBody] Budget budget)
    {
        var existingBudget = await _budgetService.GetBudgetByIdAsync(id);

        if (existingBudget == null)
        {
            return NotFound();
        }

        await _budgetService.UpdateBudgetAsync(id, budget);

        return NoContent();
    }

    // DELETE: api/Budget/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var budget = await _budgetService.GetBudgetByIdAsync(id);

        if (budget == null)
        {
            return NotFound();
        }

        await _budgetService.DeleteBudgetAsync(id);

        return NoContent();
    }
}