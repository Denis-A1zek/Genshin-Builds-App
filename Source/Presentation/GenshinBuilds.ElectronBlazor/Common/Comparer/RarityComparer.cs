using GenshinBuilds.Domain.Interfaces;
using GenshinBuilds.Domain.Models;

namespace GenshinBuilds.ElectronBlazor.Common.Comparer;

public class RarityComparer<T> : IComparer<T> where T : IRare
{
    public int Compare(T x, T y)
    {
        if (x.Rarity < y.Rarity) return 1;
        else if (x.Rarity == y.Rarity) return 0;
        else return -1;
    }
}
