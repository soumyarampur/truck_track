using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelTrack.Core.DTO
{
    public class ActionContextDto
    { 
        public int Org { get; set; }
        public int User { get; set; }
        public string Instance_code { get; set; }
        public string DbServer { get; set; }
        public string DbName { get; set; }
        public string UniqueRequestId { get; set; }
    }
}
