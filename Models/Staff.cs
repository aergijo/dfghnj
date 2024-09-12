using System;
using System.Collections.Generic;

namespace ccaaffee.Models;

public partial class Staff
{
    public int IdStaff { get; set; }

    public int PassportDetails { get; set; }

    public int PhoneNumber { get; set; }

    public string FullName { get; set; } = null!;
}
