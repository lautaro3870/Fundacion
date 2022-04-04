using ApiFundacion.Models;
using ApiFundacion.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly dena66utud3alcContext context;

        public AreaRepository(dena66utud3alcContext context)
        {
            this.context = context;
        }

        public bool CreateArea(Area area)
        {
            context.Areas.Add(area);
            return Save();
        }

        public bool DeleteArea(Area area)
        {
            context.Areas.Remove(area);
            return Save();
        }

        public Area GetArea(int id)
        {
            return context.Areas.FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Area> GetAreas()
        {
            return context.Areas.OrderBy(x => x.Area1).ToList();
        }

        public bool Save()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateArea(Area area)
        {
            context.Areas.Update(area);
            return Save();
        }
    }
}
