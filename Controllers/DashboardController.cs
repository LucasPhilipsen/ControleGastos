using ControleGastos.Api.Data;
using ControleGastos.Api.DTOs;
using ControleGastos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTotals()
    {
        // 1. Busca todas as pessoas e INCLUI a lista de transações de cada uma
        var people = await _context.People
            .Include(p => p.Transactions)
            .ToListAsync();

        // 2. Calcula os totais individuais
        var personTotals = people.Select(p =>
        {
            var totalIncome = p.Transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var totalExpense = p.Transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            return new PersonTotalDTO
            {
                PersonName = p.Name,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                NetBalance = totalIncome - totalExpense
            };
        }).ToList();

        // 3. Calcula os totais gerais da aplicação
        var grandTotalIncome = personTotals.Sum(p => p.TotalIncome);
        var grandTotalExpense = personTotals.Sum(p => p.TotalExpense);

        // 4. Monta o pacote final
        var dashboard = new DashboardResponseDTO
        {
            People = personTotals,
            GrandTotalIncome = grandTotalIncome,
            GrandTotalExpense = grandTotalExpense,
            GrandNetBalance = grandTotalIncome - grandTotalExpense
        };

        return Ok(dashboard);
    }
}