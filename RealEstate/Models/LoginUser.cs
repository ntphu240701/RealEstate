using System;
using System.Collections.Generic;

namespace RealEstate.Models;

public partial class LoginUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    /// <summary>
    /// 0: inactive 
    /// 1: active
    /// </summary>
    public int Status { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
}
