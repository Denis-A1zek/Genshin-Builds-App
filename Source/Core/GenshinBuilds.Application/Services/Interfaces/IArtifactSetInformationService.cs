using GenshinBuilds.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Services.Interfaces
{
    public interface IArtifactSetInformationService
    {
        public Task<IEnumerable<MinimalArtifactSet>> GetAllMinimalArtifactSetInfo();
        public Task<MinimalArtifact> GetAllMinmialArtifactInfo();
    }
}
