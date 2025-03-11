namespace dotnet_my_platform_api.Models;

public partial class Education
{
  public int Id { get; set; }

  public string DateRange { get; set; } = null!;

  public string Title { get; set; } = null!;

  public string Subtitle { get; set; } = null!;

  public int? OrderIndex { get; set; }
}
