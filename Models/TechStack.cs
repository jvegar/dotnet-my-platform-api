using System;
using System.Collections.Generic;

namespace dotnet_my_platform_api.Models;

public partial class TechStack
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string IconPath { get; set; } = null!;

    public int? OrderIndex { get; set; }
}
