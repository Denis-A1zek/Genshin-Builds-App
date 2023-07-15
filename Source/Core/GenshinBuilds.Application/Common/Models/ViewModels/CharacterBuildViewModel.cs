using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Models.ViewModels
{
    public sealed record CharacterBuildViewModel
    {
        public int Priority { get; set; }
        public string Title { get; set; }
        
        public List<CharacterBuildItemViewModel> Items { get; set; }
    }
}
