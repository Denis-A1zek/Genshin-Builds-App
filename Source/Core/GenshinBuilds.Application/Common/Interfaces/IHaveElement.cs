using GenshinBuilds.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Application.Common.Interfaces;

public interface IHaveElement
{
    public Element Element { get; set; }
}
