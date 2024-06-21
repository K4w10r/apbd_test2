using Test2.Models;

namespace Test2.Service;

public interface IDbService
{
    Task<Character> GetCharacterData(int id);
    Task<Item> GetItemData(int id);
    Task<bool> DoesCharacterExist(int id);
    Task<bool> DoesItemExist(int id);
    Task AddBackpackItems(List<Backpack> backpacks);
    Task<bool> IsItemAlreadyInBackpack(int characterId, int itemId);
    Task<Backpack> GetBackpackData(int charId, int itemId);
    Task AddBackpackItem(Backpack backpacks);
}