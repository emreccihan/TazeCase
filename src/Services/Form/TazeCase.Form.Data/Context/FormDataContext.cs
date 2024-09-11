using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Data.Context
{
    public class FormDataContext: DbContext
    {
        public FormDataContext(DbContextOptions<FormDataContext> options) : base(options)
        {

        }
    }
}
