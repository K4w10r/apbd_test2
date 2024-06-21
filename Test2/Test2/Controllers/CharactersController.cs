using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Test2.DTOs;
using Test2.Models;
using Test2.Service;

namespace Test2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;
    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("/{id:int}")]
    public async Task<IActionResult> GetCharacterData(int id)
    {
        var character = await _dbService.GetCharacterData(id);

        return Ok(new GetCharacterDTO()
        {
            FirstName = character.FirstName,
            LastName = character.LastName,
            CurrentWeight = character.CurrentWeight,
            MaxWeight = character.MaxWeight,
            BackpackItems = character.Backpacks.Select(e => new GetBackpackDTO()
            {
                ItemName = e.Item.Name,
                ItemWeight = e.Item.Weight,
                Amount = e.Amount
            }).ToList(),
            Titles = character.Titles.Select(e => new GetCharacterTitlesDTO()
            {
                Title = e.Title.Name,
                AquiredAt = e.AquiredAt
            }).ToList()
        });
    }

    [HttpPost("/{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, List<AddItemBackpackDTO> items)
    {
        if (!await _dbService.DoesCharacterExist(characterId))
        {
            return NotFound($"Character with given ID: {characterId} doesn't exist");
        }

        foreach (var item in items)
        {
            if (!await _dbService.DoesItemExist(item.ItemId))
            {
                return NotFound($"Item with given ID: {item.ItemId} doesn't exist");
            }

            if (!await _dbService.IsItemAlreadyInBackpack(characterId, item.ItemId))
            {
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var backpack = await _dbService.GetBackpackData(characterId, item.ItemId);
                    backpack.Amount += item.Amount;
                    await _dbService.AddBackpackItem(backpack);
                    scope.Complete();
                }
            }
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var backpack = new Backpack()
                {
                    Amount = item.Amount,
                    CharacterId = characterId,
                    ItemId = item.ItemId
                };
                await _dbService.AddBackpackItem(backpack);
                scope.Complete();
            }
            
        }

        return Ok();

    }
}