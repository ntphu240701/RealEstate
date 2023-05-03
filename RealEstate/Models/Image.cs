using System;
using System.Collections.Generic;

namespace RealEstate.Models;

public partial class Image
{
    public int Id { get; set; }

    public int RealEstateId { get; set; }

    public string Image1 { get; set; } = null!;

    public virtual Property Property { get; set; } = null!;
}
