using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;

namespace TazeCase.Form.Business.DTOs.FormFieldDto
{
    public class FormFieldGroupByFormDto
    {
        public Guid FormId { get; set; }
        public FormOutputDto Form {  get; set; }    
        public List<FormFieldBaseOutputDto>FormFields { get; set; }
    }
    
}
