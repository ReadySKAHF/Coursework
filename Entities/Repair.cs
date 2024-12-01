using Entities.Base;
using Entities;
using System.ComponentModel.DataAnnotations;

public class Repair : EntityBase
{
    public Guid CarId { get; set; }
    public virtual Car Car { get; set; }

    public Guid MechanicId { get; set; }
    public virtual Mechanic Mechanic { get; set; }

    public DateTime RepairDate { get; set; }

    [MaxLength(500)]
    public string WorkDescription { get; set; }

    public Guid StatusId { get; set; }  
    public virtual CarStatus Status { get; set; }
}
