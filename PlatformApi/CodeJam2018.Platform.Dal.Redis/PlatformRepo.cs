using System;
using System.Collections.Generic;
using System.Linq;
using Api.ErrorHandling.Models;
using CodeJam2018.PlatformTypes;

namespace CodeJam2018.Platform.Dal.Redis
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly string _connectionString;

        public PlatformRepo(PlatformDalConfig config)
        {
            _connectionString = config.ConnectionString;
        }

        private IList<IPlatform> _mockPlatforms = new List<IPlatform>()
        {
            new Platform
            {
                Id = 1,
                Name = "Progressive",
                Description = "All applications hosted on Progressive hardware"
            },
            new Platform
            {
                Id = 2,
                Name = "Google",
                Description = "All applications hosted on Google hardware"
            },
            new Platform
            {
                Id = 3,
                Name = "Azure",
                Description = "All applications hosted on Azure hardware"
            }
        };

        public (IPlatform, ErrorResult) Create(IPlatform platform)
        {
            platform.Id = _mockPlatforms.Count;
            _mockPlatforms.Add(platform);
            return (platform, ErrorResult.None);
        }

        public (IPlatform, ErrorResult) Read(int id)
        {
            try
            {
                return (_mockPlatforms.First(mp => mp.Id == id), ErrorResult.None);
            }
            catch (Exception e)
            {
                return (Platform.EmptyPlatform, new ErrorResult(ErrorCode.UnableToReadPlatform, $"We were unable to find a platform using the id:'{id}'", e));
            }
        }

        public (IList<IPlatform>, ErrorResult) ReadAll()
        {
            return (_mockPlatforms, ErrorResult.None);
        }

        public (IPlatform, ErrorResult) Update(IPlatform platform)
        {
            try
            {
                Delete(platform.Id);
                return Create(platform);
            }
            catch (Exception e)
            {
                return (Platform.EmptyPlatform, new ErrorResult(ErrorCode.UnableToUpdatePlatform, $"We were unable to update the platform", e));
            }
        }

        public ErrorResult Delete(int id)
        {
            try
            {
                _mockPlatforms = _mockPlatforms.Where(mp => mp.Id != id).ToList();

                return ErrorResult.None;
            }
            catch (Exception e)
            {
                return new ErrorResult(ErrorCode.UnableToDeletePlatform, $"We were unable to delete a platform using the id:'{id}'", e);
            }
        }
    }
}
