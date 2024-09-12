using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Data.Context;

namespace TazeCase.Form.Data.Repository
{
    public class FormFieldRepository : GenericRepository<Core.Entities.FormField>, IFormFieldRepository
    {
        public FormFieldRepository(FormDataContext dbContext) : base(dbContext)
        {

        }
    }
}
