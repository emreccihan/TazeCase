using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Business.DTOs.FormDto;
using TazeCase.Form.Business.DTOs.FormFieldDto;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Business.DTOs.FormDataDto
{
    public class FormDataOutputDto: FormDataBaseOutputModel
    {
        public FormBaseOutputDto Form { get; set; }
        public Guid FormId { get; set; }
    }
    
}
