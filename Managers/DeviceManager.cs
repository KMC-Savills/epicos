using EpicOS.Models.Entities;
using EpicOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Managers
{
    public class DeviceManager : BaseManager
    {

        private DeviceRepository deviceRepository;

        public DeviceManager()
        {
            this.deviceRepository = new DeviceRepository();
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
                cacheNinja.cache.Set("Workpoint_GetAll", hubs, cacheNinja.cacheExpiry);
            }
            return hubs;
        }

        public Hub HubGetByMAC(string MAC)
        {
            Hub hub = HubGetAll().FirstOrDefault(w => w.MAC.Equals(MAC));
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
            catch
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
                x.IPAddress = item.IPAddress;
                x.MAC = item.MAC;
                x.Name = item.Name;
                results.Add(x);
            }
            return results;
        }

        public Result TelemeryInsert(Telemery telemery)
        {
            Result result = deviceRepository.TelemeryInsert(telemery);
            return result;
        }

    }
}