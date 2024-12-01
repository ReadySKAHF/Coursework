using BusinessLogic.Base;
using Contracts.Mapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.Exceptions;
using Entities.Pagination;

namespace BusinessLogic
{
    public class MechanicService : BaseService<Mechanic>, IMechanicService
    {
        private readonly IRepairRepository _repairRepository;

        public MechanicService(IMechanicRepository repository, IRepairRepository repairRepository, IMapperService mapperService)
            : base(repository, mapperService)
        {
            _repairRepository = repairRepository;
        }

        public override PagedList<TDto> GetByPage<TDto>(PaginationQueryParameters parameters)
        {
            var mechanics = _repository
                .GetAllWithDependencies()
                .Skip((parameters.page - 1) * parameters.pageSize)
                .Take(parameters.pageSize);

            var count = _repository.Count();

            var mechanicDtos = _mapperService.Map<IQueryable<Mechanic>, IEnumerable<TDto>>(mechanics);

            return new PagedList<TDto>(mechanicDtos.ToList(), count, parameters.page, parameters.pageSize);
        }

        public override PagedList<TDto> GetByPageWithConditions<TDto>(PaginationQueryParameters parameters, Func<Mechanic, bool> condition)
        {
            var mechanics = _repository
                .GetAllWithDependencies()
                .Where(condition)
                .Skip((parameters.page - 1) * parameters.pageSize)
                .Take(parameters.pageSize);

            var count = _repository.Count();

            var mechanicDtos = _mapperService.Map<IEnumerable<Mechanic>, IEnumerable<TDto>>(mechanics);

            return new PagedList<TDto>(mechanicDtos.ToList(), count, parameters.page, parameters.pageSize);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var mechanic = await _repository.FindByIdAsync(id);
            if (mechanic == null)
                throw new NotFoundException("Mechanic not found.");

            var repairs = _repairRepository.FindByCondition(r => r.MechanicId == mechanic.Id).ToArray();
            foreach (var repair in repairs)
            {
                await _repairRepository.DeleteAsync(repair);
            }

            await _repository.DeleteAsync(mechanic);
            await _repository.SaveChangesAsync();
        }
    }
}
