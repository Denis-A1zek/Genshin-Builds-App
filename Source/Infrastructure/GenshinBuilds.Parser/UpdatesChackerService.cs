using GenshinBuilds.Application;
using GenshinBuilds.Application.Common.Models;
using GenshinBuilds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Parser;

struct ParserDetails
{
    public ParserDetails(string url, string pattern, Type type)
    {
        Url = url;
        Pattern = pattern;
        TypeToCheck = type;
    }

    public string Url { get; set; }
    public string Pattern { get; set; }
    public Type TypeToCheck { get; set; }
}

public class UpdatesChackerService : IUpdatesCheckerService
{
    private readonly HtmlWeb _htmlWeb;
    private readonly IUnitOfWork _unitOfWork;

    private readonly List<ParserDetails> parserDetails = new()
    {
        new ParserDetails("https://paimon.moe/characters", "/html/body/div/main/div/div[2]/div[1]/div[2]", typeof(Character)),
        new ParserDetails("https://paimon.moe/weapons","/html/body/div/main/div/div/div[2]/table/tbody", typeof(Weapon))
    };

    public UpdatesChackerService(HtmlWeb htmlWeb, IUnitOfWork unitOfWork)
        => (_htmlWeb, _unitOfWork) = (htmlWeb, unitOfWork);

    public async Task<UpdateDetails> HasUpdateAsync()
    {
        var updateDetails = new UpdateDetails();
        foreach (var details in parserDetails) 
        {
            var inDbCount = await _unitOfWork.GetRepository(details.TypeToCheck).CountAsync();
            var inPaimonCount = await EntityQuantityParser(details.Url, details.Pattern);

            if(inPaimonCount > inDbCount)
                updateDetails.AvailableUpdates.Add(details.TypeToCheck.Name);
        }

        return updateDetails;
    }

    public Task<UpdateResult> UpdateDataAsync
        (IEnumerable<string> updatableTypes = null, bool isDeep = false)
    {     
        throw new NotImplementedException();
    }

    private async Task<int> EntityQuantityParser(string url, string parsePattern)
    {
        var htmlDocument = await _htmlWeb.LoadFromWebAsync(url);
        var block = htmlDocument.DocumentNode.SelectSingleNode(parsePattern);
        var count = block.ChildNodes.Count;
        return count;
    }
}
