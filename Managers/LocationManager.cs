using EpicOS.Helpers;
using EpicOS.Models.Entities;
using EpicOS.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Managers
{
    public class LocationManager : BaseManager
    {

        private LocationRepository locationRepo;

        public LocationManager()
        {
            this.locationRepo = new LocationRepository();
        }

        public List<City> GetCities()
        {
            List<City> cities = cacheNinja.cache["City_GetAll"] as List<City>;
            if (cities == null)
            {
                cities = locationRepo.GetAllCity();
                cacheNinja.cache.Set("City_GetAll", cities, cacheNinja.cacheExpiry);
            }
            return cities;
        }


        public List<Region> RegionGetAll()
        {
            List<Region> regions = cacheNinja.cache["Region_GetAll"] as List<Region>;
            if (regions == null)
            {
                regions = locationRepo.RegionGetAll();
                cacheNinja.cache.Set("Region_GetAll", regions, cacheNinja.cacheExpiry);
            }
            return regions;
        }

        public List<SubMarket> SubMarketGetAll()
        {
            List<SubMarket> subMarkets = cacheNinja.cache["SubMarket_GetAll"] as List<SubMarket>;
            if (subMarkets == null)
            {
                subMarkets = locationRepo.SubMarketGetAll();
                cacheNinja.cache.Set("SubMarket_GetAll", subMarkets, cacheNinja.cacheExpiry);
            }
            return subMarkets;
        }
    }
}
