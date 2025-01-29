using System;
using System.Collections.Generic;

namespace dotnet_my_platform_api.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string DateRange { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Company { get; set; } = null!;

    public int? OrderIndex { get; set; }
}
