using System;
using System.Collections.Generic;

namespace ccaaffee.Models;

public partial class Drink
{
    public int IdProducts { get; set; }

    public string DrinkSelection { get; set; } = null!;

    public int Price { get; set; }
}
