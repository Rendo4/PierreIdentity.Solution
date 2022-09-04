using PierreIdentity.Models;
using System.Collections.Generic;

namespace PierreIdentity.ViewModels
{
  public class ListAllViewModel
  {
    public List<Treat> Treats { get; set; }
    public List<Flavor> Flavors { get; set; }
  }
}