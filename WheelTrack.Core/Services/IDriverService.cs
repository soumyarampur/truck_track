using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WheelTrack.Core.DTO;

namespace WheelTrack.Core.Services
{
    public interface IDriverService
    {
        public Task<DriverResponse> CreateDriverAsync(DriverModel orginfo);
    }
}
