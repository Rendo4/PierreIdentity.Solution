using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PierreIdentity.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required]
    public string Name { get; set; }
  }
}