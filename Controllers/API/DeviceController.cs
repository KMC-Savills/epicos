using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using EpicOS.Helpers;
using EpicOS.Managers;
using EpicOS.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        // GET: api/Device
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //Blitz helper = new Blitz();
            //string deviceMAC = helper.GenerateToken("A2:C54D:2B:5A:32");
            //return new string[] { deviceMAC, "value2" };
            return new string[] { "Please add a parameter", "Parameter is an encoded MAC address" };
        }

        // GET: api/Device/5
        [HttpGet("{id}", Name = "Get")]
        public List<Device> Get(string id)
        {
            Blitz helper = new Blitz();
            string deviceMAC = helper.DecodeToken(id);

            DeviceManager manager = new DeviceManager();
            List<Device> devices = new List<Device>();
            Hub hub = manager.HubGetByMAC(deviceMAC);
            if (hub != null)
            {
                if (hub.IsActive)
                {
                    devices = manager.GetDevicesByOffice(hub.OfficeID);
                }
            }
            return devices;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(Telemery parameter)
        {
            DeviceManager manager = new DeviceManager();
            if (!manager.IsActive(parameter.MAC, 1))
            {
                return BadRequest();
            }
            else
            {
                Workpoint point = manager.WorkpointGetByMAC(parameter.MAC);
                Telemery telemery = new Telemery();
                telemery.MAC = parameter.MAC;
                telemery.IPAddress = parameter.IPAddress;
                telemery.DateCreated = parameter.DateCreated;
                telemery.WorkpointID = point.ID;
                telemery.IsActive = true;
                telemery.IsDeleted = false;
                Result result = manager.TelemeryInsert(telemery);
                if (result.ID > 0)
                {
                    return Ok(telemery);
                }
            }
            return BadRequest();
        }

        // PUT: api/Device/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
