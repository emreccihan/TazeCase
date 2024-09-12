using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;

namespace TazeCase.Form.Business.DTOs.FormFieldDto
{
    public class FormFieldBaseOutputDto:BaseDto
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
        public FormOutputDto Form {  get; set; }
    }
}
