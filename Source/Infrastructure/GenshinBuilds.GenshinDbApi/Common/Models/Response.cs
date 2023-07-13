using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.GenshinDbApi.Common.Models
{
    internal record class Response<T>(
         string Query,
         string Folder,
         string Match,
         string Matchfolder,
         string Matchtype,
         IReadOnlyList<string> Filename,
         IReadOnlyList<T> Result
    );
}
