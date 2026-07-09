namespace ControleGastos.Api.DTOs;

// DTO para quando o Front-end for CADASTRAR uma pessoa (não precisamos pedir o ID)
public class PersonCreateDTO
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}

// DTO para quando a API for RETORNAR os dados da pessoa
public class PersonResponseDTO
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}