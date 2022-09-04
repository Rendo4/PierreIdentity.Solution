using PierreIdentity.Models;
using System.Collections.Generic;

namespace PierreIdentity.ViewModels
{
  public class AddFlavorViewModel
  {
    public Treat Treat { get; set; }
    public IEnumerable<SelectFlavorViewModel> Flavors { get; set; }
  }
}