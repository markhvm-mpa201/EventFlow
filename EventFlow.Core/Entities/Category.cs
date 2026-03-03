using EventFlow.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventFlow.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}
