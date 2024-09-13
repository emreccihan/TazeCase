using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;

namespace TazeCase.Form.Business.DTOs.FormDataDto
{
    public class FormDataGroupByFrom
    {
        public Guid FormId { get; set; }
        public FormOutputDto Form { get; set; }
        public List<FormDataBaseOutputModel>FormData { get; set; }
    }
}
