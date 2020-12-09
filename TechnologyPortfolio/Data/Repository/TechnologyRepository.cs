using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnologyPortfolio.Data.Context;

namespace TechnologyPortfolio.Data.Repository
{
  public class TechnologyRepository
  {
    private TechnologyContext _context;
    public TechnologyRepository( TechnologyContext context)
    {
      _context = context;
    }
    public List<TechnologyEntity> GetAllTechnologies()
    {
      return _context.Technologies.ToList();
    }
    public TechnologyEntity GetTechnologyById(Guid id)
    {
      return _context.Technologies.First(t => t.Id == id);
    }
    public void CreateTechnoloy(Technology technology)
    {
      var technologyEntity = new TechnologyEntity { Description = technology.Description, Id = new Guid(), Title = technology.Title, Url = technology.Url };
      _context.Add(technologyEntity);
      
      _context.SaveChanges();
    }
    public void UpdateTechnoloy(TechnologyEntity technology)
    {
      _context.SaveChanges();
    }
    public void DeleteTechnology(Guid id)
    {
      var techToDelete = _context.Technologies.First(t => t.Id == id);
      _context.Remove(techToDelete);
      _context.SaveChanges();
    }
  }
}
