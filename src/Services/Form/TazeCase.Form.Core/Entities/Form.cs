using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Core.Entities
{
    public class Form : BaseEntity
    {
        public string FormName { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<FormField> Fields { get; set; }
        public virtual ICollection<FormDataValue> FormData{ get; set; }
        public bool IsActive { get; set; } = true;
    }
}
