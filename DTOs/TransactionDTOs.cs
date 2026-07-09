using ControleGastos.Api.Models;

namespace ControleGastos.Api.DTOs;

public class TransactionCreateDTO
{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }

    public TransactionType Type { get; set; }
    public int PersonId { get; set; }
}

public class TransactionResponseDTO
{
    public int Id { get; init; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty; 
    public int PersonId { get; set; }
}