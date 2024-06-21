using Test2.Models;

namespace Test2.DTOs;

public class GetCharacterDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }

    public ICollection<GetBackpackDTO> BackpackItems { get; set; } = new HashSet<GetBackpackDTO>();
    public ICollection<GetCharacterTitlesDTO> Titles { get; set; } = new HashSet<GetCharacterTitlesDTO>();
}

public class GetBackpackDTO
{
    public string ItemName { get; set; } = null!;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}

public class GetCharacterTitlesDTO
{
    public string Title { get; set; } = null!;
    public DateTime AquiredAt { get; set; }

}