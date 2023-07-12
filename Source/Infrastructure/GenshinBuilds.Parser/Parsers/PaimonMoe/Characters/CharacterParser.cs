using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Domain.Models.Common;
using System.Xml.Linq;


namespace GenshinBuilds.Parser;

internal class CharacterParser
{
    private readonly HtmlWeb _web;
    private readonly string _baseUrl;
    private readonly IValueConverter _valueConverter;

    public CharacterParser(HtmlWeb web, string baseUrl, IValueConverter valueConverter)
        => (_web, _baseUrl, _valueConverter) = (web, baseUrl, valueConverter);

    public async Task<Character> GetCharacterAsync(string source)
    {
        var characterBlock = await LoadCharacterBlock(source);
        var character =  ParseCharacterBlock(characterBlock);     

        return character;
    }

    private async Task<HtmlNode> LoadCharacterBlock(string source)
    {
        var document = await _web.LoadFromWebAsync(source);
        var characterBlock = document.DocumentNode
            .SelectSingleNode("/html[1]/body[1]/div[1]/main/div[1]/div[1]/div[1]");

        return characterBlock;
    }

    private Character ParseCharacterBlock(HtmlNode characterBlock)
    {
        var characterInfoBlock = characterBlock.SelectSingleNode("div");

        var character = CreateCharacter(characterInfoBlock);
        character.FullImage = $"{_baseUrl}{characterBlock.ChildNodes[0].Attributes["src"].Value}";

        return character;
    }

    private Character CreateCharacter(HtmlNode characterBlock)
        => new CharacterBuilder(_valueConverter)
            .Create()
            .SetName(GetCharacterName(characterBlock))
            .SetWeaponType(ParseWeaponType(characterBlock.ChildNodes[2]))
            .SetDescription(characterBlock.ChildNodes[4].InnerText)
            .SetElement(characterBlock.ChildNodes[0].SelectSingleNode("img").Attributes["src"].Value)
            .SetElementImage(characterBlock.ChildNodes[0].SelectSingleNode("img").Attributes["src"].Value)
            .SetRarity(ParseCharacterRarity(characterBlock.ChildNodes[2]))
            .SetWeaponType(ParseWeaponType(characterBlock.ChildNodes[2]))
            .Build();

    private string GetCharacterName(HtmlNode nameNode)
    {
        var fullName = nameNode.ChildNodes[0].InnerText.Replace("\n", "").Replace(" ", "");
        var nameLenght = string.Concat(fullName.Skip(1).TakeWhile(s => char.IsLower(s)));
        var name = string.Concat(fullName.Take(nameLenght.Count() + 1));
        var lastName = string.Concat(fullName.Skip(nameLenght.Count() + 1));

        if (lastName.Count() > 1)
            return $"{name} {lastName}";

        return fullName;
    }

    private Rarity ParseCharacterRarity(HtmlNode htmlNode)
        => (Rarity)htmlNode.ChildNodes.Where(n => n.Name == "svg").Count() - 1;


    //TO-DO
    private string ParseWeaponType(HtmlNode htmlNode)
        => htmlNode.ChildNodes["p"].InnerText;
}  
