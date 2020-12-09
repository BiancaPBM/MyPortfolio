using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechnologyPortfolio.Data
{
  public class TechnologyEntity
  {
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
  }
}
