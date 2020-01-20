using EpicOS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpicOS.Repository
{
    public class BookRepository : BaseRepository
    {
        public List<Book> GetAll()
        {
            List<Book> result = new List<Book>();
            var reader = dbConnection.Select("usp_Book_GetAll");
            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    foreach (DataRow row in reader.Rows)
                    {
                        Book item = new Book();
                        item.ID = transform.ToInt(row["ID"]);
                        item.UserID = transform.ToInt(row["UserID"]);
                        item.WorkpointID = transform.ToInt(row["WorkpointID"]);
                        item.FloorID = transform.ToInt(row["FloorID"]);
                        item.OfficeID = transform.ToInt(row["OfficeID"]);
                        item.CheckIn = transform.ToDateTime(row["CheckIn"]);
                        item.CheckOut = transform.ToDateTime(row["CheckOut"]);
                        item.IsActive = transform.ToBool(row["IsActive"]);
                        item.IsDeleted = transform.ToBool(row["IsDeleted"]);
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public Book GetByID(int id)
        {
            Book item = new Book();

            object parameter = new Book()
            {
                ID = id
            };
            var reader = dbConnection.Select("usp_Book_GetByID", parameter, CommandType.StoredProcedure);

            if (reader != null)
            {
                if (reader.Rows.Count > 0)
                {
                    item.ID = id;
                    item.UserID = transform.ToInt(reader.Rows[0]["UserID"]);
                    item.WorkpointID = transform.ToInt(reader.Rows[0]["WorkpointID"]);
                    item.FloorID = transform.ToInt(reader.Rows[0]["FloorID"]);
                    item.OfficeID = transform.ToInt(reader.Rows[0]["OfficeID"]);
                    item.CheckIn = transform.ToDateTime(reader.Rows[0]["CheckIn"]);
                    item.CheckOut = transform.ToDateTime(reader.Rows[0]["CheckOut"]);
                    item.IsActive = transform.ToBool(reader.Rows[0]["IsActive"]);
                    item.IsDeleted = transform.ToBool(reader.Rows[0]["IsDeleted"]);
                }
            }
            return item;
        }

        public Result Insert(Book parameter)
        {
            var result = dbConnection.Insert("usp_Book_Insert", parameter);
            return result;
        }

        public Result Update(Book parameter)
        {
            var result = dbConnection.Update("usp_Book_Update", parameter);
            return result;
        }
    }
}
