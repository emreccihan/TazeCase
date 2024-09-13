using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazeCase.Form.Core.Entities;

namespace TazeCase.Form.Core.Repository
{
    public interface IFormDataRepository: IGenericRepository<Core.Entities.FormDataValue>
    {
        Task<List<FormDataValue>>AddListFormData(List<Core.Entities.FormDataValue> entities);
        Task<List<FormDataValue>> GetFormDatasByFormId(Guid formId);
    }
}
