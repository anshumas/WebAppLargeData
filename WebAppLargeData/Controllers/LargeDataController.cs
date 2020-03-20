using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppLargeData.Manager;
using WebAppLargeData.POCO;

namespace WebAppLargeData.Controllers
{
    public class LargeDataController : ApiController
    {
        private ILargeDataManager _repo = null;
        public LargeDataController(ILargeDataManager repo)
        {
            _repo = repo;

        }
        // GET api/values
        public IEnumerable<CustomLargeDataEntity> Get()
        {
            return _repo.GetLargData();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
