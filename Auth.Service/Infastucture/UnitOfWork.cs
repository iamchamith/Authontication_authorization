using Auth.DbAccess;
using Auth.Domain;
using Auth.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Auth.Bo.Utility.Enums;

namespace Auth.Service.Infastucture
{
    public interface IUnitOfWork
    {
        GenericRepository<Authentication> AuthenticationRepository { get; }
        GenericRepository<Authorization> AuthorizationRepository { get; }
        GenericRepository<Error> ErrorRepository { get; }
        void Save();
        Task SaveAsync();
        AppContext Context { get; }

    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork()
        {
            context = new AppContext();
        }
        public UnitOfWork(IAppContext cnt, AppRunTime type)
        {
            if (type == AppRunTime.Debug)
            {
                context = (AppContext)cnt;
                context.Configuration.AutoDetectChangesEnabled = false;
            }
            else
            {
                context = (AppContext)cnt;
            }
        }
        private DbContext context;
        private GenericRepository<Authentication> authenticationRepository;
        private GenericRepository<Authorization> authorizationRepository;
        private GenericRepository<Error> errorRepository;
        public AppContext Context
        {
            get
            {
                return context as AppContext;
            }
        }
        public GenericRepository<Authorization> AuthorizationRepository
        {
            get
            {
                if (this.authorizationRepository == null)
                {
                    this.authorizationRepository = new GenericRepository<Authorization>(context);
                }
                return authorizationRepository;
            }
        }
        public GenericRepository<Authentication> AuthenticationRepository
        {
            get
            {

                if (this.authenticationRepository == null)
                {
                    this.authenticationRepository = new GenericRepository<Authentication>(context);
                }
                return authenticationRepository;
            }
        }
        GenericRepository<Error> IUnitOfWork.ErrorRepository
        {
            get
            {
                if (this.errorRepository == null)
                {
                    this.errorRepository = new GenericRepository<Error>(context);
                }
                return errorRepository;
            }
        }
  
        public void Save()
        {
            context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
