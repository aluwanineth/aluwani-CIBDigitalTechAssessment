using CIBDigitalTechAssessment.Core.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> ListAll();
        Task<T> Add(T entity);
    }
}
