using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database.Infracstructure;

namespace VLMS.Database.Repository
{
    public interface IItemProfilePhotoRepository : IRepository<ItemProfilePhoto>
    {
    }

    public class ItemProfilePhotoRepository : RepositoryBase<ItemProfilePhoto>, IItemProfilePhotoRepository
    {
        public ItemProfilePhotoRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
   
}
