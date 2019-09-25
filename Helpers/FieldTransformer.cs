using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Helpers
{
    public class FieldTransformer
    {
        private readonly IMapper mapper;

        //public FieldTransformer()
        //{
        //    this.mapper = AutoMapper.Configuration;
        //}

        public int? ToNullableInt(object field)
        {
            return field != System.DBNull.Value ? Convert.ToInt32(field) : 0;
        }

        public int ToInt(object field)
        {
            return field != System.DBNull.Value ? Convert.ToInt32(field) : 0;
        }

        public decimal? ToNullableDecimal(object field)
        {
            return field != System.DBNull.Value ? Convert.ToDecimal(field) : 0;
        }

        public decimal ToDecimal(object field)
        {
            return field != System.DBNull.Value ? Convert.ToDecimal(field) : 0;
        }

        public double? ToNullableDouble(object field)
        {
            return field != System.DBNull.Value ? Convert.ToDouble(field) : 0;
        }

        public double ToDouble(object field)
        {
            return field != System.DBNull.Value ? Convert.ToDouble(field) : 0;
        }

        public long? ToNullableLong(object field)
        {
            return field != System.DBNull.Value ? Convert.ToInt64(field) : 0;
        }

        public long ToLong(object field)
        {
            return field != System.DBNull.Value ? Convert.ToInt64(field) : 0;
        }

        public bool? ToNullableBool(object field)
        {
            return field != System.DBNull.Value ? Convert.ToBoolean(field) : false;
        }

        public bool ToBool(object field)
        {
            return field != System.DBNull.Value ? Convert.ToBoolean(field) : false;
        }

        public DateTime? ToNullableDateTime(object field)
        {
            return field != System.DBNull.Value ? Convert.ToDateTime(field) : default(DateTime?);
        }

        public DateTime ToDateTime(object field)
        {
            return field != System.DBNull.Value ? Convert.ToDateTime(field) : default(DateTime);
        }

        public List<T> ConvertDataTableToList<T>(DataTable datatable) where T : new()
        {
            List<T> _list = mapper.Map<IDataReader, List<T>>(datatable.CreateDataReader());
            return _list;
        }
    }
}
