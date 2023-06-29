using GenshinBuilds.Domain.Enum;
using GenshinBuilds.Domain.Models;
using GenshinBuilds.Parser.Helpers;
using HtmlAgilityPack;

namespace GenshinBuilds.Parser;

internal sealed class WeaponParser 
{
    private readonly HtmlWeb _web;
    private readonly string _baseUrl;

    public WeaponParser(HtmlWeb web, string baseUrl)
        => (_web, _baseUrl) = (web, baseUrl);

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
        foreach (var item in weaponsBlockDiv.ChildNodes)
        {
            if (item.Name.Equals("img"))
                weapon.Image = $"{_baseUrl}{item.Attributes[1].Value}";

            if (!item.Name.Equals("div"))
                continue;

            weapon = CreateWeapon(item);
        }
        return weapon;
    }

    private Weapon CreateWeapon(HtmlNode node)
        => new Weapon()
        {
            Title = node.ChildNodes[0].InnerText.Trim('\\', '"'),
            Rarity = (Rarity)GetWeaponRarity(node.ChildNodes[2]),
            Type = ItemHelper.GetWeaponType(GetWeaponTypeName(node.ChildNodes[2])),
            Modifier = GetWeaponModifier(node.ChildNodes[6]),
            Description = node.ChildNodes[4].InnerText
        };

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
