using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Builders;
using GenshinBuilds.Domain.Builders;


namespace GenshinBuilds.Parser;

internal sealed class WeaponParser 
{
    private readonly HtmlWeb _web;
    private readonly string _baseUrl;
    private readonly IValueConverter _valueConverter;

    public WeaponParser(HtmlWeb web, string baseUrl, IValueConverter valueConverter)
        => (_web, _baseUrl, _valueConverter) = (web, baseUrl, valueConverter);

    public Weapon GetWeaponAsync(string source)
    {
        var weaponsBlockDiv = GetWeaponsBlock(source);
        var weapon = ParseWeaponsBlock(weaponsBlockDiv);
        return weapon;
    }

    private HtmlNode GetWeaponsBlock(string source)
    {
        var document = _web.Load(source);
        var weaponsBlock = document.DocumentNode
            .SelectSingleNode("/html/body/div/main/div/div");
        
        return weaponsBlock;
    }

    private Weapon ParseWeaponsBlock(HtmlNode weaponsBlockDiv)
    {
        Weapon weapon = new();
        weapon = CreateWeapon(weaponsBlockDiv.ChildNodes[0]);
        weapon.Image = $"{_baseUrl}{weaponsBlockDiv.ChildNodes[2].Attributes[1].Value}";

        return weapon;
    }

    private Weapon CreateWeapon(HtmlNode node)
        => new WeaponBuilder(_valueConverter)
        .Create()
        .SetTile(node.ChildNodes[0].InnerText.Trim('\\', '"'))
        .SetRarity((Rarity)GetWeaponRarity(node.ChildNodes[2]))
        .SetType(GetWeaponTypeName(node.ChildNodes[2]))
        .SetModifire(GetWeaponModifier(node.ChildNodes[6]))
        .SetDescription(node.ChildNodes[4].InnerText)
        .Build();


    /// <summary>
    /// Parses weapon type from a node
    /// </summary>
    /// <param name="htmlNode">Noda which contains type</param>
    /// <returns>Type of weapon</returns>
    private string GetWeaponTypeName(HtmlNode htmlNode)
        => htmlNode.ChildNodes.Where(n => n.Name == "p").FirstOrDefault()?.InnerText ?? "None";

    /// <summary>
    /// Parses weapon rarity from a node
    /// </summary>
    /// <param name="htmlNode">Noda which contains rarity</param>
    /// <returns>Rarity of weapon</returns>
    private int GetWeaponRarity(HtmlNode htmlNode)
        => htmlNode.ChildNodes.Where(n => n.Name == "svg").Count() - 2;

    /// <summary>
    /// Parses weapon modifier from a node
    /// </summary>
    /// <param name="htmlNode">Noda which contains modifiers</param>
    /// <returns>Modifier of weapon</returns>
    private Modifire GetWeaponModifier(HtmlNode htmlNode)
    {
        if (string.IsNullOrEmpty(htmlNode.InnerHtml))
            return new Modifire();

        var modifier = new Modifire();
        modifier.Title = htmlNode.ChildNodes[0].InnerText;
        modifier.Description = htmlNode.ChildNodes[2].InnerText;
        return modifier;
    }
}
