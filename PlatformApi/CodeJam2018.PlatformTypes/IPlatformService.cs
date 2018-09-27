using System;
using System.Collections.Generic;
using System.Text;
using Api.ErrorHandling.Models;

namespace CodeJam2018.PlatformTypes
{
    public interface IPlatformService
    {
        (IPlatform, ErrorResult) Create(IPlatform candidatePlatform);
        (IPlatform, ErrorResult) Read(int id);
        (IList<IPlatform>, ErrorResult) ReadAll();
        (IPlatform, ErrorResult) Update(IPlatform candidatePlatform);
        ErrorResult Delete(int id);
    }
}
