using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Parser.Updater.Checkers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Parser.Updater.Checkers;

public class CharacterUpdateChecker : BaseUpdateChecker, IUpdateChecker<Character>
{
    public CharacterUpdateChecker
        (HtmlWeb htmlWeb, IUnitOfWork unitOfWork) : base(htmlWeb, unitOfWork) { }

    public async Task<UpdateDetails> HasUpdateAsync()
    {
        var inDbCount = await UnitOfWork.GetRepository<Character>().CountAsync();
        var inPaimonCount =
            await EntityQuantityParserAsync
                ("https://paimon.moe/characters", "/html/body/div/main/div/div[2]/div[1]/div[2]");

        if (inPaimonCount < inDbCount)
            return UpdateDetails.NotUpdated<Character>();

        return UpdateDetails.Updated<Character>(inPaimonCount - inDbCount);
    }
}
