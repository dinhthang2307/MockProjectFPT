using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database.Infracstructure;

namespace VLMS.Database.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
    }

    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
   
}
