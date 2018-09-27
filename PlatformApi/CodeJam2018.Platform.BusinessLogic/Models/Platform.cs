using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Api.ErrorHandling.Models;
using CodeJam2018.PlatformTypes;

namespace CodeJam2018.Platform.BusinessLogic.Models
{
    public class Platform : IPlatform
    {
        public static IPlatform EmptyPlatform = new Platform
        {
            Id = -999,
            Name = "!@#EMPTY Platform#@!",
            Description = "programatic representation of an invalid platform"
        };

        public Platform(IPlatform platform)
        {
            this.Id = platform.Id;
            this.Name = platform.Name;
            this.Description = platform.Description;
        }

        public Platform()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public static bool IsValidId(IPlatform platform)
        {
            return IsValidId(platform.Id);
        }

        public static bool IsValidId(int id)
        {
            return (id > 0);
        }

        public (bool, ErrorResult) IsValidForCreation()
        {
            var invalidFields = new List<string>();
            if (Id > 0)
            {
                invalidFields.Add(nameof(Id));
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                invalidFields.Add(nameof(Name));
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                invalidFields.Add(nameof(Description));
            }

            return invalidFields.Any() 
                ? (false, new ErrorResult(ErrorCode.UnableToCreatePlatform, $"The platform data that was supplied has the following invalid properties:'{string.Join(",", invalidFields)}'")) 
                : (true, ErrorResult.None);
        }

        public (bool, ErrorResult) IsValidForUpdate()
        {
            var invalidFields = new List<string>();
            if (IsValidId(Id))
            {
                invalidFields.Add(nameof(Id));
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                invalidFields.Add(nameof(Name));
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                invalidFields.Add(nameof(Description));
            }

            return invalidFields.Any()
                ? (false, new ErrorResult(ErrorCode.UnableToUpdatePlatform, $"The platform data that was supplied has the following invalid properties:'{string.Join(",", invalidFields)}'"))
                : (true, ErrorResult.None);
        }
    }
}
