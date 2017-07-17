using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VLMS.Database.Infracstructure
{
    public interface IDbFactory:IDisposable
    {
        VLMSDataEntities Init();
    }
}
