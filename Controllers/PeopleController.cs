using ControleGastos.Api.Data;
using ControleGastos.Api.DTOs;
using ControleGastos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("api/[controller]")] 
public class PeopleController : ControllerBase
{
    private readonly AppDbContext _context;

    
    public PeopleController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonCreateDTO dto)
    {
       
        var person = new Person
        {
            Name = dto.Name,
            Age = dto.Age
        };

       
        _context.People.Add(person);    
        await _context.SaveChangesAsync();

        
        var responseDto = new PersonResponseDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };

        
        return CreatedAtAction(nameof(GetAll), new { id = person.Id }, responseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var people = await _context.People
            .Select(p => new PersonResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age
            })
            .ToListAsync();

        return Ok(people);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null)
        {
            return NotFound(); 
        }

        _context.People.Remove(person);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}