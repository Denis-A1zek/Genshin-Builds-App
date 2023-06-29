using GenshinBuilds.Domain.Enum;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Parser.Helpers;
using HtmlAgilityPack;

namespace GenshinBuilds.Parser;

internal class CharacterParser
{
    private readonly HtmlWeb _web;
    private readonly string _baseUrl;

    public CharacterParser(HtmlWeb web, string baseUrl)
        => (_web, _baseUrl) = (web, baseUrl);

    public Character GetCharacterAsync(string source)
    {
        var characterBlock = LoadCharacterBlock(source);
        var character = ParseCharacterBlock(characterBlock);
        
        return character;
    }

    private HtmlNode LoadCharacterBlock(string source)
    {
        var document = _web.Load(source);
        var characterBlock = document.DocumentNode
            .SelectSingleNode("/html[1]/body[1]/div[1]/main/div[1]/div[1]/div[1]");

        return characterBlock;
    }

    private Character ParseCharacterBlock(HtmlNode characterBlock)
    {
        Character character = new();

        character.FullImage = $"{_baseUrl}{characterBlock.ChildNodes[0].Attributes["src"].Value}";
        var characterInfoBlock = characterBlock.SelectSingleNode("div");

        CreateCharacter(characterInfoBlock, character);

        return character;
    }

    private void CreateCharacter(HtmlNode characterBlock, Character character)
    {
        var characterElementImage = characterBlock.ChildNodes[0].SelectSingleNode("img").Attributes["src"].Value;
        character.Element = ItemHelper.GetElement(characterElementImage);
        character.ElementsImage = $"{_baseUrl}{characterElementImage}";
        character.Rarity = ParseCharacterRarity(characterBlock.ChildNodes[2]);

        var characterName = characterBlock.ChildNodes[0].InnerText;
        character.Name = characterName.Replace("\n", "").Replace(" ", "");
        character.WeaponType = ParseWeaponType(characterBlock.ChildNodes[2]);
        character.Description = characterBlock.ChildNodes[4].InnerText;
    }

    private Rarity ParseCharacterRarity(HtmlNode htmlNode)
        => (Rarity)htmlNode.ChildNodes.Where(n => n.Name == "svg").Count() - 2;

    private WeaponType ParseWeaponType(HtmlNode htmlNode)
        => ItemHelper.GetWeaponType(
            htmlNode.ChildNodes.Where(t => t.Name == "p")
                .FirstOrDefault().InnerText);
}  
