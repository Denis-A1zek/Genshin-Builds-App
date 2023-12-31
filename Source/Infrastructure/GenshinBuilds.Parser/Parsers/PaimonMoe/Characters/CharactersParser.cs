﻿using GenshinBuilds.Application;
using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Parser.Common;

namespace GenshinBuilds.Parser;

public class CharactersParser : Parser<IEnumerable<Character>>
{
    private const string WEAPONS_LIST_URL = $"{BaseUrl}/characters";

    private readonly CharacterParser _characterParser;

    public CharactersParser(HtmlWeb web, IValueConverter converter) : base(web)
        => _characterParser = new CharacterParser(web, BaseUrl, converter);

    public override async Task<IEnumerable<Character>> LoadAsync()
    {
        var charactersBlock = SelectCharactersBlock();  
        
        var characters = await ParseCharactersDetails(charactersBlock);

        return characters;
    }

    private HtmlNode SelectCharactersBlock()
    {
        var document = Web.Load(WEAPONS_LIST_URL);
        var charactersBlock = document.DocumentNode
            .SelectSingleNode("/html[1]/body[1]/div[1]/main/div[1]/div[2]/div[1]/div[2]");
        return charactersBlock;
    }

    private async Task<IEnumerable<Character>> ParseCharactersDetails
        (HtmlNode charactersBlock)
    {
        List<Character> characters = new List<Character>();

        await Parallel.ForEachAsync(charactersBlock.ChildNodes,
            GetParallelOptions(), async (source, token)
                => await ParseCharacter(source, characters));

        return characters;
    }

    private ParallelOptions GetParallelOptions() =>
       new()
       {
           MaxDegreeOfParallelism
           = Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.75) * 2.0))
       };

    private async Task ParseCharacter(HtmlNode aNode, List<Character> characters)
    {
        var characterUrl = GetUrlToCharacter(aNode);
        var avatarBlock = $"{BaseUrl}{aNode.SelectSingleNode("div[1]/img").Attributes["src"].Value}";
        var character = await _characterParser.GetCharacterAsync(characterUrl);
        character.Avatar = avatarBlock;
        characters.Add(character);
    }

    private string GetUrlToCharacter(HtmlNode aNode)
    {
        var href = aNode.Attributes["href"].Value;
        if (string.IsNullOrEmpty(href)) throw new Exception();

        return $"{BaseUrl}{href}";
    }
}
