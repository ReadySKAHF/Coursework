using Contracts.Repositories;
using DbAccess.Repositories.Base;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DbAccess.Repositories
{
    public class RepairRepository : RepositoryBase<Repair>, IRepairRepository
    {
        public RepairRepository(Context.Context context) : base(context) { }

        public override IQueryable<Repair> GetAllWithDependencies() =>
            _context.Repairs
                .AsNoTracking()
                .Include(r => r.Car) // Загрузить информацию о автомобиле
                .Include(r => r.Mechanic) // Загрузить информацию о механике
                .Include(r => r.Status); // Загрузить статус работы
    }
}
