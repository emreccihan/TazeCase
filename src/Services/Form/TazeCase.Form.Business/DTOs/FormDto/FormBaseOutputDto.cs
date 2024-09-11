using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Business.DTOs.FormDto
{
    public class FormBaseOutputDto : BaseDto
    {
        public string FormName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
