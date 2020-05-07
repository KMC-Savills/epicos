using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using EpicOS.Helpers;
using EpicOS.Managers;
using EpicOS.Models.Entities;
using EpicOS.Models.Parameters;
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

        [HttpGet("/api/floor/getbyofficeid/{id}", Name = "Floor_GetByOfficeID")]
        public IEnumerable<Floor> FloorGetByOfficeID(int id)
        {
            OfficeManager manager = new OfficeManager();
            return manager.FloorGetByOfficeID(id);
        }

        [HttpPost("/api/device/telemery/list", Name = "Device_Telemery_LatestList")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Telemery> RequestTelemery(TelemeryFilter filter)
        {
            DeviceManager manager = new DeviceManager();
            return manager.TelemeryGetFilter(filter);
        }

        [HttpGet("/api/device/encryptmac", Name = "Device_EncryptMAC")]
        public IEnumerable<string> Get()
        {
            Blitz helper = new Blitz();
            string deviceMAC = helper.GenerateToken("B8:7C6F:1A:D8:25");
            return new string[] { deviceMAC, "value2" };
            //return new string[] { "Please add a parameter", "Parameter is an encoded MAC address" };
        }

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

        [HttpPost("/api/device/telemery/insert", Name = "Device_Telemery_Insert_Batch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateTelemeryByBatch(IEnumerable<Telemery> parameters)
        {
            DeviceManager manager = new DeviceManager();
            List<Result> results = new List<Result>();
            if (parameters.Count() > 0)
            {
                foreach (Telemery parameter in parameters)
                {
                    if (manager.IsActive(parameter.MAC, 1))
                    {
                        Workpoint point = manager.WorkpointGetByMAC(parameter.MAC);
                        parameter.WorkpointID = point.ID;
                        parameter.IsActive = true;
                        parameter.IsDeleted = false;
                        Result result = manager.TelemeryInsert(parameter);
                        if (result.ID > 0)
                        {
                            results.Add(result);
                        }
                    }
                }
                if (results.Count() > 0)
                {
                    return Ok(results);
                }
            }
            return BadRequest();
        }

        [HttpPost("/api/device/log/insert", Name = "Device_Log_Insert_Batch")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateLog(IEnumerable<Log> parameters)
        {
            DeviceManager manager = new DeviceManager();
            List<Result> results = new List<Result>();
            if (parameters.Count() > 0)
            {
                foreach (Log parameter in parameters)
                {
                    if (manager.IsActive(parameter.MAC, 2))
                    {
                        Result result = manager.LogInsert(parameter);
                        if (result.ID > 0)
                        {
                            results.Add(result);
                        }
                    }
                }
                if (results.Count() > 0)
                {
                    return Ok(results);
                }
            }
            return BadRequest();
        }
    }
}
