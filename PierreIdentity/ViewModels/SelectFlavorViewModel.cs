using PierreIdentity.Models;
using System.Collections.Generic;

namespace PierreIdentity.ViewModels
{
  public class SelectFlavorViewModel
  {
    public int FlavorId { get; set; }
    public string Name { get; set; }
    public bool IsSelected { get; set; }
  }
}