using ControleGastos.Api.Data;
using ControleGastos.Api.DTOs;
using ControleGastos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TransactionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransactionCreateDTO dto)
    {
        var person = await _context.People.FindAsync(dto.PersonId);

        if (person == null)
        {
            return NotFound("Person not found."); 
        }

        
        if (person.Age < 18 && dto.Type == TransactionType.Income)
        {
            return BadRequest("Minors (under 18) are not allowed to register incomes."); 
        }

       
        var transaction = new Transaction
        {
            Description = dto.Description,
            Amount = dto.Amount,
            Type = dto.Type,
            PersonId = dto.PersonId
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        
        var responseDto = new TransactionResponseDTO
        {
            Id = transaction.Id,
            Description = transaction.Description,
            Amount = transaction.Amount,
            Type = transaction.Type.ToString(), 
            PersonId = transaction.PersonId
        };

        return CreatedAtAction(nameof(GetAll), new { id = transaction.Id }, responseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var transactions = await _context.Transactions
            .Select(t => new TransactionResponseDTO
            {
                Id = t.Id,
                Description = t.Description,
                Amount = t.Amount,
                Type = t.Type.ToString(),
                PersonId = t.PersonId
            })
            .ToListAsync();

        return Ok(transactions);
    }
}