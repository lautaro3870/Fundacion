using ApiFundacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.IRepository
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAreas();
        Area GetArea(int id);
        bool CreateArea(Area area);
        bool UpdateArea(Area area);
        bool DeleteArea(Area area);
        bool Save();

    }
}
