using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test2.Models;

[Table("character_titles")]
[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitles
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    public DateTime AquiredAt { get; set; }

    [ForeignKey(nameof(CharacterId))] public Character Character { get; set; } = null!;
    [ForeignKey(nameof(TitleId))] public Title Title { get; set; } = null!;
}