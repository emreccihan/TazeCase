using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormFieldDto;

namespace TazeCase.Form.Business.DTOs.FormDataDto
{
    public class FormDataBaseOutputModel : BaseDto
    {
        public Guid FormFieldId { get; set; }
        public FormFieldBaseOutputDto FormField { get; set; }
        public string Value { get; set; }
    }
}
