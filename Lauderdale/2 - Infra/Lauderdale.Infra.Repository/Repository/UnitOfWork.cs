using Lauderdale.App.Domain.Interfaces.Repository;
using Lauderdale.Repository.Context;

namespace Lauderdale.Infra.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext _context;

        public UnitOfWork(EntitiesContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            if (this._context.ChangeTracker.HasChanges())
                this._context.SaveChanges();
        }
    }
}
