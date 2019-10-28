using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpicOS.Models.Entities;

namespace EpicOS.Repository
{
    public class OfficeRepository : BaseRepository
    {

        public Result Insert(User parameter)
        {
            var result = dbConnection.Insert("usp_Office_Insert", parameter);
            return result;
        }

        public Result Update(User parameter)
        {
            var result = dbConnection.Update("usp_Office_Update", parameter);
            return result;
        }

    }
}
