using System.Collections.Generic;

namespace dotnet_my_platform_api.Models
{
    public partial class GitHubRepo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string HtmlUrl { get; set; } = null!;
        public string? Description { get; set; }
        public string? Language { get; set; }
        public List<string> Topics { get; set; } = new List<string>();
    }
} 