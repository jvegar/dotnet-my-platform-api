using System;
using System.Collections.Generic;

namespace dotnet_my_platform_api.Models;

public partial class PersonalInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public int? ProjectsCount { get; set; }
}
