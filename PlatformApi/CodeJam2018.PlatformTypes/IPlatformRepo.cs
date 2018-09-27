using System;
using System.Collections.Generic;
using System.Text;
using Api.ErrorHandling.Models;

namespace CodeJam2018.PlatformTypes
{
    public interface IPlatformRepo
    {
        (IPlatform, ErrorResult) Create(IPlatform platform);
        (IPlatform, ErrorResult) Read(int id);
        (IList<IPlatform>, ErrorResult) ReadAll();
        (IPlatform, ErrorResult) Update(IPlatform platform);
        ErrorResult Delete(int id);
    }
}
