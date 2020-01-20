﻿using EpicOS.Models.Entities;
using EpicOS.Models.Parameters;
using EpicOS.Models.ViewModel;
using EpicOS.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EpicOS.Managers
{
    public class DeviceManager : BaseManager
    {

        private DeviceRepository deviceRepository;

        public DeviceManager()
        {
            this.deviceRepository = new DeviceRepository();
        }

        public enum DeviceTypes
        {
            Sensor = 1,
            Hub = 2,
            Laptop = 3,
            Desktop = 4,
            Phone = 5,
            Tablet = 6
        }

        public List<Workpoint> WorkpointGetAll()
        {
            List<Workpoint> workpoints = cacheNinja.cache["Workpoint_GetAll"] as List<Workpoint>;
            if (workpoints == null)
            {
                workpoints = deviceRepository.WorkpointGetAll();
                cacheNinja.cache.Set("Workpoint_GetAll", workpoints, cacheNinja.cacheExpiry);
            }
            return workpoints;
        }

        public List<Hub> HubGetAll()
        {
            List<Hub> hubs = cacheNinja.cache["Hub_GetAll"] as List<Hub>;
            if (hubs == null)
            {
                hubs = deviceRepository.HubGetAll();
                cacheNinja.cache.Set("Hub_GetAll", hubs, cacheNinja.cacheExpiry);
            }
            return hubs;
        }

        public List<Telemery> TelemeryGetAll()
        {
            List<Telemery> telemetry = cacheNinja.cache["Telemery_GetAll"] as List<Telemery>;
            if (telemetry == null)
            {
                telemetry = deviceRepository.TelemeryGetAll();
                cacheNinja.cache.Set("Telemery_GetAll", telemetry, cacheNinja.cacheExpiry);
            }
            return telemetry;
        }

        public List<Telemery> TelemeryGetFilter(TelemeryFilter parameter)
        {
            return deviceRepository.TelemeryGetFilter(parameter);
        }

        public Hub GetByID(int id)
        {
            return HubGetAll().FirstOrDefault(e => e.ID.Equals(id));
        }

        public Hub HubGetByMAC(string MAC)
        {
            Hub hub = HubGetAll().FirstOrDefault(w => w.MAC.ToLower().Equals(MAC.ToLower()));
            return hub;
        }

        public Workpoint WorkpointGetByMAC(string MAC)
        {
            Workpoint workpoint = WorkpointGetAll().FirstOrDefault(w => w.MAC.Equals(MAC));
            return workpoint;
        }

        public bool IsActive(string MAC, int type = 0)
        {
            bool result = false;
            try
            {
                switch (type)
                {
                    case 1:
                        List<Workpoint> workpoints = WorkpointGetAll();
                        result = workpoints.FirstOrDefault(w => w.MAC.Equals(MAC)).IsActive;
                        break;
                    case 2:
                        List<Hub> hubs = HubGetAll();
                        result = hubs.FirstOrDefault(w => w.MAC.Equals(MAC)).IsActive;
                        break;
                    default:
                        List<Hub> xhubs = HubGetAll();
                        List<Workpoint> xworkpoints = WorkpointGetAll();
                        Hub hub = xhubs.FirstOrDefault(x => x.MAC.Equals(MAC));
                        Workpoint wpoint = xworkpoints.FirstOrDefault(x => x.MAC.Equals(MAC));
                        if (hub != new Hub())
                        {
                            result = hub.IsActive;
                        }
                        else
                        {
                            result = wpoint.IsActive;
                        }
                        break;
                }
            }
            catch (Exception error)
            {
                result = false;
            }
            return result;
        }

        public List<Device> GetDevicesByOffice(int OfficeID)
        {
            List<Device> results = new List<Device>();
            foreach (Workpoint item in WorkpointGetAll().Where(w => w.OfficeID.Equals(OfficeID)).ToList())
            {
                Device x = new Device();
                x.ID = item.ID;
                x.IPaddress = item.IPaddress;
                x.MAC = item.MAC;
                x.Name = item.Name;
                results.Add(x);
            }
            return results;
        }

        public Result WorkpointInsert(Workpoint workpoint)
        {
            Result result = deviceRepository.WorkpointInsert(workpoint);
            return result;
        }

        public Result WorkpointUpdate(Workpoint workpoint)
        {
            Result result = deviceRepository.WorkpointUpdate(workpoint);
            return result;
        }

        public Result HubInsert(Hub hub)
        {
            Result result = deviceRepository.HubInsert(hub);
            return result;
        }

        public Result HubUpdate(Hub hub)
        {
            Result result = deviceRepository.HubUpdate(hub);
            return result;
        }

        public Result LogInsert(Log log)
        {
            Result result = deviceRepository.LogInsert(log);
            return result;
        }

        public Result TelemeryInsert(Telemery telemery)
        {
            Result result = new Result();
            TelemeryFilter filter = new TelemeryFilter();
            Workpoint point = WorkpointGetByMAC(telemery.MAC);
            if (point.IsActive)
            {
                filter.DateStart = telemery.DateCreated.AddMinutes(-2);
                filter.DateEnd = telemery.DateCreated.AddMinutes(2);
                filter.FloorID = point.FloorID;
                filter.OfficeID = point.OfficeID;
                List<Telemery> LatestTelemeries = TelemeryGetFilter(filter);
                if (LatestTelemeries.Count > 0)
                {
                    Telemery theOne = LatestTelemeries.Where(t => t.MAC.ToLower().Equals(telemery.MAC.ToLower())).FirstOrDefault();
                    if (!theOne.IsActive)
                    {
                        result = deviceRepository.TelemeryInsert(telemery);
                    }
                }
                else
                {
                    result = deviceRepository.TelemeryInsert(telemery);
                }
            }
            return result;
        }

        public Result TelemeryUpdate(Telemery telemery)
        {
            Result result = deviceRepository.TelemeryUpdate(telemery);
            return result;
        }
        public List<DeviceViewModel> DeviceGetAll()
        {
            OfficeManager officeManager = new OfficeManager();
            List<DeviceViewModel> deviceViewModels = new List<DeviceViewModel>();
            List<Workpoint> workpointGetAll = WorkpointGetAll();
            List<Office> offices = officeManager.OfficeGetAll();
            List<Hub> hubs = HubGetAll();
            List<Floor> floors = officeManager.FloorGetAll();
            foreach (Hub hub in hubs)
            {
                DeviceViewModel deviceItems = new DeviceViewModel();
                deviceItems.ID = hub.ID;
                deviceItems.Name = hub.Name;
                deviceItems.Type = 2;
                deviceItems.MAC = hub.MAC;
                deviceItems.IPaddress = hub.IPaddress;
                deviceItems.OfficeID = hub.OfficeID;
                deviceItems.FloorID = hub.FloorID;
                deviceItems.RoomID = hub.RoomID;
                deviceItems.OfficeName = offices.First(item => item.ID.Equals(hub.OfficeID)).Name;
                deviceItems.Floor = floors.First(item => item.ID.Equals(hub.FloorID)).Name;
                deviceViewModels.Add(deviceItems);
            }
            foreach (Workpoint workpoint in workpointGetAll)
            {
                DeviceViewModel deviceItems = new DeviceViewModel();
                deviceItems.ID = workpoint.ID;
                deviceItems.Name = workpoint.Name;
                deviceItems.Type = 1;
                deviceItems.MAC = workpoint.MAC;
                deviceItems.IPaddress = workpoint.IPaddress;
                deviceItems.OfficeID = workpoint.OfficeID;
                deviceItems.FloorID = workpoint.FloorID;
                deviceItems.RoomID = workpoint.RoomID;
                deviceItems.OfficeName = offices.First(item => item.ID.Equals(workpoint.OfficeID)).Name;
                deviceItems.Floor = floors.First(item => item.ID.Equals(workpoint.FloorID)).Name;
                deviceViewModels.Add(deviceItems);
            }
            return deviceViewModels;
        }
       
    }
}