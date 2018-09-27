using System;
using System.Collections.Generic;
using Api.ErrorHandling.Models;
using CodeJam2018.PlatformTypes;

namespace CodeJam2018.Platform.BusinessLogic
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepo _repo;

        public PlatformService(IPlatformRepo repo)
        {
            _repo = repo;
        }

        public (IPlatform, ErrorResult) Create(IPlatform candidatePlatform)
        {
            var platform = new Models.Platform(candidatePlatform);
            var (isValid, isValidForCreationErrorResult) = platform.IsValidForCreation();
            if (!isValid)
            {
                return (Models.Platform.EmptyPlatform, isValidForCreationErrorResult);
            }

            (IPlatform createdPlatform, ErrorResult errorResult) = _repo.Create(platform);

            if (errorResult != ErrorResult.None)
            {
                return (Models.Platform.EmptyPlatform, errorResult);
            }

            return (createdPlatform, ErrorResult.None);
        }

        public (IPlatform, ErrorResult) Read(int id)
        {
            if (!Models.Platform.IsValidId(id))
            {
                return (Models.Platform.EmptyPlatform, new ErrorResult(ErrorCode.InvalidPlatformId, $"The Id of the Platform you are attempting to retrieve is invalid. The Id that was provided was:'{id}'"));
            }

            (IPlatform readPlatform, ErrorResult errorResult) = _repo.Read(id);

            if (errorResult != ErrorResult.None)
            {
                return (Models.Platform.EmptyPlatform, errorResult);
            }

            return (readPlatform, ErrorResult.None);
        }

        public (IList<IPlatform>, ErrorResult) ReadAll()
        {
            (IList<IPlatform> allPlatforms, ErrorResult errorResult) = _repo.ReadAll();

            if (errorResult != ErrorResult.None)
            {
                return (new List<IPlatform>(), errorResult);
            }

            return (allPlatforms, ErrorResult.None);
        }

        public (IPlatform, ErrorResult) Update(IPlatform candidatePlatform)
        {
            var platform = new Models.Platform(candidatePlatform);
            var (isValid, isValidForUpdateErrorResult) = platform.IsValidForUpdate();
            if (!isValid)
            {
                return (Models.Platform.EmptyPlatform, isValidForUpdateErrorResult);
            }

            (IPlatform updatedPlatform, ErrorResult errorResult) = _repo.Update(platform);

            if (errorResult != ErrorResult.None)
            {
                return (Models.Platform.EmptyPlatform, errorResult);
            }

            return (updatedPlatform, ErrorResult.None);
        }

        public ErrorResult Delete(int id)
        {
            if (!Models.Platform.IsValidId(id))
            {
                return new ErrorResult(ErrorCode.InvalidPlatformId, $"The Id of the Platform you are attempting to retrieve is invalid. The Id that was provided was:'{id}'");
            }

            ErrorResult errorResult = _repo.Delete(id);

            if (errorResult != ErrorResult.None)
            {
                return errorResult;
            }

            return ErrorResult.None;
        }
    }
}
