using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Data.Context;

namespace TazeCase.Form.Data.Repository
{
    public class FormFieldRepository : GenericRepository<Core.Entities.FormField>, IFormFieldRepository
    {
        public FormFieldRepository(FormDataContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<FormField>> GetFormFieldsByFormId(Guid formId)
        {
            return await context.FormFields.Include(q=>q.Form).Where(q => q.FormId == formId).ToListAsync();
        }
    }
}
