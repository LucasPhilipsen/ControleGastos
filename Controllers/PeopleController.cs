using ControleGastos.Api.Data;
using ControleGastos.Api.DTOs;
using ControleGastos.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("api/[controller]")] // A URL ficará: /api/people
public class PeopleController : ControllerBase
{
    private readonly AppDbContext _context;

    // Injeção de Dependência: A API entrega o banco de dados pronto para usarmos
    public PeopleController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PersonCreateDTO dto)
    {
        // 1. Pega o DTO que veio da internet e transforma na Entidade do banco
        var person = new Person
        {
            Name = dto.Name,
            Age = dto.Age
        };

        // 2. Salva no banco de dados de forma assíncrona
        _context.People.Add(person);
        await _context.SaveChangesAsync();

        // 3. Monta o DTO de resposta para devolver os dados (agora com o ID gerado)
        var responseDto = new PersonResponseDTO
        {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age
        };

        // Retorna HTTP 201 (Created)
        return CreatedAtAction(nameof(GetAll), new { id = person.Id }, responseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Vai no banco e já converte direto para DTO (muito mais rápido e consome menos memória)
        var people = await _context.People
            .Select(p => new PersonResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Age = p.Age
            })
            .ToListAsync();

        return Ok(people); // Retorna HTTP 200 com a lista
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Busca a pessoa pelo ID
        var person = await _context.People.FindAsync(id);

        if (person == null)
        {
            return NotFound(); // Retorna HTTP 404 se não achar
        }

        // Deleta a pessoa (o EF Core vai deletar as transações dela automaticamente)
        _context.People.Remove(person);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna HTTP 204 (Sucesso, mas sem conteúdo para mostrar)
    }
}