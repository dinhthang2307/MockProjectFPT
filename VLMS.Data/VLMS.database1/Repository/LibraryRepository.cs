using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VLMS.Database.Infracstructure;

namespace VLMS.Database.Repository
{
    public interface ILibraryRepository : IRepository<Library>
    {
    }

    public class LibraryRepository : RepositoryBase<Library>, ILibraryRepository
    {
        public LibraryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
 
}
