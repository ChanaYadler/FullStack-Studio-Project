using System;
using System.Collections.Generic;

namespace DAL.DalModels;

public partial class Customer
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
}
