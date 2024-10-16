﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Core.Entities
{
    public class FormDataValue:BaseEntity
    {
        public Guid FormFieldId { get; set; }
        public virtual FormField FormField { get; set; }
        public string Value { get; set; }
        public Guid FormId { get; set; }
        public virtual Form Form{ get; set; }
    }
}
