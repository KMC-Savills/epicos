using EpicOS.Models.Entities;
using EpicOS.Models.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Repository
{
    public class LocationRepository : BaseRepository
    {
        public List<City> GetAllCity()
        {
            List<City> result = new List<City>();

            var reader = dbConnection.Select("usp_City_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        City item = new City();
                        item.CityID = transform.ToInt(row["CityID"]);
                        item.CityName = row["CityName"].ToString();
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<Region> RegionGetAll()
        {
            List<Region> result = new List<Region>();

            var reader = dbConnection.Select("usp_Region_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Region item = new Region();
                        item.RegionID = transform.ToInt(row["ID"]);
                        item.RegionName = row["City Name"].ToString();
                        item.Coordinates = row["Coordinates"].ToString();
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<SubMarket> SubMarketGetAll()
        {
            List<SubMarket> result = new List<SubMarket>();

            var reader = dbConnection.Select("usp_SubMarket_GetAll", null, CommandType.StoredProcedure);
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        SubMarket item = new SubMarket();
                        item.SubMarketID = transform.ToInt(row["ID"]);
                        item.SubMarketName = row["City Name"].ToString();
                        item.CityID = transform.ToInt(row["CityID"]);
                        item.Country = row["Country"].ToString();
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}
