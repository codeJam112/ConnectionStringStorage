using CodeJam2018.PlatformTypes;

namespace CodeJam2018.Platform.Dal.Redis
{
    public class Platform : IPlatform
    {
        public static IPlatform EmptyPlatform = new Platform
        {
            Id = -999,
            Name = "!@#EMPTY Platform#@!",
            Description = "programatic representation of an invalid platform"
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
