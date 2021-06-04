using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectChannel.WebApi.Models
{
    public class TodoTask : BaseClass
    {
        public string Description { get; set; }
        public bool IsCreated { get; set; }
    }
}
