using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Models;

public partial class News
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Contents { get; set; } = null!;

    public string? Title { get; set; }
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    [Display(Name = "Front Image")]
    [NotMapped]
    public IFormFile FrontImage { get; set; }
}
