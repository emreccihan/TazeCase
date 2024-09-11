using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Core.Entities
{
    public class FormField : BaseEntity
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; } 
        public bool IsRequired { get; set; }
        public Guid FormId { get; set; }
        public virtual Form Form { get; set; }
    }
}
