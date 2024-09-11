using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Core.Entities
{
    public class FormData:BaseEntity
    {
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        public ICollection<FormDataValue> DataValues { get; set; }
    }
}
