using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;

namespace TazeCase.Form.Business.DTOs.FormDataDto
{
    public class FormDataGroupByFrom
    {
        public Guid FormId { get; set; }
        public FormBaseOutputDto Form { get; set; }
        public List<FormFieldDataGroupedDto> FormData { get; set; }
    }

}
