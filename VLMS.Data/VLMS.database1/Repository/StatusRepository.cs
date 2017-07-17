using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database.Infracstructure;

namespace VLMS.Database.Repository
{
    public interface IStatusRepository : IRepository<Status>
    {
    }

    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
 
}
