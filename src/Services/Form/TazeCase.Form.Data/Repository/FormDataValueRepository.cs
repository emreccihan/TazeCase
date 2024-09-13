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
    public class FormDataValueRepository : GenericRepository<Core.Entities.FormDataValue>, IFormDataRepository
    {
        public FormDataValueRepository(FormDataContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<FormDataValue>> AddListFormData(List<FormDataValue> entities)
        {
            await context.Set<FormDataValue>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
            return entities;
        }
        public async Task<List<FormDataValue>> GetFormDatasByFormId(Guid formId)
        {
            return await context.FormDataValues.Include(q => q.Form).Include(q=>q.FormField).Where(q => q.FormId == formId).ToListAsync();
        }
    }
}
