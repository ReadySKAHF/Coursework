using Contracts.Repositories;
using DbAccess.Repositories.Base;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DbAccess.Repositories
{
    public class MechanicRepository : RepositoryBase<Mechanic>, IMechanicRepository
    {
        public MechanicRepository(Context.Context context) : base(context) { }

        public override IQueryable<Mechanic> GetAllWithDependencies() =>
            _context.Mechanics
                .AsNoTracking();

        // Можно добавить дополнительные методы, если нужны специфические запросы для механиков
        public IQueryable<Mechanic> GetMechanicsWithRepairs()
        {
            return _context.Mechanics
                .AsNoTracking()
                .Include(m => m.Repairs)
                .ThenInclude(r => r.Car); // Если нужно загружать также автомобили с ремонтом
        }
    }
}
