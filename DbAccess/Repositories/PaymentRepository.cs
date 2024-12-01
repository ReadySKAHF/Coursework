using Contracts.Repositories;
using DbAccess.Repositories.Base;
using Entities;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbAccess.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(Context.Context context) : base(context) { }

        public override IQueryable<Payment> GetAllWithDependencies() =>
            _context.Payments
                .AsNoTracking()
                .Include(p => p.Repair)
                .ThenInclude(r => r.Mechanic); 
    }
}
