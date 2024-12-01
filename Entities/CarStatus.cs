using Entities.Base;

namespace Entities
{
    public class CarStatus : EntityBase, IEntityBase
    {
        public string StatusName { get; set; } = null!;
        
        public IEnumerable<Repair> Repairs { get; set; }
    }
}

