using System;
using System.Collections.Generic;

namespace dotnet_my_platform_api.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string IconPath { get; set; } = null!;

    public int? OrderIndex { get; set; }
}
