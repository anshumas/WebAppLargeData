using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppLargeData.POCO;

namespace WebAppLargeData.Manager
{
    public class LargeDataManager : ILargeDataManager
    {
        public IEnumerable<CustomLargeDataEntity> GetLargData()
        {
            return new List<CustomLargeDataEntity>();
        }
    }
}