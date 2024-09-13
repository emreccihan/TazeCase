using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Report.Core.Wrappers.Input
{
    public class BaseJson<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Body { get; set; }
        public int? TotalCount { get; set; }
    }
}
