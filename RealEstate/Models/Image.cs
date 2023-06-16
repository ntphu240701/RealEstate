using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models;

public partial class Image
{
    public int Id { get; set; }

    public int? NewsId { get; set; }
    public int? RealEstateId { get; set; }

    public string Image1 { get; set; } = null!;

    public int? SellerId { get; set; }


    public int? LoginUserId { get; set; }

    public virtual LoginUser? LoginUser { get; set; }

    public virtual News? News { get; set; }

    public virtual Property? RealEstate { get; set; }

    public virtual Seller? Seller { get; set; }
}
