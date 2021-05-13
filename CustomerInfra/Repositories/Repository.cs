using CustomerInfra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly CrudProjeto_dbContext context;
        private DbSet<T> table = null;

        public Repository(CrudProjeto_dbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            table.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await table.FindAsync(id);
            if(entity == null)
            {
                return entity;
            }

            table.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
