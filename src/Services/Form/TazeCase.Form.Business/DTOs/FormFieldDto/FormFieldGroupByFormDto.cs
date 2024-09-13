using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDataDto;
using TazeCase.Form.Business.DTOs.FormDto;

namespace TazeCase.Form.Business.DTOs.FormFieldDto
{
    public class FormFieldGroupByFormDto
    {
        public Guid FormId { get; set; }
        public FormBaseOutputDto Form {  get; set; }    
        public List<FormFieldBaseOutputDto>FormFields { get; set; }
    }

    public class FormFieldDataGroupedDto
    {
        public Guid FormFieldId { get; set; }
        public FormFieldBaseOutputDto FormField { get; set; }
        public List<FormDataValueDto> Data { get; set; } // New field for the values
    }
}
