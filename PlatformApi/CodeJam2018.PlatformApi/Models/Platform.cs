using CodeJam2018.PlatformTypes;

namespace CodeJam2018.PlatformApi.Models
{
    public class Platform : IPlatform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
