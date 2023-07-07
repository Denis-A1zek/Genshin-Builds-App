using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain.Models.Common;
using GenshinBuilds.Parser.Helpers;

namespace GenshinBuilds.Parser;

internal class CharacterParser
{
    private readonly HtmlWeb _web;
    private readonly string _baseUrl;
    private readonly ICharacterBuilder _characterBuilder;

    public CharacterParser(HtmlWeb web, string baseUrl, ICharacterBuilder characterBuilder)
        => (_web, _baseUrl, _characterBuilder) = (web, baseUrl, characterBuilder);

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
        => _characterBuilder.SetName(GetCharacterName(characterBlock))
            .SetWeaponType(ParseWeaponType(characterBlock.ChildNodes[2]))
            .SetDescription(characterBlock.ChildNodes[4].InnerText)
            .SetElement(characterBlock.ChildNodes[0].SelectSingleNode("img").Attributes["src"].Value)
            .SetElementImage(characterBlock.ChildNodes[0].SelectSingleNode("img").Attributes["src"].Value)
            .SetRarity(ParseCharacterRarity(characterBlock.ChildNodes[2]))
            .Build();

    private string GetCharacterName(HtmlNode nameNode)
        => nameNode.ChildNodes[0].InnerText.Replace("\n", "").Replace(" ", "");

    private Rarity ParseCharacterRarity(HtmlNode htmlNode)
        => (Rarity)htmlNode.ChildNodes.Where(n => n.Name == "svg").Count() - 2;


    //TO-DO
    private WeaponType ParseWeaponType(HtmlNode htmlNode)
        => WeaponType.None;
}  
