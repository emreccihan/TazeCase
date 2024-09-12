using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Business.DTOs.FormFieldDto
{
    public class FormFieldInputDto
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
        public Guid FormId { get; set; }
    }
}
