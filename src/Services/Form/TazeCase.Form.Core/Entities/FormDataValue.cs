using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Core.Entities
{
    public class FormDataValue:BaseEntity
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
        public Guid FormDataId { get; set; }
        public virtual FormData FormData { get; set; }
    }
}
