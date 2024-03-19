using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class BLMeeting
{
    
    public string Id { get; set; } = null!;

    public DateTime Date { get; set; }

    public string WorkerId { get; set; } = null!;

    public string CustomersId { get; set; } = null!;

    public virtual Customer Customers { get; set; } = null!;

    public virtual Worker Worker { get; set; } = null!;

}
