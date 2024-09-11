using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Business.DTOs
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
