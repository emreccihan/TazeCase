
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Business.DTOs.FormDataDto
{
    public class FormDataInputDto
    {
        public string Value { get; set; }
        public Guid FormId { get; set; }
        public Guid FormFieldId { get; set; }

    }
}
