namespace Test2.DTOs;

public class AddItemBackpackDTO
{
    public int ItemId { get; set; }
    public int Amount { get; set; }
}

public class GetAddedItemsDTO
{
    public int Amount { get; set; }
    public int ItemId { get; set; }
    public int CharacterId { get; set; }
}