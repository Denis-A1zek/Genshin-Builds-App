using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinBuilds.Domain.Models.Common;

public abstract record Identity
{
    [Key]
    public Guid Id { get; set; }
}
