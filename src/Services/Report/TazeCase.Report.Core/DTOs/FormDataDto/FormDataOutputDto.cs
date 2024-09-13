using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Report.Core.DTOs.FormDto;

namespace TazeCase.Report.Core.DTOs.FormDataDto
{
    public class FormDataOutputDto
    {
        public Guid FormId { get; set; }
        public FormOutputDto Form { get; set; }
        public List<FormFieldData> FormData { get; set; }

    }
    public class FormFieldData
    {
        public Guid FormFieldId { get; set; }
        public FormFieldDetails FormField { get; set; }
        public string Value { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class FormFieldDetails
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
