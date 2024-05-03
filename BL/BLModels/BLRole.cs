namespace DAL.DalModels;

public partial class BLRole
{
    public string Id { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string WorkerId { get; set; } = null!;

    public virtual Worker Worker { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();


}
