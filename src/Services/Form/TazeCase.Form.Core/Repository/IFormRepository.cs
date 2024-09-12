using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Core.Repository
{
    public interface IFormRepository:IGenericRepository<Core.Entities.Form>
    {
        Task<bool> UpdateActiveStatus(Core.Entities.Form entity);
    }
}
