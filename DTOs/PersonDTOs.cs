namespace ControleGastos.Api.DTOs;


public class PersonCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}


public class PersonResponseDTO
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}