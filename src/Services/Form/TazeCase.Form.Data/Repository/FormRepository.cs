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
    }
}
