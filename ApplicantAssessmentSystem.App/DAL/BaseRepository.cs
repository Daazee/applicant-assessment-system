using ApplicantAssessmentSystem.App.Context;
using ApplicantAssessmentSystem.App.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantAssessmentSystem.App.DAL
{

    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private ApplicantAssessmentContext context;

        public BaseRepository(ApplicantAssessmentContext _context)
        {
            context = _context;
        }
        //ApplicantAssessmentContext context = ContextManager.GetContext();

        public async Task<T> GetItem(int id)
        {
            var model = await context.Set<T>().FindAsync(id);
            return model;
        }

        // gets list of items async
        public async Task<IEnumerable<T>> GetItems()
        {
            var result = await context.Set<T>().ToListAsync();
            return result;
        }


        public async Task<T> AddItem(T item)
        {
            context.Set<T>().Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        // updates an entity in a set
        public async Task<T> UpdateItem(T item)
        {
            context.Entry<T>(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return item;
        }

        // removes an entity in a set
        public async Task<T> RemoveItem(int id)
        {
            var query = await context.Set<T>().FindAsync(id);
            if (query != null)
            {
                context.Set<T>().Remove(query);
                await context.SaveChangesAsync();
            }
            return query;
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}