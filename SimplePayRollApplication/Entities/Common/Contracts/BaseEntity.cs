using System;

namespace SimplePayRollApplication.Entities.Common.Contracts;

public class BaseEntity 
{
    public string Id {get; set; } = Guid.NewGuid().ToString().Substring(0, 5);
}