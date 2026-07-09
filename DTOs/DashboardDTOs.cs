namespace ControleGastos.Api.DTOs;

public class PersonTotalDTO
{
    public string PersonName { get; set; } = string.Empty;
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal NetBalance { get; set; }
}

public class DashboardResponseDTO
{
    public List<PersonTotalDTO> People { get; set; } = new();
    public decimal GrandTotalIncome { get; set; }
    public decimal GrandTotalExpense { get; set; }
    public decimal GrandNetBalance { get; set; }
}