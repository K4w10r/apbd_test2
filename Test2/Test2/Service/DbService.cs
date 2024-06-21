using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Service;

public class DbService : IDbService

{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<Character> GetCharacterData(int id)
    {
        
            return await _context.Characters.FirstOrDefaultAsync(e => e.Id == id);
        
    }

    public async Task<Item> GetItemData(int id)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task<Backpack> GetBackpackData(int charId, int itemId)
    {
        return await _context.Backpacks.FirstOrDefaultAsync(e => e.ItemId == itemId && e.CharacterId == charId);
    }

    public async Task<bool> DoesCharacterExist(int id)
    {
        return await _context.Characters.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> DoesItemExist(int id)
    {
        return await _context.Items.AnyAsync(e => e.Id == id);
    }

    public async Task<bool> IsItemAlreadyInBackpack(int characterId, int itemId)
    {
        return await _context.Backpacks.AnyAsync(e => e.CharacterId == characterId && e.ItemId == itemId);
    }
    

    public async Task AddBackpackItems(List<Backpack> backpacks)
    {
        await _context.AddRangeAsync(backpacks);
        await _context.SaveChangesAsync();
    }
    public async Task AddBackpackItem(Backpack backpacks)
    {
        await _context.AddAsync(backpacks);
        await _context.SaveChangesAsync();
    }
}