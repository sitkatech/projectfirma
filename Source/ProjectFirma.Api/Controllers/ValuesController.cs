using System.Web.Http;

namespace ProjectFirma.Api.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/values/List")]
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet]
        [Route("api/values/get/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [HttpPost]
        [Route("api/values/post/{id}")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/values/put/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("api/values/delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}
