using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.GenshinDbApi.Common.Models
{
    internal record CharacterImages(
         string Image,
         string Card,
         string Portrait,
         string Icon,
         string Sideicon,
         string HoyolabAvatar,
         string Nameicon,
         string Nameiconcard,
         string Namesideicon,
         string Cover1,
         string Cover2,
         string Namegachasplash,
         string Namegachaslice
    );
}
