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

        [HttpGet("/api/office/getall", Name = "Office_GetAll")]
        public IEnumerable<Office> GetAll()
        {
            OfficeManager manager = new OfficeManager();
            return manager.OfficeGetAll();
        }


        // GET: api/Device
        [HttpGet("/api/device/encryptmac", Name = "Device_EncryptMAC")]
        public IEnumerable<string> Get()
        {
            Blitz helper = new Blitz();
            string deviceMAC = helper.GenerateToken("B8:7C6F:1A:D8:25");
            return new string[] { deviceMAC, "value2" };
            //return new string[] { "Please add a parameter", "Parameter is an encoded MAC address" };
        }

        // GET: api/Device/5
        [HttpGet("/api/device/getbyhubmac/{token}", Name = "Device_Sensor_GetByHubMAC")]
        public List<Device> GetSensorByHubMAC(string token)
        {
            Blitz helper = new Blitz();
            string deviceMAC = helper.DecodeToken(token);

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

        [HttpPost("/api/device/sensor-list", Name = "Device_SensorList")]
        [Consumes(MediaTypeNames.Application.Json)]
        public List<Device> GetSensorsByHubMAC(Device parameter)
        {
            DeviceManager manager = new DeviceManager();
            List<Device> devices = new List<Device>();
            Hub hub = manager.HubGetByMAC(parameter.MAC);
            if (hub != null)
            {
                if (hub.IsActive)
                {
                    devices = manager.GetDevicesByOffice(hub.OfficeID);
                }
            }
            return devices;
        }

        [HttpPost("/api/device/generatetoken", Name = "Device_GenerateToken")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateToken(Device parameter)
        {
            DeviceManager manager = new DeviceManager();
            if (manager.IsActive(parameter.MAC, 2))
            {
                Blitz helper = new Blitz();
                string token = helper.GenerateToken(parameter.MAC);
                return Ok(token);
            }
            return BadRequest();
        }

        //[HttpPost("/api/device/telemery/insert", Name = "Device_Telemery_Insert")]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public IActionResult CreateTelemery(Telemery parameter)
        //{
        //    DeviceManager manager = new DeviceManager();
        //    if (manager.IsActive(parameter.MAC, 1))
        //    {
        //        Workpoint point = manager.WorkpointGetByMAC(parameter.MAC);
        //        Telemery telemery = new Telemery();
        //        telemery.MAC = parameter.MAC;
        //        telemery.IPAddress = parameter.IPAddress;
        //        telemery.DateCreated = parameter.DateCreated;
        //        telemery.WorkpointID = point.ID;
        //        telemery.IsActive = true;
        //        telemery.IsDeleted = false;
        //        Result result = manager.TelemeryInsert(telemery);
        //        if (result.ID > 0)
        //        {
        //            return Ok(telemery);
        //        }
        //    }
        //    return BadRequest();
        //}

        [HttpPost("/api/device/telemery/insert", Name = "Device_Telemery_Insert_Batch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTelemeryByBatch(IEnumerable<Telemery> parameters)
        {
            DeviceManager manager = new DeviceManager();
            if (parameters.Count() > 0)
            {
                foreach (Telemery parameter in parameters)
                {
                    if (manager.IsActive(parameter.MAC, 1))
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
