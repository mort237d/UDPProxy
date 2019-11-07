using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib;

namespace SensorRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private static List<SensorData> _senseData = new List<SensorData>
        {
            new SensorData(1, "Room", 32, 900),
            new SensorData(2, "Room2", 33, 901)
        };

        // GET: api/Sensors
        [HttpGet]
        public IEnumerable<SensorData> Get()
        {
            return _senseData;
        }

        // GET: api/Sensors/5
        [HttpGet("{id}")]
        public SensorData Get(int id)
        {
            return _senseData.Find(s => s.Id == id);
        }

        // POST: api/Sensors
        [HttpPost]
        public void Post([FromBody] SensorData value)
        {
            _senseData.Add(value);
        }

        // PUT: api/Sensors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SensorData value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
