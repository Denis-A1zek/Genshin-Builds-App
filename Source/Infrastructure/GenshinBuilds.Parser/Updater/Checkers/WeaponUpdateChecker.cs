using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Parser.Updater.Checkers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Parser.Updater.Checkers;

public class WeaponUpdateChecker : BaseUpdateChecker, IUpdateChecker
{
    public WeaponUpdateChecker
        (HtmlWeb htmlWeb, IUnitOfWork unitOfWork) : base(htmlWeb, unitOfWork) { }

    public async Task<UpdateDetails> HasUpdateAsync()
    {
        var inDbCount = await UnitOfWork.GetRepository<Weapon>().CountAsync();
        var inPaimonCount =
            await EntityQuantityParserAsync
                ("https://paimon.moe/weapons", "/html/body/div/main/div/div/div[2]/table/tbody");

        if (inPaimonCount < inDbCount)
            return UpdateDetails.NotUpdated<Weapon>();

        return UpdateDetails.Updated<Weapon>(inPaimonCount - inDbCount);
    }
}
