using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database.Infracstructure;

namespace VLMS.Database.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
    }

    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
   
}
