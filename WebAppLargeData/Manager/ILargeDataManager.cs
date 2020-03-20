using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppLargeData.POCO;

namespace WebAppLargeData.Manager
{
    public interface ILargeDataManager
    {
        IEnumerable<CustomLargeDataEntity> GetLargData();
    }
}
