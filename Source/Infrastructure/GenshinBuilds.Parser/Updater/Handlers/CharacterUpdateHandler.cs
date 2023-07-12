using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Application;
using GenshinBuilds.Parser.Updater.Handlers.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Parser.Updater.Handlers;

public sealed class CharacterUpdateHandler : BaseUpdateHandler, IUpdateHandler
{
    private readonly IParser<IEnumerable<Character>> _characterParser;

    public CharacterUpdateHandler
        (IUnitOfWork unitOfWork, IParser<IEnumerable<Character>> parser) : base(unitOfWork)
        => (_characterParser) = (parser);

    public async Task<UpdateResult> UpdateAsync(bool isDeepUpdate = false)
    {
        var parseCharacterFromPaimonTask = _characterParser.LoadAsync();
        var repository = UnitOfWork.GetRepository<Character>();
        var characterFromDb = await repository.GetAllAsync();

        var characterInPaimon = await parseCharacterFromPaimonTask;

        if (!characterInPaimon.Any()) return UpdateResult.Create(0, "");
        var differance = characterInPaimon.Except(characterFromDb, new CharacterEqualityComparer());
        await repository.InsertRangeAsync(differance);
        await UnitOfWork.Commit();

        return UpdateResult.Create(differance.Count(), "Data has been updated");
    }
}

internal sealed class CharacterEqualityComparer : IEqualityComparer<Character>
{
    public bool Equals(Character? x, Character? y)
    {
        return x.Name.Equals(y.Name);
    }

    public int GetHashCode([DisallowNull] Character obj)
    {
        return obj.Name.GetHashCode();
    }
}
