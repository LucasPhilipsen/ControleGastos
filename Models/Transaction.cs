namespace ControleGastos.Api.Models;

public enum TransactionType
{
    Income,
    Expense
}

public class Transaction
{
    public int Id { get; init; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }

    public int PersonId { get; set; }
    
    public Person? Person { get; set; }
}