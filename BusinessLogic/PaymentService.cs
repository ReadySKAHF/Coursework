using BusinessLogic.Base;
using Contracts.Mapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.Entities;
using Entities.Exceptions;
using Entities.Pagination;

namespace BusinessLogic
{
    public class PaymentService : BaseService<Payment>, IPaymentService
    {
        private readonly IRepairRepository _repairRepository;

        public PaymentService(IPaymentRepository repository, IRepairRepository repairRepository, IMapperService mapperService)
            : base(repository, mapperService)
        {
            _repairRepository = repairRepository;
        }

        public override PagedList<TDto> GetByPage<TDto>(PaginationQueryParameters parameters)
        {
            var payments = _repository
                .GetAllWithDependencies()
                .Skip((parameters.page - 1) * parameters.pageSize)
                .Take(parameters.pageSize);

            var count = _repository.Count();

            var paymentDtos = _mapperService.Map<IQueryable<Payment>, IEnumerable<TDto>>(payments);

            return new PagedList<TDto>(paymentDtos.ToList(), count, parameters.page, parameters.pageSize);
        }

        public override PagedList<TDto> GetByPageWithConditions<TDto>(PaginationQueryParameters parameters, Func<Payment, bool> condition)
        {
            var payments = _repository
                .GetAllWithDependencies()
                .Where(condition)
                .Skip((parameters.page - 1) * parameters.pageSize)
                .Take(parameters.pageSize);

            var count = _repository.Count();

            var paymentDtos = _mapperService.Map<IEnumerable<Payment>, IEnumerable<TDto>>(payments);

            return new PagedList<TDto>(paymentDtos.ToList(), count, parameters.page, parameters.pageSize);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var payment = await _repository.FindByIdAsync(id);
            if (payment == null)
                throw new NotFoundException("Payment not found.");

            await _repository.DeleteAsync(payment);
            await _repository.SaveChangesAsync();
        }
    }
}
