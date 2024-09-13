using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Repository;
using TazeCase.Form.Data.Context;

namespace TazeCase.Form.Data.Repository
{
    public class FormRepository : GenericRepository<Core.Entities.Form>, IFormRepository
    {
        public FormRepository(FormDataContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> UpdateActiveStatus(Core.Entities.Form comingEntity)
        {
            var entity = await context.Set<Core.Entities.Form>().FirstOrDefaultAsync(q => q.Id == comingEntity.Id);
            if (entity == null)
                return false;
            entity.IsActive = comingEntity.IsActive;
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
