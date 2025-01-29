using System;
using System.Collections.Generic;

namespace dotnet_my_platform_api.Models;

public partial class Skill
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Percentage { get; set; }

    public int? LastWeek { get; set; }

    public int? LastMonth { get; set; }

    public bool? IsMainSkill { get; set; }

    public int? OrderIndex { get; set; }
}
