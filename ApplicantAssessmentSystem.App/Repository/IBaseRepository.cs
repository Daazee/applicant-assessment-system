using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetItem(int id);
        Task<IEnumerable<T>> GetItems();
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task<T> RemoveItem(int id);
    }
}
