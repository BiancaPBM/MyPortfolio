using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnologyPortfolio.Data.Context
{
  public class TechnologyContext:DbContext
  {
    public TechnologyContext(DbContextOptions options):base(options) { }


    public DbSet<TechnologyEntity> Technologies { get; set; }
  }
}
