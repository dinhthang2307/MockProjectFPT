using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database.Infracstructure;

namespace VLMS.Database.Repository
{
    public interface IItemCategoryRepository : IRepository<ItemCategory>
    {
    }

    public class ItemCategoryRepository : RepositoryBase<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
   
}
