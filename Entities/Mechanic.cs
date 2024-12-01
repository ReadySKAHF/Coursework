using Entities.Base;

namespace Entities
{
    public class Mechanic : EntityBase, IEntityBase
    {
        public string FullName { get; set; } = null!;

        public string Qualification { get; set; } = null!;

        public int Experience { get; set; } // Стаж механика в годах

        public decimal Salary { get; set; } // Оклад механика

        public virtual ICollection<Repair> Repairs { get; set; } = new List<Repair>();
    }
}

