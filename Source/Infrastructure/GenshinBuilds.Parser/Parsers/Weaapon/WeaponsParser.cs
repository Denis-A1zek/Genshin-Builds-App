using HtmlAgilityPack;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Parser.Common;

namespace GenshinBuilds.Parser;

public sealed class WeaponsParser : Parser<IEnumerable<Weapon>>
{
    private const string WEAPONS_LIST_URL = $"{BaseUrl}/weapons";
    
    private readonly WeaponParser _weaponParser;
    
    public WeaponsParser(HtmlWeb web) : base(web)
        => _weaponParser = new WeaponParser(web, BaseUrl);
    
    public override async Task<IEnumerable<Weapon>> LoadAsync()
    {
        var weaponsTable = SelectTableWithWeapons();
        var weapons = await ParseWeaponsFromTableAsync(weaponsTable);
        return weapons;
    }
    
    private HtmlNode SelectTableWithWeapons()
    {
        var htmlDocument = Web.Load(WEAPONS_LIST_URL);
        var weaponsTable = htmlDocument.DocumentNode
            .SelectSingleNode("/html/body/div/main/div/div/div[2]/table/tbody");
        
        return weaponsTable;
    }
    
    private async Task<IEnumerable<Weapon>> ParseWeaponsFromTableAsync(HtmlNode tableNode)
    {
        List<Weapon> weapons = new List<Weapon>();

        await Parallel.ForEachAsync(tableNode.ChildNodes,
            GetParallelOptions(), async (source, token)
                => await ParseWeaponAsync(source, weapons));

        return weapons;
    }
    
    private ParallelOptions GetParallelOptions() =>
        new()
        {
            MaxDegreeOfParallelism
            = Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.75) * 2.0))
        };
    
    private async Task ParseWeaponAsync
        (HtmlNode aNode, List<Weapon> weapons)
    {
        var weaponUrl = GetUrlToTheWeapon(aNode);    
        var weapon = _weaponParser.GetWeaponAsync(weaponUrl);
        weapons.Add(weapon);
    }
    
    private string GetUrlToTheWeapon(HtmlNode aNode)
    {
        var href = aNode.Attributes["href"].Value;
        if (string.IsNullOrEmpty(href)) throw new Exception();

        return $"{BaseUrl}{href}";
    }   
}
