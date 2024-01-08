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
    
    private readonly BudgetService _budgetService;

    public BudgetController(BudgetService budgetService){
        _budgetService =budgetService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Budget>> GetByID(string id){
        var vbudget = await _budgetService.GetByIdAsync(id);

        if (vbudget is null)
            {
                return NotFound();
            }

            return Ok(vbudget);
    }
    [HttpGet]
    public async Task<List<Budget>> Get(){
        return await _budgetService.GetAsync();
    }

    [HttpPost]
     public async Task<IActionResult> Post([FromBody] Budget budget){
        await _budgetService.CreateAsync(budget);
        return CreatedAtAction(nameof(Get), new {id=budget.Id}, budget);
     }

     [HttpPut("{id}")]
      public async Task<IActionResult> UpdateBudget(string id,[FromBody] Budget updatedBudget){
        if(id !=updatedBudget.Id){
             return BadRequest("ID mismatch in URL and request body");
        }
        await _budgetService.PutAsync(id, updatedBudget);
        return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteBudget(string id){
        await _budgetService.DeleteAsync(id);
        return NoContent();
      } 
}