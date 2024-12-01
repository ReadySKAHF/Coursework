using BusinessLogic.Base;
using Contracts.Mapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities;
using Entities.Exceptions;
using Entities.Pagination;

namespace BusinessLogic
{
    public class RepairService : BaseService<Repair>, IRepairService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMechanicRepository _mechanicRepository;

        public RepairService(IRepairRepository repository, ICarRepository carRepository, IMechanicRepository mechanicRepository, IMapperService mapperService)
            : base(repository, mapperService)
        {
            _carRepository = carRepository;
            _mechanicRepository = mechanicRepository;
        }

        public override PagedList<TDto> GetByPage<TDto>(PaginationQueryParameters parameters)
        {
            var repairs = _repository
                .GetAllWithDependencies()
                .Skip((parameters.page - 1) * parameters.pageSize)
                .Take(parameters.pageSize);

            var count = _repository.Count();

            var repairDtos = _mapperService.Map<IQueryable<Repair>, IEnumerable<TDto>>(repairs);

            return new PagedList<TDto>(repairDtos.ToList(), count, parameters.page, parameters.pageSize);
        }

        public override PagedList<TDto> GetByPageWithConditions<TDto>(PaginationQueryParameters parameters, Func<Repair, bool> condition)
        {
            var repairs = _repository
                .GetAllWithDependencies()
                .Where(condition)
                .Skip((parameters.page - 1) * parameters.pageSize)
                .Take(parameters.pageSize);

            var count = _repository.Count();

            var repairDtos = _mapperService.Map<IEnumerable<Repair>, IEnumerable<TDto>>(repairs);

            return new PagedList<TDto>(repairDtos.ToList(), count, parameters.page, parameters.pageSize);
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var repair = await _repository.FindByIdAsync(id);
            if (repair == null)
                throw new NotFoundException("Repair not found.");

            await _repository.DeleteAsync(repair);
            await _repository.SaveChangesAsync();
        }
    }
}
