using Domain.Interfaces.Generics;
using Infrastructure.Configurations.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Generics
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<BaseDbContext> _optionsBuilder;
        public GenericRepository()
        {
            _optionsBuilder = new DbContextOptions<BaseDbContext>();
        }
        //===============Métodos CRUD===============================
        public async Task Add(T Object)
        {
            using (var data = new BaseDbContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Object)
        {
            using (var data = new BaseDbContext(_optionsBuilder))
            {
                data.Set<T>().Remove(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task UpDate(T Object)
        {
            using (var data = new BaseDbContext(_optionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        //===============Métodos para pesquisa======================
        public async Task<T> getEntityById(int Id)
        {
            using (var data = new BaseDbContext(_optionsBulder))
            {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new BaseDbContext(_optionsBulder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        #region Dispose https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        ~GenericRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}

    }
}
