using Entities.Base;

namespace Entities
{
    namespace Entities
    {
        public class Payment : EntityBase, IEntityBase
        {
            public Guid RepairId { get; set; }  // Идентификатор ремонта
            public virtual Repair Repair { get; set; } = null!;  // Ссылка на ремонт

            public DateTime Date { get; set; }  // Дата оплаты

            public decimal Rate { get; set; }  // Тариф

            public decimal Amount { get; set; }  // Сумма оплаты
        }
    }

}
